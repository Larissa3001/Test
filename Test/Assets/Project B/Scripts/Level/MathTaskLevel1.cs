using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MathTaskLevel1 : MonoBehaviour {

	string MathTaskStr;

	bool bEL2TF;
	bool bEL1TF;
	bool bEL3TF;

	bool bMathTask;
	bool bComplete;
	bool bFail;
	bool bShow;

	public Dictionary <Texture2D,bool> MTask = new Dictionary <Texture2D,bool>();

	private bool toggle1 = false;
	private bool toggle2 = false;
	private bool toggle3 = false;

	Texture2D iconel1;
	Texture2D iconel2;
	Texture2D iconel3;

	bool boolElement2;
	bool boolElement3;
	bool boolElement1;


	int pickedElements;

	public static bool changeCurrentToNext;



	// Use this for initialization
	void Start () {

		bShow = true;

		pickedElements = 0;

		iconel1 = Element1.Element1Icon;			
		iconel2 = Element2.Element2Icon;
		iconel3 = Element3.Element3Icon;

		changeCurrentToNext = false;

		bMathTask = false;

		bComplete = false;
		bFail = false; 

		SetMathTask ();

		MTask.Add(iconel1,bEL1TF);
		MTask.Add(iconel2,bEL2TF);
		MTask.Add(iconel3,bEL3TF);


	}
	
	// Update is called once per frame
	void Update () {

		pickedElements = GameValues.pickedEle;



		if(GameValues.bAllEnemiesDead && pickedElements == 3){
			bMathTask = true;
		}
	}

	
	void SetMathTask() {

			MathTaskStr = "Welche Elemente gehören zur Menge: A = {Farben heller als Blau} ?";
		
			bEL2TF = true;
			bEL1TF = false;
			bEL3TF = true;

	}

	
	void OnGUI(){
		
		if (bMathTask && bShow) {
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "");
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "MathTask");
		
			GUI.Label (new Rect (100,100, 400, 400), MathTaskStr);
		
		
			toggle1 = GUI.Toggle (new Rect (50, 175, 100, 50), toggle1, iconel1, "button");
			toggle2 = GUI.Toggle (new Rect (250, 175, 100, 50), toggle2, iconel2, "button");
			toggle3 = GUI.Toggle (new Rect (450, 175, 100, 50), toggle3, iconel3, "button");
		
		
		
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
				GetBooleans();
				TestIfMathTaskIsRight ();
				bShow = false;
			}
		}
		
		
		
		if (bComplete) {
				GUI.Box (new Rect (100, 125, 400, 200), "");
				GUI.Box (new Rect (100, 125, 400, 200), "");

				GUI.Label (new Rect (175, 150, 400, 400), "Geschafft!" );
			
				if (GUI.Button (new Rect (175, 200, 100, 50), "next Level!")) {
					PlayerPrefs.SetInt(Level.NextLevel, 1);
					changeCurrentToNext = true;
					Application.LoadLevel (Level.NextLevel);
					

				}
				if (GUI.Button (new Rect (325, 200, 100, 50), "MainMenu")) {
					Application.LoadLevel ("Menu");
				}
			}
		
			if (bFail) {
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

	
	void GetBooleans(){
		
		if(MTask.TryGetValue(iconel2, out boolElement2)){
			//print ("P");
			//print (boolElement2);
		}
		
		else{
			print ("Key is not found.");
		}
		
		if(MTask.TryGetValue(iconel1, out boolElement1)){
			//print ("B");
			//print (boolElement1);
		}
		
		else{
			print ("Key is not found.");
		}
		
		if(MTask.TryGetValue(iconel3, out boolElement3)){
			//print ("Element3");
			//print(boolElement3);
		}
		
		else{
			print ("Key is not found.");
		}
	}

	
	void TestIfMathTaskIsRight(){

	//	print (bPTF + " " + bBTF + " " + bYTF);
	//	print (toggle1 + " " + toggle2 + " " + toggle3);


		if(boolElement2 == toggle2 && boolElement1 == toggle1 && boolElement3 == toggle3){
			bComplete = true;
			bMathTask = false;
		}
		else{
			bFail = true;
			bMathTask = false;
		}

	}
	
}
