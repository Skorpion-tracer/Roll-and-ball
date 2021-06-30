using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall.Model
{
    public abstract class PlayerBase : MonoBehaviour
    {
        [SerializeField] private float _speed = 3.0f;

        public float Speed
        {
            get => _speed;
            set {
                if (value > 10) value = 10;
                _speed = value;
            }
        }

        public abstract void Move(float x, float y, float z);
    }
}

