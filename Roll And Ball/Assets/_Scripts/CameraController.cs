using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;

namespace RollAndBall
{
    public sealed class CameraController : MonoBehaviour
    {
        public Player Player;

        private Vector3 _offset;
        private Animator _animator;

        private void Start()
        {
            _offset = transform.position - Player.transform.position;
            _animator = GetComponent<Animator>();
        }

        private void LateUpdate()
        {
            transform.position = Player.transform.position + _offset;
        }

        public void IsShakeCamera()
        {
            _animator.SetTrigger(AnimationConsts.SHAKE_CAMERA);            
        }        
    }
}
