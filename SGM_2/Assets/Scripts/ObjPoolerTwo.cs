using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPoolerTwo : MonoBehaviour {
public static ObjPoolerTwo objPooler2;
	public List<GameObject> bulletList2;
	public GameObject bulletToBePooled2;
	public int amountToPool2;

	void Awake() 
	{
		objPooler2 = this;
	}
	// Use this for initialization
	void Start () {
		bulletList2 = new List<GameObject>();

		for (int i = 0; i < amountToPool2; i++)
		{
			GameObject bullet2 = (GameObject) Instantiate (bulletToBePooled2);
			bullet2.SetActive(false);
			bulletList2.Add(bullet2);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public GameObject GetPooledBullet() 
	{
		for (int i = 0; i < bulletList2.Count; i++)
		{
			if (!bulletList2[i].activeInHierarchy) 
			{
      			return bulletList2[i];
		    }
  		}
		return null;
	}

}
