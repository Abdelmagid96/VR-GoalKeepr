using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public Canvas menucanvas;
	public Canvas maincanvas;

	// Use this for initialization
	void Start () {
		if (menucanvas != null)
		{
			menucanvas.enabled = false;
		}
	}

	public void Pause(){
		// Oculus Touch primary button (A) pressed.
		if( OVRInput.GetDown(OVRInput.Button.One) )
		{
			
			if (menucanvas != null)
			{
				menucanvas.enabled = true;
			}
			maincanvas.enabled = false;
			Time.timeScale = 0;
		}
	}
	public void Resume(){
		if (menucanvas != null)
		{
			menucanvas.enabled = false;
		}
		maincanvas.enabled = true;
		Time.timeScale = 1;
		
	}
	public void Quit(){
		Application.Quit();
	}
	public void Restart(){
		
		SceneManager.LoadScene( "Gameplay" );
		GameManager.score = 0;
		Time.timeScale = 1;

	
	}


}
