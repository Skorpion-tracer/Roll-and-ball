using Helper;
using RollAndBall.Model;
using UnityEngine;
using UnityEngine.UI;

namespace RollAndBall
{
    public class Reference
    {
        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private Animator _animator;
        private GameObject _score;
        private GameObject _endGame;
        private GameObject _win;
        private Canvas _canvas;
        private Button _restartButton;

        public PlayerBall PlayerBall
        {
            get {
                if (_playerBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>(ResourcesConst.PLAYER_BALL);
                    _playerBall = Object.Instantiate(gameObject);
                }

                return _playerBall;
            }
        }

        public Camera MainCamera
        {
            get {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }

        public Animator Animator
        {
            get {
                if (_animator == null)
                {
                    if (Camera.main.TryGetComponent<Animator>(out Animator animator))
                    {
                        _animator = animator;
                    }
                }
                return _animator;
            }
        }

        public Canvas Canvas
        {
            get {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public GameObject Score
        {
            get {
                if (_score == null)
                {
                    var gameObject = Resources.Load<GameObject>(ResourcesConst.SCORE_PLAYER);
                    _score = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _score;
            }
        }

        public GameObject EndGame
        {
            get {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>(ResourcesConst.END_GAME);
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _endGame;
            }
        }

        public GameObject Win
        {
            get {
                if (_win == null)
                {
                    var gameObject = Resources.Load<GameObject>(ResourcesConst.WIN_GAME);
                    _win = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _win;
            }
        }

        public Button RestartButton
        {
            get {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>(ResourcesConst.RESTART_BUTTON);
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _restartButton;
            }
        }
    }
}
