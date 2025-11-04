using System.Threading;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject[] pipePrefabs;   // ✅ Birden fazla prefab tutmak için dizi
    public float spawnRate = 2f;
    private float timer = 0f;
    public float heightOffset = 10f;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // ✅ Rastgele prefab seç
        int randomIndex = Random.Range(0, pipePrefabs.Length);
        GameObject selectedPipe = pipePrefabs[randomIndex];

        // ✅ Rastgele yükseklikte spawn et
        Instantiate(
            selectedPipe,
            new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0),
            transform.rotation
        );
    }
}
