using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;

namespace RollAndBall
{
    public sealed class CameraController : IExecute
    {
        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;
        private Animator _animator;

        public CameraController(Transform player, Transform mainCamera, Animator animator)
        {
            _player = player;
            _mainCamera = mainCamera;
            _mainCamera.LookAt(_player);
            _animator = animator;
            _offset = _mainCamera.position - _player.position;
        }

        public void Execute()
        {
            _mainCamera.position = _player.position + _offset;
        }

        public void IsShakeCamera()
        {
            _animator.SetTrigger(AnimationConsts.SHAKE_CAMERA);            
        }        
    }
}
