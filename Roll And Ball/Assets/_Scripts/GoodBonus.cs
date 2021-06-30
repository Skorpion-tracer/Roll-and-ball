using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall
{
    public sealed class GoodBonus : InteractiveObject, IFly, 
                                    IFlicker
    {
        [SerializeField] private int _point;

        private float _lengthFlay;

        protected override void Awake()
        {
            base.Awake();
            _lengthFlay = UnityEngine.Random.Range(2.0f, 2.5f);
        }

        public event Action OnPickUp;
        public event Action<int> OnDisplayBonus;

        protected override void Interaction()
        {
            OnDisplayBonus?.Invoke(_point);
            OnPickUp?.Invoke();
        }

        public override void Execute()
        {
            if (!IsInteractable)
            {
                return;
            }
            Fly();
            Flicker();
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
