


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OVRGUIController : MonoBehaviour {


	public Canvas maincanvas;
	public Canvas menucanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.GetDown (OVRInput.Button.One))
		{

			menucanvas.enabled = true;
			maincanvas.enabled = false;
			Time.timeScale = 0;
		} 
		if (OVRInput.GetDown (OVRInput.Button.Two)){
			if (menucanvas.enabled == true)
			{
				menucanvas.enabled = false;
				maincanvas.enabled = true;
				Time.timeScale = 1;
			}
		}
		if (OVRInput.GetDown (OVRInput.Button.Three))
		{
			if (menucanvas.enabled == true){
			// Oculus Touch primary button (A) pressed.
			SceneManager.LoadScene ("Gameplay");
			GameManager.score = 0;
			Time.timeScale = 1;
			}
		}
		else if(OVRInput.GetDown (OVRInput.Button.Start)){
			Application.Quit();
		}

	}

}



