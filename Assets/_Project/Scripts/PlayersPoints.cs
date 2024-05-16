using System;
using UnityEngine;

namespace _Project
{
    public class PlayersPoints : Singleton<PlayersPoints>
    {
        public int Points { get; private set; }

        public event Action OnPointsChanged;

        public void AddPoint()
        {
            Points++;
            OnPointsChanged?.Invoke();
        }
    }
}
