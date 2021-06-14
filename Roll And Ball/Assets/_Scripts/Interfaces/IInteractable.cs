using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall
{
    public interface IInteractable : IAction, IInitialization
    {
        bool IsInteractable { get; }
    }
}
