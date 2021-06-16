using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RollAndBall
{
    public sealed class ListInteractableObject<T> : IEnumerator, IEnumerable where T : InteractiveObject
    {
        private InteractiveObject[] _interactiveObjects;
        private static int _index = -1;
        private InteractiveObject _current;

        public ListInteractableObject()
        {
            _interactiveObjects = Object.FindObjectsOfType<T>();
            Array.Sort(_interactiveObjects);
        }

        public InteractiveObject this[int index]
        {
            get => _interactiveObjects[index];
            set => _interactiveObjects[index] = value;
        }

        public bool MoveNext()
        {
            _index++;
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }            
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _interactiveObjects[_index];

        public int Count => _interactiveObjects.Length;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
