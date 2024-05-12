using UnityEngine;

namespace _Project
{
    public class PointDestinationArea : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out Player player) && collision.gameObject.activeInHierarchy)
            {
                collision.GetComponent<PlayersPoints>().AddPoint();
            }
        }
    }
}
