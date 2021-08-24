using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall.Model
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerBall : PlayerBase
    {
        private Rigidbody _rigidbodyPlayer;
        private Camera _camera;

        private float _rotateSpeed = 0.2f;

        private void Start()
        {
            _rigidbodyPlayer = GetComponent<Rigidbody>();
            Speed = 3.0f;
            _camera = Camera.main;
        }

        public override void MoveForward()
        {
            _rigidbodyPlayer.AddForce(_camera.transform.forward * Speed);
        }

        public override void MoveBack()
        {
            _rigidbodyPlayer.AddForce(-_camera.transform.forward * Speed);
        }

        public override void MoveRight()
        {
            _rigidbodyPlayer.AddForce(_camera.transform.right * Speed);
        }

        public override void MoveLeft()
        {
            _rigidbodyPlayer.AddForce(-_camera.transform.right * Speed);
        }

        public override void Rotation(float mouseX, float mouseY)
        {
            Vector3 movement = Vector3.zero;

            float horizontalInput = mouseX;
            float verticalInput = mouseY;

            if (horizontalInput != 0 || verticalInput != 0)
            {
                movement.x = horizontalInput;
                movement.z = verticalInput;

                Quaternion temp = _camera.transform.rotation;
                _camera.transform.eulerAngles = new Vector3(0, _camera.transform.eulerAngles.y, 0);
                movement = _camera.transform.TransformDirection(movement);
                _camera.transform.rotation = temp;

                Quaternion direction = Quaternion.LookRotation(movement);
                _rigidbodyPlayer.rotation = Quaternion.Lerp(transform.rotation, direction,
                    _rotateSpeed * Time.deltaTime);
            }
        }
    }
}
