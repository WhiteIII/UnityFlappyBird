using TMPro;
using UnityEngine;

namespace _Project
{
    public class DisplayNumberOfPointsOnScreen : MonoBehaviour
    {
        [SerializeField] private GameStart _gameStart;
        [SerializeField] private PlayersPoints _playersPoints;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private TMP_Text _finalScore;

        private void Awake()
        {
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
