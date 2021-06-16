using UnityEngine;
using UnityEngine.UI;

namespace RollAndBall
{
    public sealed class DisplayBonuses : MonoBehaviour
    {
        [SerializeField] private Text _textToWin;
        [SerializeField] private Text _text;
        [SerializeField] private Text _textGameOver;

        public void Display(int value)
        {
            _text.text = $"Вы набрали {value}";
        }

        public void DisplayToWin()
        {
            _textToWin.text = "Вы Победили!!!";
        }

        public void DisplayToGameOver()
        {
            _textGameOver.text = $"Конец Игры!";
        }
    }
}
