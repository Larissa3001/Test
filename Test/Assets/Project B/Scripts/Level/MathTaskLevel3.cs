using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MathTaskLevel3 : MonoBehaviour {
	
	string MathTaskStr3;
	
	bool bEL2TF3;
	bool bEL1TF3;
	bool bEL3TF3;
	
	bool bMathTask3;
	bool bComplete3;
	bool bFail3;
	bool bShow3;
	
	public Dictionary <Texture2D,bool> MTask3 = new Dictionary <Texture2D,bool>();
	
	private bool toggle13 = false;
	private bool toggle23 = false;
	private bool toggle33 = false;
	
	Texture2D iconel13;
	Texture2D iconel23;
	Texture2D iconel33;
	
	bool boolElement23;
	bool boolElement33;
	bool boolElement13;
	
	int pickedElements;

	bool bstart;
	
	
	public static bool changeCurrentToNext3;
	
	
	
	// Use this for initialization
	void Start () {

		bstart = true;
		
		bShow3 = true;
		
		pickedElements = 0;
		
		changeCurrentToNext3 = false;
		
		bMathTask3 = false;
		
		bComplete3 = false;
		bFail3 = false; 
		
		SetMathTask3 ();

		
	}
	
	// Update is called once per frame
	void Update () {

		if(bstart){
		iconel13 = Element1.Element1Icon;			
		iconel23 = Element2.Element2Icon;
		iconel33 = Element3.Element3Icon;
		
		MTask3.Add(iconel13,bEL1TF3);
		MTask3.Add(iconel23,bEL2TF3);
		MTask3.Add(iconel33,bEL3TF3);

			bstart = false;
		}

		pickedElements = GameValues.pickedEle;
		
		if(GameValues.bAllEnemiesDead &&  pickedElements == 3){
			bMathTask3 = true;
		}
	}
	
	
	void SetMathTask3() {
		
		MathTaskStr3 = "Welche Elemente gehören zur Menge: A = {Farben die Orange mischen} ?";
		
		bEL2TF3 = false;
		bEL1TF3 = true;
		bEL3TF3 = true;
		
	}
	
	
	void OnGUI(){
		
		if (bMathTask3 && bShow3) {
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "");
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "MathTask");
			
			GUI.Label (new Rect (100,100, 400, 400), MathTaskStr3);
			
			
			toggle13 = GUI.Toggle (new Rect (50, 175, 100, 50), toggle13, iconel13, "button");
			toggle23 = GUI.Toggle (new Rect (250, 175, 100, 50), toggle23, iconel23, "button");
			toggle33 = GUI.Toggle (new Rect (450, 175, 100, 50), toggle33, iconel33, "button");
			
			
			
			/*if (GUI.Button (new Rect (50,175, 100, 50), iconp)) {
						print ("you clicked the icon1");
					}
							
					if (GUI.Button (new Rect (250,175, 100, 50), iconb)) {
						print ("you clicked the icon2");
					}

					if (GUI.Button (new Rect (450,175, 100, 50), icony)) {
						print ("you clicked the icon3");
					}*/
			
			if (GUI.Button (new Rect (225, Screen.height / 2 + 100, 150, 25), "Accept")) {
				GetBooleans2();
				TestIfMathTaskIsRight2 ();
				bShow3 = false;
			}
		}
		
		
		
		if (bComplete3) {
			GUI.Box (new Rect (100, 125, 400, 200), "");
			GUI.Box (new Rect (100, 125, 400, 200), "");
			
			GUI.Label (new Rect (175, 150, 400, 400), "Geschafft!" );
			
			if (GUI.Button (new Rect (175, 200, 100, 50), "next Level!")) {
				PlayerPrefs.SetInt(Level.NextLevel, 1);
				changeCurrentToNext3 = true;
				Application.LoadLevel (Level.NextLevel);
				
				
				
			}
			if (GUI.Button (new Rect (325, 200, 100, 50), "MainMenu")) {
				Application.LoadLevel ("Menu");
			}
		}
		
		if (bFail3) {
			GUI.Box (new Rect (100, 125, 400, 200), "");
			GUI.Box (new Rect (100, 125, 400, 200), "");
			
			GUI.Label (new Rect (175, 150, 400, 400), "Leider nicht die richtige Lösung!");
			
			if (GUI.Button (new Rect (175, 200, 100, 50), "Neustarten")) {
				Application.LoadLevel (Level.CurrentLevel);
			}
			if (GUI.Button (new Rect (325, 200, 100, 50), "MainMenu")) {
				Application.LoadLevel ("Menu");
			}
		}
	}
	
	
	void GetBooleans2(){
		
		if(MTask3.TryGetValue(iconel23, out boolElement23)){
			//print ("P");
			//print (boolElement2);
		}
		
		else{
			print ("Key is not found.");
		}
		
		if(MTask3.TryGetValue(iconel13, out boolElement13)){
			//print ("B");
			//print (boolElement1);
		}
		
		else{
			print ("Key is not found.");
		}
		
		if(MTask3.TryGetValue(iconel33, out boolElement33)){
			//print ("Element3");
			//print(boolElement3);
		}
		
		else{
			print ("Key is not found.");
		}
	}
	
	
	void TestIfMathTaskIsRight2(){
		
		//	print (bPTF + " " + bBTF + " " + bYTF);
		//	print (toggle1 + " " + toggle2 + " " + toggle3);
		
		
		if(boolElement23 == toggle23 && boolElement13 == toggle13 && boolElement33 == toggle33){
			bComplete3 = true;
			bMathTask3 = false;
		}
		else{
			bFail3 = true;
			bMathTask3 = false;
		}
		
	}
	
}
