using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPoolerOne : MonoBehaviour {
public static ObjPoolerOne objPooler1;
	public List<GameObject> bulletList1;
	public GameObject bulletToBePooled1;
	public int amountToPool1;

	void Awake() 
	{
		objPooler1 = this;
	}
	// Use this for initialization
	void Start () {
		bulletList1 = new List<GameObject>();

		for (int i = 0; i < amountToPool1; i++)
		{
			GameObject bullet1 = (GameObject) Instantiate (bulletToBePooled1);
			bullet1.SetActive(false);
			bulletList1.Add(bullet1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public GameObject GetPooledBullet() 
	{
		for (int i = 0; i < bulletList1.Count; i++)
		{
			if (!bulletList1[i].activeInHierarchy) 
			{
      			return bulletList1[i];
		    }
  		}
		return null;
	}

}
