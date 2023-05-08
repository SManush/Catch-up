using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 10;
    private float spawnPosZ = 20;
    private float startDaley = 2;
    private float spawnInterval = 5.5f;
    private float spawnRangeZ = 3;
    private float spawnPosXLeft = -28;
    private float spawnPosXRight = 28;

    



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDaley, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int animalIndexLeft = Random.Range(0, animalPrefabs.Length);
        int animalIndexRight = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Vector3 spawnPosLeft = new Vector3(spawnPosXLeft, 0, Random.Range(spawnRangeZ, -spawnRangeZ));
        Vector3 spawnPosRight = new Vector3(spawnPosXRight, 0, Random.Range(spawnRangeZ, -spawnRangeZ));
        Vector3 rotationLeft = new Vector3(0, 90, 0);
        Vector3 rotationRight = new Vector3(0, -90, 0);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        Instantiate(animalPrefabs[animalIndexLeft], spawnPosLeft, Quaternion.Euler(rotationLeft));
        Instantiate(animalPrefabs[animalIndexRight], spawnPosRight, Quaternion.Euler(rotationRight));
    }
}

