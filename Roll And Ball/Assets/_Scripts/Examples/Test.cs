using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollAndBall;

namespace Examples
{
    public class Test : MonoBehaviour
    {
        void Start()
        {
            DelegatesObserver.Source s = new DelegatesObserver.Source();
            DelegatesObserver.Observer1 o1 = new DelegatesObserver.Observer1();
            DelegatesObserver.Observer2 o2 = new DelegatesObserver.Observer2();
            DelegatesObserver.Mydelegate d1 = new DelegatesObserver.Mydelegate(o1.Do);
            s.Add(d1);
            s.Add(o2.Do);
            s.Run();
            s.Remove(o1.Do);
            s.Run();
        }
    }
}
