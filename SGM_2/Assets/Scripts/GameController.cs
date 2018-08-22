using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	private GameObject[] elementsInPauseMode;
	void Start () 
	{
	
	}
	
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.M))
		{
			SceneManager.LoadScene("Menu");
		}

		if(Input.GetKeyDown(KeyCode.P))
		{
			foreach (var item in elementsInPauseMode)
			{
				item.SetActive(true);
			}
		}
	}

	public void RestartGame()
	{
		SceneManager.LoadScene("StarterScene");
	
		foreach(var item in elementsInPauseMode)
		{
			item.SetActive(false);
		}
	}
		
	public void GoToMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	
}
