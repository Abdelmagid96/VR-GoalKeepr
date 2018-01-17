using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to control the cannon firing.
public class CannonControl : MonoBehaviour {

	public GameObject cannonBallPrefab = null; // Reference variable to the cannon ball prefab.

	public Transform spawnLocation = null; // Reference variable to the Transform component of the spawn location.

	public float Power =1500.0F;

	// Update is called once per frame.
	void Update () {

		// Control cannon firing with keyboard space key.
		if( Input.GetKeyDown( KeyCode.Space ) ) { 

			// Reference variable to a cannon ball clone.
			GameObject cannonBallClone = null;
			// Create a cannon ball clone at runtime (spawning).
			cannonBallClone = Instantiate (cannonBallPrefab, spawnLocation.position, transform.rotation);

			// Extract the reference to the Rigidbody component of the clone, and apply a force to it.
			Rigidbody cannonBallRigidbody = cannonBallClone.GetComponent<Rigidbody> ();
			cannonBallRigidbody.AddForce (spawnLocation.forward * Power); // WARNING: force vector wrong!

		}

	}
}

