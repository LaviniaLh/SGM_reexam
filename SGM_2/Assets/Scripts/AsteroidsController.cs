using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsController : MonoBehaviour {

    [SerializeField]
    private GameObject[] asteroids;

    private float timeSinceLastAsteroid = 0f;
    [SerializeField]
    private float timeBetweenAsteroids;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()  
    {
        timeSinceLastAsteroid += Time.deltaTime;

        if (timeSinceLastAsteroid >= timeBetweenAsteroids)
        {
            timeSinceLastAsteroid -= timeBetweenAsteroids;
            AsteroidsFalling();
        }

    }

    void AsteroidsFalling()
    {
        float whereToFall = Random.Range(-7.9f, 7.85f);

        GameObject currentAsteroid = asteroids[Random.Range(0, 4)];

        Vector3 position = new Vector3(whereToFall, transform.position.y);

        GameObject clone = Instantiate(currentAsteroid, position, Quaternion.identity);
        Destroy(clone, 3f);
    }

    
}
