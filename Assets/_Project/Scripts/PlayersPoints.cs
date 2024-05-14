using System;
using UnityEngine;

namespace _Project
{
    public class PlayersPoints : MonoBehaviour
    {
        public static PlayersPoints Instance { get; private set; }

        public int Points { get; private set; }

        public event Action OnPointsChanged;

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
        }

        public void AddPoint()
        {
            Points++;
            OnPointsChanged?.Invoke();
        }
    }
}
