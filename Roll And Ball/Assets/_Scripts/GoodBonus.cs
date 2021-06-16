using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall
{
    public sealed class GoodBonus : InteractiveObject, IFly, 
                                    IFlicker
    {
        public int Point;
        private float _lengthFlay;
        private DisplayBonuses _displayBonuses;

        protected override void Awake()
        {
            base.Awake();
            _lengthFlay = UnityEngine.Random.Range(2.0f, 2.5f);
            _displayBonuses = FindObjectOfType<DisplayBonuses>();
        }

        public event Action OnPickUp;

        protected override void Interaction()
        {
            _displayBonuses.Display(5);
            OnPickUp?.Invoke();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = Color.cyan;
        }
    }
}
