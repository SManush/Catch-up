using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    private float sideBound = 30;

    //create a reference to our GameManager script, gameManager - new variable
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //setup the reference to the new variable
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if an object goes past the players view in a game, remove that object
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        } 
        else if (transform.position.z < lowerBound) 
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else if (transform.position.x > sideBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else if (transform.position.x < -sideBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }

    }
}
