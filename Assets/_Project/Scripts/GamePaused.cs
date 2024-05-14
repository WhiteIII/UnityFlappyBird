using UnityEngine;

namespace _Project
{
    public class GamePaused : MonoBehaviour
    {
        private PlayerKill _playerKill;

        private void Start()
        {
            _playerKill = PlayerKill.Instance;

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
