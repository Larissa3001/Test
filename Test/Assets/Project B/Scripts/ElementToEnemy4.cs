using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ElementToEnemy4 : MonoBehaviour {
	
	
	Vector3 Element1Pos4;
	Vector3 Element2Pos4;
	Vector3 Element3Pos4;
	Vector3 Element4Pos4;
	
	bool bEl14;
	bool bEl24;
	bool bEl34;
	bool bEl44;
	
	bool bMovedElement14;
	bool bMovedElement24;
	bool bMovedElement34;
	bool bMovedElement44;

	
	// Use this for initialization
	void Start () {
		
		bMovedElement14 = false;
		bMovedElement24 = false;
		bMovedElement34 = false;
		bMovedElement44 = false;
		
		bEl14 = GameValues.bElement14;
		bEl24 = GameValues.bElement24;
		bEl34 = GameValues.bElement34;
		bEl44 = GameValues.bElement44;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		bEl14 = GameValues.bElement14;
		bEl24 = GameValues.bElement24;
		bEl34 = GameValues.bElement34;
		bEl44 = GameValues.bElement44;
		
		DeadEnemy4 ();
		
	}
	
	void DeadEnemy4(){
		
		if(bEl14 && !bMovedElement14){
			Element1Pos4 = GameValues.Element14Vec;
			//print(Element1Pos);
			
			if(gameObject.name == "Element1"){
				gameObject.transform.position= new Vector3(Element1Pos4.x,Element1Pos4.y,Element1Pos4.z);
			}
			bMovedElement14 = true;
		}
		
		if(bEl24 && !bMovedElement24){
			Element2Pos4 = GameValues.Element24Vec;
			//print(Element2Pos);
			
			if(gameObject.name == "Element2"){
				gameObject.transform.position= new Vector3(Element2Pos4.x,Element2Pos4.y,Element2Pos4.z);
			}
			bMovedElement24 = true;
			
		}
		
		if(bEl34 && !bMovedElement34){
			Element3Pos4 = GameValues.Element34Vec;
			//print(Element3Pos);
			if(gameObject.name == "Element3"){																
				gameObject.transform.position= new Vector3(Element3Pos4.x,Element3Pos4.y,Element3Pos4.z);
			}
			bMovedElement34 = true;
		}
		if(bEl44 && !bMovedElement44){
			Element4Pos4 = GameValues.Element44Vec;
			//print(Element3Pos);
			if(gameObject.name == "Element4"){																
				gameObject.transform.position= new Vector3(Element4Pos4.x,Element4Pos4.y,Element4Pos4.z);
			}
			bMovedElement44 = true;
		}
		
	}
	
}
