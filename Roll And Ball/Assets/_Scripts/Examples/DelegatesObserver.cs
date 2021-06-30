using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public sealed class DelegatesObserver
    {
        public delegate void Mydelegate(object o);
        public sealed class Source
        {
            private Mydelegate _functions;
            public void Add(Mydelegate f)
            {
                _functions += f;
            }

            public void Remove(Mydelegate f)
            {
                _functions -= f;
            }

            public void Run()
            {
                Debug.Log("RUNS!");
                if (_functions != null) _functions(this);
            }

            public override string ToString()
            {
                return $"Source";
            }
        }

        public sealed class Observer1
        {
            public void Do(object o)
            {
                Debug.Log($"Первый. Принял, что объект {o} побежал");
            }
        }

        public sealed class Observer2
        {
            public void Do(object o)
            {
                Debug.Log($"Второй. Принял, что объект {o} побежал");
            }
        }
    }
}