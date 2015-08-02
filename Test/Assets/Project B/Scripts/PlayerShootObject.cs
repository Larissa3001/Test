using UnityEngine;
using System.Collections;

public class PlayerShootObject : MonoBehaviour {
	
	[HideInInspector]
	public bool Right = false;
	[HideInInspector]
	public bool Left = false;

	
	public float maxSpeed = 10.0f;
	
	void FixedUpdate () {
		
		if (Right) {
			transform.Translate (Vector3.right * Time.deltaTime * maxSpeed);
		} else if (Left) {
			transform.Translate (Vector3.left * Time.deltaTime * maxSpeed);
		}

		if (transform.position.x > 10 || transform.position.x < -10) {
			Destroy(gameObject);
		}
	}

}