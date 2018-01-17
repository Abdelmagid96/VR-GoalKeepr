using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Text uiScoreText;
	public Text uiHighScoreText;
	public static int score = 0;
	public static int highScore=0;



	// Use this for initialization
	void Start () {
		uiScoreText.text="Score:0";
		uiHighScoreText.text = "High Score: " + PlayerPrefs.GetInt ("High Score: ", 0).ToString ();

	}
	
	// Update is called once per frame
	void Update () {
		uiScoreText.text = "Score:" + score.ToString ();
		uiHighScoreText.text ="High Score: " + PlayerPrefs.GetInt ("High Score: ", 0).ToString ();


		if(score>PlayerPrefs.GetInt("High Score: ",0)){
			PlayerPrefs.SetInt("High Score: ",score);
			highScore = score;
		}
	}
}


