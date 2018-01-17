using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to control the camera via keyboard (arrow keys).
public class CameraControl : MonoBehaviour {

	[ Tooltip( "Velocity of the camera in meters per second limited to [ 0.1, 10 ]." ) ]
	[ Range( 0.1F, 10.0F ) ]
	public float velocity = 0.1F; // Velocity of the camera [m/sec];

	// Update is called once per frame.
	void Update () {

		Vector3 currCamPos = transform.position; // Get current camera position.

		// Track keyboard arrow keys, and update the current camera position.
		if( Input.GetKey( KeyCode.LeftArrow ) ) { currCamPos.x -= Time.deltaTime * velocity; }
		if( Input.GetKey( KeyCode.RightArrow ) ) { currCamPos.x += Time.deltaTime * velocity; }
		if( Input.GetKey( KeyCode.UpArrow ) ) { currCamPos.y += Time.deltaTime * velocity; }
		if( Input.GetKey( KeyCode.DownArrow ) ) { currCamPos.y -= Time.deltaTime * velocity; }

		transform.position = currCamPos; // Update camera position.

	}

}