using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace RollAndBall
{
    public sealed class BonusToWin : InteractiveObject, IFlicker
    {
        private Material _material;
        private ListInteractableObject<BonusToWin> _listBonus;
        private DisplayBonuses _displayBonuses;

        private void Awake()
        {
            _listBonus = new ListInteractableObject<BonusToWin>();
            _material = GetComponent<Renderer>().material;
            _displayBonuses = FindObjectOfType<DisplayBonuses>();
        }

        protected override void Interaction()
        {            
            if (_listBonus.MoveNext() == true)
            {
                Log($"Объект: {_listBonus.Current}");
                return;
            }
            else
            {
                _displayBonuses.DisplayToWin();
            }
        }

        public void Flicker()
        {
            _material.color = Color.green;
        }
    }
}
