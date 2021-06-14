using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall
{
    public sealed class PlayerBall : Player
    {
        private void FixedUpdate()
        {
            Move();
        }
    }
}
