using UnityEngine;

namespace _Project
{
    public class ObstaclePositionRandomizer : MonoBehaviour
    {
        [SerializeField] private Transform _upperObstacle;
        [SerializeField] private float[] _upperObstacleRange = new float[2];
        [SerializeField] private Transform _lowerObstacle;
        [SerializeField] private float[] _lowerObstacleRange = new float[2];

        private void Start()
        {
            Randomize();
        }

        public void Randomize()
        {
            _upperObstacle.position = new Vector2(_upperObstacle.position.x,
                Random.Range(_upperObstacleRange[0], _upperObstacleRange[1]));
            _lowerObstacle.position = new Vector2(_lowerObstacle.position.x,
                Random.Range(_lowerObstacleRange[0], _lowerObstacleRange[1]));
        }
    }
}
