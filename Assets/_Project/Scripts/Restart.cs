using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project
{
    public class Restart : MonoBehaviour
    {
        [SerializeField] private PlayerKill _playerKill;

        private void Awake()
        {
            gameObject.SetActive(false);
            _playerKill.OnPlayerKilled += ButtonActive;
        }

        private void OnDestroy()
        {
            _playerKill.OnPlayerKilled -= ButtonActive;
        }

        private void ButtonActive()
        {
            gameObject.SetActive(true);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1.0f;
        }
    }
}
