using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MathTaskLevel2 : MonoBehaviour {
	
	string MathTaskStr2;
	
	bool bEL2TF2;
	bool bEL1TF2;
	bool bEL3TF2;
	
	bool bMathTask2;
	bool bComplete2;
	bool bFail2;
	bool bShow2;

	public Dictionary <Texture2D,bool> MTask2 = new Dictionary <Texture2D,bool>();
	
	private bool toggle12 = false;
	private bool toggle22 = false;
	private bool toggle32 = false;
	
	Texture2D iconel12;
	Texture2D iconel22;
	Texture2D iconel32;
	
	bool boolElement22;
	bool boolElement32;
	bool boolElement12;

	int pickedElements;


	
	public static bool changeCurrentToNext2;
	
	
	
	// Use this for initialization
	void Start () {


		bShow2 = true;

		pickedElements = 0;

		iconel12 = Element1.Element1Icon;			
		iconel22 = Element2.Element2Icon;
		iconel32 = Element3.Element3Icon;

		changeCurrentToNext2 = false;
		
		bMathTask2 = false;
		
		bComplete2 = false;
		bFail2 = false; 
		
		SetMathTask2 ();

		MTask2.Add(iconel12,bEL1TF2);
		MTask2.Add(iconel22,bEL2TF2);
		MTask2.Add(iconel32,bEL3TF2);
		
	}
	
	// Update is called once per frame
	void Update () {


		pickedElements = GameValues.pickedEle;
		
		if(GameValues.bAllEnemiesDead &&  pickedElements == 3){
				bMathTask2 = true;
		}
	}
	
	
	void SetMathTask2() {
		
		MathTaskStr2 = "Welche Elemente gehören zur Menge: A = {Blau} ?";
		
		bEL2TF2 = false;
		bEL1TF2 = true;
		bEL3TF2 = false;
		
	}
	
	
	void OnGUI(){
		
		if (bMathTask2 && bShow2) {
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "");
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "MathTask");
			
			GUI.Label (new Rect (100,100, 400, 400), MathTaskStr2);
			
			
			toggle12 = GUI.Toggle (new Rect (50, 175, 100, 50), toggle12, iconel12, "button");
			toggle22 = GUI.Toggle (new Rect (250, 175, 100, 50), toggle22, iconel22, "button");
			toggle32 = GUI.Toggle (new Rect (450, 175, 100, 50), toggle32, iconel32, "button");
			
			
			
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
				bShow2 = false;
			}
		}
		
		
		
		if (bComplete2) {
			GUI.Box (new Rect (100, 125, 400, 200), "");
			GUI.Box (new Rect (100, 125, 400, 200), "");
			
			GUI.Label (new Rect (175, 150, 400, 400), "Geschafft!" );
			
			if (GUI.Button (new Rect (175, 200, 100, 50), "next Level!")) {
				PlayerPrefs.SetInt(Level.NextLevel, 1);
				changeCurrentToNext2 = true;
				Application.LoadLevel (Level.NextLevel);

				
				
			}
			if (GUI.Button (new Rect (325, 200, 100, 50), "MainMenu")) {
				Application.LoadLevel ("Menu");
			}
		}
		
		if (bFail2) {
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
		
		if(MTask2.TryGetValue(iconel22, out boolElement22)){
			//print ("P");
			//print (boolElement2);
		}
		
		else{
			print ("Key is not found.");
		}
		
		if(MTask2.TryGetValue(iconel12, out boolElement12)){
			//print ("B");
			//print (boolElement1);
		}
		
		else{
			print ("Key is not found.");
		}
		
		if(MTask2.TryGetValue(iconel32, out boolElement32)){
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
		
		
		if(boolElement22 == toggle22 && boolElement12 == toggle12 && boolElement32 == toggle32){
			bComplete2 = true;
			bMathTask2 = false;
		}
		else{
			bFail2= true;
			bMathTask2 = false;
		}
		
	}
	
}
