using RollAndBall.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _savePlayer = KeyCode.F6;
        private readonly KeyCode _loadPlayer = KeyCode.F9;
        private readonly KeyCode _moveForward = KeyCode.W;
        private readonly KeyCode _moveBack = KeyCode.S;
        private readonly KeyCode _loadRight = KeyCode.D;
        private readonly KeyCode _loadLeft = KeyCode.A;
        private readonly string _mouseX = "Mouse X";
        private readonly string _mouseY = "Mouse Y";

        public InputController(PlayerBase player)
        {
            _playerBase = player;
            _saveDataRepository = new SaveDataRepository();
        }

        public void Execute()
        {
            if (Input.GetKey(_moveForward))
            {
                _playerBase.MoveForward();
            }
            if (Input.GetKey(_moveBack))
            {
                _playerBase.MoveBack();
            }
            if (Input.GetKey(_loadRight))
            {
                _playerBase.MoveRight();
            }
            if (Input.GetKey(_loadLeft))
            {
                _playerBase.MoveLeft();
            }
            _playerBase.Rotation(Input.GetAxis(_mouseX), Input.GetAxis(_mouseY));

            if (Input.GetKeyDown(_savePlayer))
            {
                _saveDataRepository.Save(_playerBase);
            }
            if (Input.GetKeyDown(_loadPlayer))
            {
                _saveDataRepository.Load(_playerBase);
            }
        }
    }
}
