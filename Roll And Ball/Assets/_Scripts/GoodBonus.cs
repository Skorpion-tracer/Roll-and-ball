using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall
{
    public sealed class GoodBonus : InteractiveObject, IFlay, IFlicker
    {
        public int Point;
        private Material _material;
        private float _lengthFlay;
        private DisplayBonuses _displayBonuses;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(1.0f, 5.0f);
            _displayBonuses = new DisplayBonuses();
        }

        protected override void Interaction()
        {
            _displayBonuses.Display(5);
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}
