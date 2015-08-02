using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ElementToEnemy : MonoBehaviour {


	Vector3 Element1Pos;
	Vector3 Element2Pos;
	Vector3 Element3Pos;

	bool bEl1;
	bool bEl2;
	bool bEl3;

	bool bMovedElement1;
	bool bMovedElement2;
	bool bMovedElement3;
	


	// Use this for initialization
	void Start () {

		bMovedElement1 = false;
		bMovedElement2 = false;
		bMovedElement3 = false;
	
		bEl1 = GameValues.bElement1;
		bEl2 = GameValues.bElement2;
		bEl3 = GameValues.bElement3;

	}
	
	// Update is called once per frame
	void Update () {
	
		bEl1 = GameValues.bElement1;
		bEl2 = GameValues.bElement2;
		bEl3 = GameValues.bElement3;

		DeadEnemy ();

	}

	void DeadEnemy(){

		if(bEl1 && !bMovedElement1){
			Element1Pos = GameValues.Element1Vec;
			//print(Element1Pos);

			if(gameObject.name == "Element1"){
				gameObject.transform.position= new Vector3(Element1Pos.x,Element1Pos.y,Element1Pos.z);
			}
			bMovedElement1 = true;
		}

		if(bEl2 && !bMovedElement2){
			Element2Pos = GameValues.Element2Vec;
			//print(Element2Pos);

			if(gameObject.name == "Element2"){
				gameObject.transform.position= new Vector3(Element2Pos.x,Element2Pos.y,Element2Pos.z);
			}
			bMovedElement2 = true;

		}

		if(bEl3 && !bMovedElement3){
			Element3Pos = GameValues.Element3Vec;
			//print(Element3Pos);
			if(gameObject.name == "Element3"){																
				gameObject.transform.position= new Vector3(Element3Pos.x,Element3Pos.y,Element3Pos.z);
			}
			bMovedElement3 = true;
		}

	}
	
}
