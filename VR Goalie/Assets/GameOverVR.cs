using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverVR : MonoBehaviour {

	public Canvas maincanvas;
		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {
			
			if (OVRInput.GetDown (OVRInput.Button.Three))
			{
				// Oculus Touch primary button (A) pressed.
				SceneManager.LoadScene ("GamePlay");
				GameManager.score = 0;
			}
			else if(OVRInput.GetDown (OVRInput.Button.Start)){
				Application.Quit();
			}

		}

	}



