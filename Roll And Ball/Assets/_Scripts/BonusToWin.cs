using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollAndBall
{
    public sealed class BonusToWin : InteractiveObject, IFlicker
    {
        private ListInteractableObject<BonusToWin> _listBonus;

        private static int _countBonuses;

        protected override void Awake()
        {
            base.Awake();
            _countBonuses = 0;
            _listBonus = new ListInteractableObject<BonusToWin>();
        }

        public event Action OnDisplayBonus;
        public event Action<object, CaughtPlayerEventArgs> OnWin;

        protected override void Interaction()
        {
            _countBonuses++;
            if (_countBonuses >= 3)
            {
                OnWin?.Invoke(this, new CaughtPlayerEventArgs(_color));
                OnDisplayBonus?.Invoke();
            }
        }

        public override void Execute()
        {
            if (!IsInteractable)
            {
                return;
            }
            Flicker();
        }

        public void Flicker()
        {
            _material.color = Color.green;
        }
    }
}
