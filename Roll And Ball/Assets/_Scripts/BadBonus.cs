using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollAndBall
{
    public sealed class BadBonus : InteractiveObject, IFlay, 
                IRotation, ICloneable, IFlicker
    {
        private Material _material;
        private float _lengthFlay;
        private float _speedRotation;
        private DisplayBonuses _displayToBonuses;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(2.3f, 2.5f);
            _speedRotation = Random.Range(10.0f, 90.0f);
            _displayToBonuses = FindObjectOfType<DisplayBonuses>();
        }

        protected override void Interaction()
        {
            _displayToBonuses.DisplayToGameOver();
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        public object Clone()
        {
            var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            return result;
        }

        public void Flicker()
        {
            _material.color = Color.red;
        }
    }
}
