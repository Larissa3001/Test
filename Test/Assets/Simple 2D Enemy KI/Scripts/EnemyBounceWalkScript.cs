using UnityEngine;
using System.Collections;

/*
 * See Scene:
 * 
 * 4 EnemyBouncing
 * 
 * You find the EnemyBounceWalkScript as an Enemy-Component
 */
public class EnemyBounceWalkScript : MonoBehaviour {
	
	public float Speed = 0.05f;
	
	private Vector3 direction1;
	private Vector3 direction2;

	private bool top;
	private bool bottom;
	private bool front;

	private float horizontalPositionOld = 0.0f;

	private BounceTarget lastDirection;

	[HideInInspector]
	public bool facingRight = true;
	private Vector3 lastPosition;

	//added
	bool EnemyDie = false;
	

	void Awake(){

		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer (EnemyAWConst.ENEMY), LayerMask.NameToLayer (EnemyAWConst.ENEMY), true);

		// Random direction on start
		switch(Random.Range (0, 3)){
			case 0:
				top = true;
				lastDirection = BounceTarget.TOP;
				break;
			case 1:
				bottom = true;
				lastDirection = BounceTarget.BOTTOM;
				break;
			case 2:
				front = true;
				lastDirection = BounceTarget.FRONT;
				break;
		}
	}

	void Start() {
		//added
		EnemyDie = false;
	}

	void Update(){

		
		if(EnemyDie){
			Destroy(gameObject);
		}
	
		// Change movement if one of the following is true
		if (top || bottom || front) {
			nextMovement ();
			lastPosition = transform.position;
		}
	}


	void FixedUpdate () {

		// Save horizontal position for flip-check
		horizontalPositionOld = transform.position.x;

		// Move diagonal 45°
		transform.Translate( Quaternion.Euler (0, 45, 0) * direction1, Space.World);
		transform.Translate( Quaternion.Euler (0, 45, 0) * direction2, Space.World);

		if(transform.position.x < horizontalPositionOld){

			if(facingRight){
				Flip ();
				facingRight = false;				
			}
		} else {
			if(!facingRight){
				Flip ();
				facingRight = true;
			}
		}
	}

	private void nextMovement(){

		if(top){
			if(facingRight){
				direction1 = Vector3.right * Speed;
				direction2 = Vector3.down * Speed;
			} else {
				direction1 = Vector3.left * Speed;
				direction2 = Vector3.down * Speed;
			}

			lastDirection = BounceTarget.TOP;
			top = false;
		} else

		if (bottom) {

			if(facingRight){
				direction1 = Vector3.right * Speed;
				direction2 = Vector3.up * Speed;
			} else {
				direction1 = Vector3.left * Speed;
				direction2 = Vector3.up * Speed;
			}

			lastDirection = BounceTarget.BOTTOM;
			bottom = false;


		} else

		if (front) {

			if(facingRight){

				if(lastDirection == BounceTarget.TOP){
					direction1 = Vector3.left * Speed;
					direction2 = Vector3.down * Speed;
				} else if(lastDirection == BounceTarget.BOTTOM){
					direction1 = Vector3.left * Speed;
					direction2 = Vector3.up * Speed;
				} else if(lastDirection == BounceTarget.FRONT){

					if(lastPosition.y > transform.position.y){
						direction1 = Vector3.left * Speed;
						direction2 = Vector3.down * Speed;

					} else {
						direction1 = Vector3.left * Speed;
						direction2 = Vector3.up * Speed;
					}
				}

			} else {

				if(lastDirection == BounceTarget.TOP){
					direction1 = Vector3.right * Speed;
					direction2 = Vector3.down * Speed;
				} else if(lastDirection == BounceTarget.BOTTOM){
					direction1 = Vector3.right * Speed;
					direction2 = Vector3.up * Speed;
				} else if(lastDirection == BounceTarget.FRONT){
					
					if(lastPosition.y > transform.position.y){
						direction1 = Vector3.right * Speed;
						direction2 = Vector3.down * Speed;						
					} else {
						direction1 = Vector3.right * Speed;
						direction2 = Vector3.up * Speed;
					}
				}
			}

			lastDirection = BounceTarget.FRONT;
			front = false;
		}
	}

	// Call from BounceTigger-Script
	public void Bounce(bool t, bool b, bool f){

		// Processing in the update- and nextMovement-method
		top = t;
		bottom = b;
		front= f;
	}

	void Flip(){
		
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private void OnTriggerEnter2D(Collider2D col){

		//added
		if (col.gameObject.tag.Equals (EnemyAWConst.SHOOTSTAR)) { 
			EnemyDie = true;
			Destroy(col.gameObject);
			print ("dieeeeeeeeeeeeeee");
		}
	}

	public enum BounceTarget { 

		TOP, 
		BOTTOM, 
		FRONT 
	};
}
