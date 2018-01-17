using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to schedule the destruction of the GameObject this script is attached to.
public class CannonballSelfDestruct : MonoBehaviour {

	public float timeDelay = 3.0F; // Time delay for self-destruction [secs].

	// Use this for initialization.
	void Start () {

		Destroy( gameObject, timeDelay ); // Schedule self-destruction.

	}

}