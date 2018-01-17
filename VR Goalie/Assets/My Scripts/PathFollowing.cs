using UnityEngine;
using System.Collections;

public class PathFollowing : MonoBehaviour {

	public SimplePath path;
	public float speed = 20.0f;
	public float mass = 5.0f;
	public bool isLooping = true;
	public AudioClip saw;

	public bool isBlocked = false;

	private float curSpeed; // Actual speed of the unit.
	private int curPathIndex;
	private float pathLength;
	private Vector3 targetPoint;
	private Vector3 velocity;

	void Start() {
		pathLength = path.Length;
		curPathIndex = 0;
		// Get the current velocity of the unit.
		velocity = transform.forward;
		GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = saw;
	}

	void Update() {
		if (!isBlocked) {
			curSpeed = speed * Time.deltaTime; // Unify the speed.
			targetPoint = path.GetPoint( curPathIndex );
			// If reach the radius within the path then move to next point in the path.
			if( Vector3.Distance( transform.position, targetPoint ) < path.Radius ) {
				// Don't move the unit if the path is completed.
				if( curPathIndex < ( pathLength - 1 ) ) { curPathIndex++; }
				else if( isLooping ) { curPathIndex = 0; }
				else { return; } }
			// Move the unit until the end point is reached in the path.
			if( curPathIndex >= pathLength ) { return; }
			// Calculate the next Velocity towards the path.
			if( ( curPathIndex >= ( pathLength - 1 ) ) && !isLooping ) { 
				velocity += Steer( targetPoint, true ); }
			else { velocity += Steer( targetPoint ); }
			transform.position += velocity; // Move the unit according to the velocity.
			transform.rotation = Quaternion.LookRotation( velocity ); // Rotate the vehicle towards the desired Velocity.
		}
	}

	// Steering algorithm to steer the vector towards the target.
	public Vector3 Steer( Vector3 target, bool bFinalPoint = false ) {
		// Calculate the directional vector from the current position towards the target point.
		Vector3 desiredVelocity = target - transform.position;
		float dist = desiredVelocity.magnitude;
		// Normalise the desired Velocity.
		desiredVelocity.Normalize();
		// Calculate the velocity according to the speed.
		if( bFinalPoint && ( dist < 10.0f ) ) { 
			desiredVelocity *= curSpeed * ( dist / 10.0f ); }
		else { desiredVelocity *= curSpeed; }
		// Calculate the force Vector.
		Vector3 steeringForce = desiredVelocity - velocity;
		Vector3 acceleration = steeringForce / mass;
		return acceleration;
	}

	void OnCollisionEnter( Collision col ) {
		if (!isBlocked) {
			if (col.gameObject.name.Equals ("Glove Left") ||
				col.gameObject.name.Equals ("Glove Right")) {
				GetComponent<AudioSource> ().Play ();
				isBlocked = true;
				Debug.Log ("Collided");
				Rigidbody rb = GetComponent<Rigidbody> ();
				rb.useGravity = true;
				rb.AddForce (col.contacts [0].normal * 200.0F);
				GameManager.score += 100;


			
			}
		}
	}

}