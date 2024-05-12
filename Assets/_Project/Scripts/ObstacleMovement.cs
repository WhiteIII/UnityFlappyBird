using UnityEngine;

namespace _Project
{
    public class ObstacleMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.Translate(new Vector2(1, 0) * _speed * Time.deltaTime);
        }
    }
}
