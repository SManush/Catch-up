using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval;

    public GameObject dogPrefab;
    public bool dogFired = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

    // Update is called once per frame
    void Update()
    {
        // if the dog hasnt been fired
        if (!dogFired)
        {

            // if user presses space bar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // fire the pup!
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

                // set dog fired to true! 
                dogFired = true;

                // Run a method after 1 second that sets dogFired back to false
                Invoke("LimitDogCannon", 1f);
            }
        }
    }
    private void LimitDogCannon()
    {
        dogFired = false;
    }
    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        
        // Generate random ball index and random spawn position
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[0].transform.rotation);
        Invoke("SpawnRandomBall", Random.Range(3, 6));

    }

}
