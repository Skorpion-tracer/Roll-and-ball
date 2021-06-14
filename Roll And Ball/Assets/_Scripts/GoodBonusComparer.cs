﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall
{
    public class GoodBonusComparer : IComparer<GoodBonus>
    {
        public int Compare(GoodBonus x, GoodBonus y)
        {
            if (x.Point < y.Point)
            {
                return 1;
            }

            if (x.Point > y.Point)
            {
                return -1;
            }

            return 0;
        }
    }
}
