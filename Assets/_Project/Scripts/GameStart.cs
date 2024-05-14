using UnityEngine;
using System;

namespace _Project
{
    public class GameStart : MonoBehaviour
    {
        public static GameStart Instance { get; private set; }

        public event Action GameStarted;

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            Time.timeScale = 0f;
        }

        public void StartGame()
        {
            GameStarted?.Invoke();

            Time.timeScale = 1.0f;
        }
    }
}