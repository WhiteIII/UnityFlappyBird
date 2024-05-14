using TMPro;
using UnityEngine;

namespace _Project
{
    public class DisplayNumberOfPointsOnScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _score;
        [SerializeField] private TMP_Text _finalScore;

        private GameStart _gameStart;
        private PlayersPoints _playersPoints;

        private void Start()
        {
            _gameStart = GameStart.Instance;
            _playersPoints = PlayersPoints.Instance;

            gameObject.SetActive(false);

            _score.text = _playersPoints.Points.ToString();

            _gameStart.GameStarted += WakeUp;
            _playersPoints.OnPointsChanged += DisplayPoints;
        }

        private void OnDestroy()
        {
            _playersPoints.OnPointsChanged -= DisplayPoints;
            _gameStart.GameStarted -= WakeUp;
        }

        private void DisplayPoints()
        {
            _score.text = _playersPoints.Points.ToString();
            _finalScore.text = _score.text;
        }

        private void WakeUp()
        {
            gameObject.SetActive(true);
        }
    }
}
