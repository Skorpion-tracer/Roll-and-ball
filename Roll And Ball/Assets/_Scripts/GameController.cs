using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollAndBall
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        public Text _finishGameLabel;
        private ListInteractableObject<InteractiveObject> _interactiveObjects;
        private DisplayEndGame _displayEndGame;
        private CameraController _cameraController;

        private void Awake()
        {
            _interactiveObjects = new ListInteractableObject<InteractiveObject>();
            _displayEndGame = new DisplayEndGame(_finishGameLabel);
            _cameraController = FindObjectOfType<CameraController>();

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
                }
            }
        }

        private void CaughtPlayer(object value, CaughtPlayerEventArgs args)
        {
            Time.timeScale = 0.0f;
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Count; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFly flay)
                {
                    flay.Fly();
                }

                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }

                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
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