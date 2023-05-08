using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;

    public float zRangeMinZ;
    public float zRangeMaxZ;

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.z < zRangeMinZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMinZ);
        }
        if (transform.position.z > zRangeMaxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMaxZ);
        }
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a projectile from the player
            //new method - Instantiate() (кот. говорит,  что мы будем созд. нов. объект из уже имеющихся)
            //position where it should start, rotation what it should be when you create that
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
        }
    }
}
