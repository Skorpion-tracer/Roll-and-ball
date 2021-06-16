using UnityEngine;
using UnityEngine.UI;

namespace RollAndBall
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;

        public DisplayEndGame(Text finishGameLabel)
        {
            _finishGameLabel = finishGameLabel;
            _finishGameLabel.text = string.Empty;
        }

        public void GameOver(object o, CaughtPlayerEventArgs args)
        {
            _finishGameLabel.text = $"Конец Игры! Вас Убил {((BadBonus)o).name} {args.Color} цвета";
        }
    }
}