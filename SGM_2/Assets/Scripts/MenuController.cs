using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour 
{
	[SerializeField]
	private string start;
	[SerializeField]
	private string instructions;

	public void ChooseStart()
	{
		SceneManager.LoadScene(start);
	}

	public void ChooseInstructions()
	{
		SceneManager.LoadScene(instructions);
	}

	public void ChooseQuit()
	{
		Application.Quit();
	}

}
