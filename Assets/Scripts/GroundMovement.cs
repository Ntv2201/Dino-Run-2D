using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public GameObject groundPrefab;

    public float groundSpeed = 5f;
    private bool hasSpawnedGround = false;

    private void Update()
    {
        MovingGround();
        SpawnGround();
    }

    private void MovingGround()
    {
        transform.Translate(Vector3.left * groundSpeed * Time.deltaTime);
    }

    private void SpawnGround()
    {
        if(Vector3.Distance(new Vector3(-9f, 0f, 0), transform.position) < 0.2f && !hasSpawnedGround)
        {
            Instantiate(groundPrefab, new Vector3(-9f + 12, 0f, 0), Quaternion.identity);
            hasSpawnedGround = true; 
        }
        else if(Vector3.Distance(new Vector3(-28f, 0f, 0), transform.position) < 0.2f)
        {
            Destroy(gameObject);
        }
    }

}
