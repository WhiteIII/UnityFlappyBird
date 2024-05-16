using UnityEngine;
using System;

namespace _Project
{
    public class GameStart : Singleton<GameStart>
    {
        public event Action GameStarted;

        protected override void Awake()
        { 
            base.Awake();
            Time.timeScale = 0f;
        }

        public void StartGame()
        {
            GameStarted?.Invoke();

            Time.timeScale = 1.0f;
        }
    }
}