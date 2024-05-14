using System;
using UnityEngine;

namespace _Project
{
    public class PlayerKill : MonoBehaviour
    {
        public static PlayerKill Instance { get; private set; }

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
