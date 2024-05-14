using UnityEngine;

namespace _Project
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _minRotationZ;
        [SerializeField] private float _maxRotationZ;
        [SerializeField] private float _rotationSpeed;

        private GameStart _gameStart;
        private Rigidbody2D _rigidbody;
        private Quaternion _maxRotation;
        private Quaternion _minRotation;

        private void Start()
        {
            _gameStart = GameStart.Instance;

            GetComponent<PlayerMovement>().enabled = false;

            _gameStart.GameStarted += WakeUp;

            _rigidbody = GetComponent<Rigidbody2D>();

            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        }

        private void OnDestroy()
        {
            _gameStart.GameStarted -= WakeUp;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _rigidbody.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Force);
                transform.rotation = _maxRotation;
                _rigidbody.velocity = Vector2.zero;
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }

        private void WakeUp()
        {
            GetComponent<PlayerMovement>().enabled = true;
        }
    }
}
