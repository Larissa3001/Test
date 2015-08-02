using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MathTaskLevel5 : MonoBehaviour {
	
	string MathTaskStr5;
	
	bool bEL2TF5;
	bool bEL1TF5;
	bool bEL3TF5;
	bool bEL4TF5;
	
	bool bMathTask5;
	bool bComplete5;
	bool bFail5;
	bool bShow5;
	
	public Dictionary <Texture2D,bool> MTask5 = new Dictionary <Texture2D,bool>();
	
	private bool toggle15 = false;
	private bool toggle25 = false;
	private bool toggle35 = false;
	private bool toggle45 = false;
	
	Texture2D iconel15;
	Texture2D iconel25;
	Texture2D iconel35;
	Texture2D iconel45;

	bool boolElement15;
	bool boolElement25;
	bool boolElement35;
	bool boolElement45;
	
	int pickedElements;
	
	Time Time;
	
	
	public static bool changeCurrentToNext5;

	
	// Use this for initialization
	void Start () {
		
		bShow5 = true;
		
		pickedElements = 0;

		iconel15 = Element1.Element1Icon;			
		iconel25 = Element2.Element2Icon;
		iconel35 = Element3.Element3Icon;
		iconel45 = Element4.Element4Icon;

		changeCurrentToNext5 = false;
		
		bMathTask5 = false;
		
		bComplete5 = false;
		bFail5 = false; 
		
		SetMathTask ();
		
		MTask5.Add(iconel15,bEL1TF5);
		MTask5.Add(iconel25,bEL2TF5);
		MTask5.Add(iconel35,bEL3TF5);
		MTask5.Add(iconel45,bEL4TF5);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		pickedElements = GameValues.pickedEle;
		
		if(GameValues.bAllEnemiesDead4 &&  pickedElements == 4){
			Time.timeScale = 0;
			bMathTask5 = true;
		}
	}
	
	
	void SetMathTask() {
		
		MathTaskStr5 = "Welche Elemente gehören zur Menge: A = {Enthält die Farbe rot} ?";
		
		bEL2TF5  = true;
		bEL1TF5  = true;
		bEL3TF5  = true;
		bEL4TF5  = false;
		
	}
	
	
	void OnGUI(){
		
		if (bMathTask5 && bShow5) {
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "");
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "MathTask");
			
			GUI.Label (new Rect (100,100, 400, 400), MathTaskStr5);
			
			
			toggle15 = GUI.Toggle (new Rect (50, 175, 100, 50), toggle15, iconel15, "button");
			toggle25 = GUI.Toggle (new Rect (250, 175, 100, 50), toggle25, iconel25, "button");
			toggle35 = GUI.Toggle (new Rect (450, 175, 100, 50), toggle35, iconel35, "button");
			toggle45 = GUI.Toggle (new Rect (250, 250, 100, 50), toggle45, iconel45, "button");
			
			
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
				GetBooleans5();
				TestIfMathTaskIsRight5 ();
				bShow5 = false;
			}
		}
		
		
		
		if (bComplete5) {
			GUI.Box (new Rect (100, 125, 400, 200), "");
			GUI.Box (new Rect (100, 125, 400, 200), "");
			
			GUI.Label (new Rect (175, 150, 400, 400), "Geschafft!" );
			
			if (GUI.Button (new Rect (175, 200, 100, 50), "next Level!")) {
				PlayerPrefs.SetInt(Level.NextLevel, 1);
				changeCurrentToNext5 = true;
				Application.LoadLevel (Level.NextLevel);
				
				
				
			}
			if (GUI.Button (new Rect (325, 200, 100, 50), "MainMenu")) {
				Application.LoadLevel ("Menu");
			}
		}
		
		if (bFail5) {
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
	
	
	void GetBooleans5(){
		
		if(MTask5.TryGetValue(iconel25, out boolElement25)){
			//print ("P");
			//print (boolElement2);
		}
		
		else{
			print ("Key is not found.");
		}
		
		if(MTask5.TryGetValue(iconel15, out boolElement15)){
			//print ("B");
			//print (boolElement1);
		}
		
		else{
			print ("Key is not found.");
		}
		
		if(MTask5.TryGetValue(iconel35, out boolElement35)){
			//print ("Element3");
			//print(boolElement3);
		}
		
		else{
			print ("Key is not found.");
		}
		if(MTask5.TryGetValue(iconel45, out boolElement45)){
			//print ("Element3");
			//print(boolElement3);
		}
		
		else{
			print ("Key is not found.");
		}
	}
	
	
	void TestIfMathTaskIsRight5(){
		
		//	print (bPTF + " " + bBTF + " " + bYTF);
		//	print (toggle1 + " " + toggle2 + " " + toggle3);
		
		
		if(boolElement25 == toggle25 && boolElement15 == toggle15 && boolElement35 == toggle35 && boolElement45 == toggle45){
			bComplete5 = true;
			bMathTask5 = false;
		}
		else{
			bFail5= true;
			bMathTask5 = false;
		}
		
	}
	
}
