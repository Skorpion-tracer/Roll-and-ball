using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall
{
    public class Test : MonoBehaviour
    {
        void Start()
        {
            var interactableObject = new ListInteractableObject<BonusToWin>();

            foreach (var o in interactableObject)
            {
                print(o);
            }
        }
    }
}
