using UnityEngine;
using UnityEngine.UI;

namespace RollAndBall
{
    public sealed class DisplayBonuses
    {
        private Text _textToWin;
        private Text _textScore;

        public DisplayBonuses(GameObject score, GameObject win)
        {
            _textToWin = win.GetComponent<Text>();
            _textToWin.text = string.Empty;
            _textScore = score.GetComponent<Text>();
            _textScore.text = string.Empty;
        }

        public void Display(int value)
        {
            _textScore.text = $"Вы набрали {value}";
        }

        public void DisplayToWin()
        {
            _textToWin.text = "Вы Победили!!!";
        }
    }
}
