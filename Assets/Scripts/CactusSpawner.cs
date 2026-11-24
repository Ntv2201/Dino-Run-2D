using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cactusA;
    [SerializeField] private GameObject cactusB;
    [SerializeField] private GameObject cactusC;

    [SerializeField] private float minTimeBetweenSpawn;
    [SerializeField] private float maxTimeBetweenSpawn;

    private void Start()
    {
        SpawnCactus();
    }

    private void SpawnCactus()
    {
        Instantiate(ChooseRandomCactus(), transform.position, Quaternion.identity);
        Invoke("SpawnCactus", Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn));
    }

    private GameObject ChooseRandomCactus()
    {
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0: return cactusA;
            case 1: return cactusB;
            case 2: return cactusC;
        }
        return cactusA;
    }

}
