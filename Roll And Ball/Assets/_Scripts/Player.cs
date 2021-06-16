using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed = 3.0f;

        public float Speed
        {
            get => _speed;
            set {
                if (value > 10.0f)
                    value = 10.0f;
                    
                _speed = value;
            }
        }

        private Rigidbody _rigidbody;

        private void Start()
        {
            if (Speed > 10) throw new Exception("Скорость выше нормальной!!!");
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            _rigidbody.AddForce(movement * _speed);
        }
    }
}

