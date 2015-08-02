﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
* See Scene:
* 
* 5 EnemyWaypoints
* 
* You find the EnemyWaypointWalker Script as a Enemy-Component (Prefab)
*/
public class EnemyWaypointWalker : MonoBehaviour {

	public List<GameObject> WaypointPositions;
	public float speed = 1;

	private int currentWaypoint = 0;
	
	private Vector3 targetPositionDelta;
	private Vector3 moveDirection = Vector3.zero;

	private float horizontalPositionOld;
	private bool facingRight = true;
	
	void FixedUpdate () {

		// Save actual position for flip-check
		horizontalPositionOld = transform.position.x;

		WaypointWalk ();
		Move ();
			
		// Flip-Check
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
	
	void WaypointWalk() {

		if (WaypointPositions.Count > 0) {

			GameObject wp = (GameObject) WaypointPositions [currentWaypoint];
			Vector3 targetPosition = wp.transform.position;

			targetPositionDelta = targetPosition - transform.position;

			// if i´m near the next waypoint count one high
			if (targetPositionDelta.sqrMagnitude <= 0.01f) {

				currentWaypoint++;
				
				// If the last waypoint reached, start again
				if (currentWaypoint >= WaypointPositions.Count) {
					currentWaypoint = 0;
				}
			}
		}
	}

	protected virtual void Move(){
		moveDirection = targetPositionDelta.normalized * speed;
		transform.Translate (moveDirection * Time.deltaTime, Space.World);
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
