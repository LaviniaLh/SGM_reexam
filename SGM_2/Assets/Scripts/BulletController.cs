using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	
	[SerializeField]
	private float speed;
	private Rigidbody2D bulletRigidbody;
	[SerializeField]
	private string playerString;
	[SerializeField]
	GameObject bulletEffect;
	private float lifetime = 1;

	//public GameObject gemEffect;

	void Start () 
	{
		bulletRigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update () 
	{
        if (playerString.Equals("PlayerTwo"))
            bulletRigidbody.velocity = new Vector2(speed * transform.localScale.x, 0);
        else
            bulletRigidbody.velocity = new Vector2(-speed * transform.localScale.x, 0);
    }

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.tag == playerString)
        {
            PlayerController script = (PlayerController) GameObject.Find(playerString).GetComponent(typeof(PlayerController));
            script.PlayerIsHurt(5);
			Instantiate (bulletEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        if(other.tag.Equals("margin"))
        {
			var clone = Instantiate (bulletEffect, transform.position, transform.rotation);
			DestroyEffect(clone);
            gameObject.SetActive(false);
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
