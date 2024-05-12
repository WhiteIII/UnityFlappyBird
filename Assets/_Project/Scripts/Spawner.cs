using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace _Project
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _obstacle;
        [SerializeField] private GameObject _startPoint;
        [SerializeField] private float _repeatRate = 1f;
        [SerializeField] private int _poolCapacity = 5;
        [SerializeField] private int _poolMaxSize = 5;

        private ObjectPool<GameObject> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(_obstacle),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
        }

        private void ActionOnGet(GameObject obj)
        {
            obj.transform.position = _startPoint.transform.position;
            obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            obj.SetActive(true);
        }

        private void Start()
        {
            StartCoroutine(SpawnObstacle());
        }

        private void GetObstacle()
        {
            _pool.Get();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _pool.Release(other.gameObject);
        }

        private IEnumerator SpawnObstacle()
        {
            while (gameObject.activeInHierarchy)
            {
                GetObstacle();

                yield return new WaitForSeconds(_repeatRate);
            }
        }
    }
}
