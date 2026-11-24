using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private void Start()
    {
        Invoke("DestroyAfterTimes", 7);
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void DestroyAfterTimes()
    {
        Destroy(gameObject);
    }
}
