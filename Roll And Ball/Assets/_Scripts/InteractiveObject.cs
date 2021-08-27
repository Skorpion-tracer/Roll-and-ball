using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollAndBall
{
    public abstract class InteractiveObject : MonoBehaviour, IComparable<InteractiveObject>, IExecute
    {
        protected Color _color;

        private bool _isInteractable;

        public bool IsInteractable
        {
            get => _isInteractable;
            private set {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        protected Material _material;

        protected virtual void Awake()
        {
            IsInteractable = true;
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
            IsInteractable = false;
        }

        protected abstract void Interaction();
        public abstract void Execute();

        public int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }
    }
}
