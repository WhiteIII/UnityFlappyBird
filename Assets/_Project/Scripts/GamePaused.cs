using UnityEngine;

namespace _Project
{
    public class GamePaused : MonoBehaviour
    {
        [SerializeField] private PlayerKill _playerKill;

        private void Awake()
        {
            _playerKill.OnPlayerKilled += Pause;
        }

        private void OnDestroy()
        {
            _playerKill.OnPlayerKilled -= Pause;
        }

        private void Pause()
        {
            Time.timeScale = 0;
        }
    }
}
