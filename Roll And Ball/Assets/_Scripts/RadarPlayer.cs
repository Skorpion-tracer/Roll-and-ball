using UnityEngine;
using UnityEngine.UI;

namespace RollAndBall
{
    public sealed class RadarPlayer : MonoBehaviour
    {
        [SerializeField] private Image _ico;
        private void OnValidate()
        {
            _ico = Resources.Load<Image>("MiniMap/Player");
        }

        private void OnDisable()
        {
            Radar.RemoveRadarObject(gameObject);
        }

        private void OnEnable()
        {
            Radar.RegisterRadarObject(gameObject, _ico);
        }

    }
}