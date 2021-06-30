using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall.Model
{
    public sealed class PlayerBall : PlayerBase
    {
        private Rigidbody _rigidbodyPlayer;

        private void Start()
        {
            _rigidbodyPlayer = GetComponent<Rigidbody>();
            Speed = 3.0f;
        }

        public override void Move(float x, float y, float z)
        {
            _rigidbodyPlayer.AddForce(new Vector3(x, y, z) * Speed);
        }
    }
}
