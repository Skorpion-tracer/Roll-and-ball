using RollAndBall.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RollAndBall
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private ListInteractableObject<InteractiveObject> _interactiveObjects;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private CameraController _cameraController;
        private ListExecuteObject _interactiveObject;
        private InputController _inputController;
        private PlayerBase _player;
        private Reference _reference;

        private void Awake()
        {
            _reference = new Reference();
            _interactiveObjects = new ListInteractableObject<InteractiveObject>();
            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Score, _reference.Win);
            _player = _reference.PlayerBall;
            _cameraController = new CameraController(_player.transform, _reference.MainCamera.transform, _reference.Animator);
            _inputController = new InputController(_player);            
            _interactiveObject = new ListExecuteObject();

            _interactiveObject.AddExecuteObject(_cameraController);
            _interactiveObject.AddExecuteObject(_inputController);

            foreach (var o in _interactiveObjects)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;
                }

                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPickUp += _cameraController.IsShakeCamera;
                    goodBonus.OnDisplayBonus += _displayBonuses.Display;
                }

                if (o is BonusToWin bonusToWin)
                {
                    bonusToWin.OnDisplayBonus += _displayBonuses.DisplayToWin;
                    bonusToWin.OnWin += CaughtPlayer;
                }
            }

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
            _reference.RestartButton.gameObject.SetActive(true);
        }

        private void CaughtPlayer(object value, CaughtPlayerEventArgs args)
        {
            Time.timeScale = 0.0f;
            _reference.RestartButton.gameObject.SetActive(true);
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                if (o is InteractiveObject interactiveObject)
                {
                    Destroy(interactiveObject.gameObject);
                    if (o is BadBonus badBonus)
                    {
                        badBonus.CaughtPlayer -= CaughtPlayer;
                        badBonus.CaughtPlayer -= _displayEndGame.GameOver;
                    }
                }                
            }
        }
    }
}