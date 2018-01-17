using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyClock : MonoBehaviour
{
	public int  Minutes = 1;
	public int  Seconds = 0;
	public Text    m_text;
	private float   m_leftTime;

	private void Awake()
	{
		m_leftTime = GetInitialTime();
	}

	private void Update()
	{
		if (m_leftTime > 0f) {
			//  Update countdown clock
			m_leftTime -= Time.deltaTime;
			Minutes = GetLeftMinutes ();
			Seconds = GetLeftSeconds ();

			//  Show current clock
			if (m_leftTime > 0f) {
				m_text.text = ("Time:" + Minutes + ":" + Seconds.ToString ("00"));
			} else {
				//  The countdown clock has finished
				m_text.text = "Time : 0:00";
				SceneManager.LoadScene ("GameOver");
			}
		} 
		else {
			//  The countdown clock has finished
			m_text.text = "Time : 0:00";
			SceneManager.LoadScene ("/Users/abdelmagidsiddig/Desktop/VR Project 2/VR Goalie/Assets/GameOver.unity");
		}

	}

	private float GetInitialTime()
	{
		return Minutes * 60f + Seconds;
	}

	private int GetLeftMinutes()
	{
		return Mathf.FloorToInt(m_leftTime / 60f);
	}

	private int GetLeftSeconds()
	{
		return Mathf.FloorToInt(m_leftTime % 60f);
	}

}