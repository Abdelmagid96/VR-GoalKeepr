using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shot manager.
//  - generate a soccer ball at runtime;
//  - select a trajectory for current ball;
//  - set the soccer ball to follow the selected trajectory.
public class ShotManager : MonoBehaviour {

	public float shotPower = 1000.0F; // Newtons.

	public float shotDelay = 1.0F; // Seconds.

	public GameObject soccerBallPrefab = null; // Reference variable to the soccer ball prefab.

	public Transform spawnLocation = null; // Reference variable to the Transform component of the spawn location.

	public SimplePath[] paths;

	private int pathIndex = 0;

	private int score=0;


	// Automatic generation of soccer balls using frequency.
	IEnumerator AutoSoccerBallGen()
	{
		// Infinite loop.
		while(true) {

			// Reference variable to a soccer ball clone.
			GameObject soccerBallClone = null;
			// Create a soccer ball clone at runtime (spawning).
			soccerBallClone = Instantiate (soccerBallPrefab, spawnLocation.position, transform.rotation);

			soccerBallClone.GetComponent<PathFollowing> ().path = paths [pathIndex];

			pathIndex = (pathIndex + 1) % paths.Length; 

			// Extract the reference to the Rigidbody component of the clone, and apply a force to it.
			//Rigidbody soccerBallRigidbody = soccerBallClone.GetComponent<Rigidbody> ();
			//soccerBallRigidbody.AddForce (Vector3.forward * shotPower); // WARNING: force vector wrong!

			// Suspend execution for "shotDelay" seconds.
			yield return new WaitForSeconds(shotDelay);
		}

	}

	// Use this for initialization.
	IEnumerator Start () {
		yield return StartCoroutine("AutoSoccerBallGen");
	}


}


