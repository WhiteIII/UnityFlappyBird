using System;
using UnityEngine;

namespace _Project
{
    public class PlayerKill : Singleton<PlayerKill>
    {
        public event Action OnPlayerKilled;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Obstacle>(out Obstacle obstacle))
            {
                GetComponent<PlayerMovement>().enabled = false;
                OnPlayerKilled?.Invoke();
            }
        }
    }
}
