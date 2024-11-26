using UnityEngine;

namespace IRV.Scripts
{
    public class ObjectSpawner : MonoBehaviour
    {
        public void spawnObject(GameObject gameObject)
        {
            Instantiate(gameObject, transform.position, Quaternion.identity);
        }
    }
}