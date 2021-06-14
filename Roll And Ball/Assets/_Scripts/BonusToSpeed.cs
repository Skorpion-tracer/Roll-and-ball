using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall
{
    public sealed class BonusToSpeed : InteractiveObject, IFlay, IFlicker
    {
        [SerializeField] private float _increaseSpeed = 2.0f;

        private Material _material;
        private float _lengthFlay;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(2.0f, 4f);
        }

        protected override void Interaction()
        {
            var Player = FindObjectOfType<PlayerBall>();
            Player.Speed += _increaseSpeed;
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = Color.yellow;
        }
    }
}
