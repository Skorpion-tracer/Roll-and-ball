using RollAndBall.Model;
using UnityEngine;

namespace RollAndBall
{
    public sealed class BonusToSpeed : InteractiveObject, IFly, IFlicker
    {
        [SerializeField] private float _increaseSpeed = 2.0f;
        
        private float _lengthFlay;

        protected override void Awake()
        {
            base.Awake();
            _lengthFlay = Random.Range(2.0f, 4f);
        }

        protected override void Interaction()
        {
            var Player = FindObjectOfType<PlayerBall>();
            Player.Speed += _increaseSpeed;
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
            _material.color = Color.yellow;
        }
    }
}
