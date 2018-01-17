using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	void Update ()
	{
		if( Input.GetKeyDown(KeyCode.R) )
		{
			SceneManager.LoadScene( "12-6-2017");
		}
	}
}