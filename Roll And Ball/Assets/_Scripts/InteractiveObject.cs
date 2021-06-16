using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollAndBall
{
    public abstract class InteractiveObject : MonoBehaviour, IComparable<InteractiveObject>
    {
        protected Color _color;
        public bool IsInteractable { get; } = true;

        protected Material _material;

        protected virtual void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _color = _material.color;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            Destroy(gameObject);
        }

        protected abstract void Interaction();

        public int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }
    }
}
