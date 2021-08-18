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
        private readonly string _horizontal = "Horizontal";
        private readonly string _vertical = "Vertical";
        private readonly string _mouseX = "Mouse X";
        private readonly string _mouseY = "Mouse Y";

        public InputController(PlayerBase player)
        {
            _playerBase = player;
            _saveDataRepository = new SaveDataRepository();
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis(_horizontal), 0.0f, Input.GetAxis(_vertical));
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
