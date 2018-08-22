using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    private Rigidbody2D asteroidRigidbody;
    [SerializeField]
    private GameObject asteroidEffect;
    private float lifetime = 1;

    void Start()
    {
        asteroidRigidbody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("PlayerOne") || other.tag.Equals("PlayerTwo"))
        {
            PlayerController script = (PlayerController)GameObject.Find(other.tag).GetComponent(typeof(PlayerController));
            script.PlayerIsHurt(20);
            Instantiate (asteroidEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            DestroyEffect(asteroidEffect);
        }
    }

    void DestroyEffect(GameObject other)
	{
		lifetime -= Time.deltaTime;

		if(lifetime<0)
		{
			Destroy(gameObject);
		}
	}
}
