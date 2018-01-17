using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text FinalScore;
	public Text Highscore;


	private int highscore=0;
	private int finalscore=0;

	// Use this for initialization
	void Start () {

		highscore = GameManager.highScore;
		finalscore = GameManager.score;
		
	}
	
	// Update is called once per frame
	void Update () {
		 
		Highscore.text = "High Score: " + PlayerPrefs.GetInt("High Score: ").ToString();
		FinalScore.text = "Final Score:" + finalscore.ToString ();
		
	}
}
