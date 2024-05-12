using UnityEngine;
using System;

namespace _Project
{
    public class GameStart : MonoBehaviour
    {
        public event Action GameStarted;

        private void Awake()
        {
            Time.timeScale = 0f;
        }

        public void StartGame()
        {
            GameStarted?.Invoke();

            Time.timeScale = 1.0f;
        }
    }
}