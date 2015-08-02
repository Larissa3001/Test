using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MathTaskLevel4 : MonoBehaviour {
	
	string MathTaskStr4;
	
	bool bEL2TF4;
	bool bEL1TF4;
	bool bEL3TF4;
	bool bEL4TF4;
	
	bool bMathTask4;
	bool bComplete4;
	bool bFail4;
	bool bShow4;
	
	public Dictionary <Texture2D,bool> MTask4 = new Dictionary <Texture2D,bool>();
	
	private bool toggle14 = false;
	private bool toggle24 = false;
	private bool toggle34 = false;
	private bool toggle44 = false;
	
	Texture2D iconel14;
	Texture2D iconel24;
	Texture2D iconel34;
	Texture2D iconel44;
	
	bool boolElement24;
	bool boolElement34;
	bool boolElement14;
	bool boolElement44;
	
	int pickedElements;

	Time Time;

	
	public static bool changeCurrentToNext4;
	
	
	
	// Use this for initialization
	void Start () {
		
		bShow4 = true;

		pickedElements = 0;
		
		iconel14 = Element1.Element1Icon;			
		iconel24 = Element2.Element2Icon;
		iconel34 = Element3.Element3Icon;
		iconel44 = Element4.Element4Icon;
		
		changeCurrentToNext4 = false;
		
		bMathTask4 = false;
		
		bComplete4 = false;
		bFail4 = false; 
		
		SetMathTask ();
		
		MTask4.Add(iconel14,bEL1TF4);
		MTask4.Add(iconel24,bEL2TF4);
		MTask4.Add(iconel34,bEL3TF4);
		MTask4.Add(iconel44,bEL4TF4);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		pickedElements = GameValues.pickedEle;
		
		if(GameValues.bAllEnemiesDead4 &&  pickedElements == 4){
			Time.timeScale = 0;
			bMathTask4 = true;
		}
	}
	
	
	void SetMathTask() {
		
		MathTaskStr4 = "Welche Elemente gehören zur Menge: A = {Enthält die Farbe rot} ?";
		
		bEL2TF4  = true;
		bEL1TF4  = true;
		bEL3TF4  = true;
		bEL4TF4  = false;
		
	}
	
	
	void OnGUI(){
		
		if (bMathTask4 && bShow4) {
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "");
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "MathTask");
			
			GUI.Label (new Rect (100,100, 400, 400), MathTaskStr4);
			
			
			toggle14 = GUI.Toggle (new Rect (50, 175, 100, 50), toggle14, iconel14, "button");
			toggle24 = GUI.Toggle (new Rect (250, 175, 100, 50), toggle24, iconel24, "button");
			toggle34 = GUI.Toggle (new Rect (450, 175, 100, 50), toggle34, iconel34, "button");
			toggle44 = GUI.Toggle (new Rect (250, 250, 100, 50), toggle44, iconel44, "button");
			
			
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
				GetBooleans4();
				TestIfMathTaskIsRight4 ();
				bShow4 = false;
			}
		}
		
		
		
		if (bComplete4) {
			GUI.Box (new Rect (100, 125, 400, 200), "");
			GUI.Box (new Rect (100, 125, 400, 200), "");
			
			GUI.Label (new Rect (175, 150, 400, 400), "Geschafft!" );
			
			if (GUI.Button (new Rect (175, 200, 100, 50), "next Level!")) {
				PlayerPrefs.SetInt(Level.NextLevel, 1);
				changeCurrentToNext4 = true;
				Application.LoadLevel (Level.NextLevel);
				
				
				
			}
			if (GUI.Button (new Rect (325, 200, 100, 50), "MainMenu")) {
				Application.LoadLevel ("Menu");
			}
		}
		
		if (bFail4) {
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
	
	
	void GetBooleans4(){
		
		if(MTask4.TryGetValue(iconel24, out boolElement24)){
			//print ("P");
			//print (boolElement2);
		}
		
		else{
			print ("Key is not found.");
		}
		
		if(MTask4.TryGetValue(iconel14, out boolElement14)){
			//print ("B");
			//print (boolElement1);
		}
		
		else{
			print ("Key is not found.");
		}
		
		if(MTask4.TryGetValue(iconel34, out boolElement34)){
			//print ("Element3");
			//print(boolElement3);
		}
		
		else{
			print ("Key is not found.");
		}
		if(MTask4.TryGetValue(iconel44, out boolElement44)){
			//print ("Element3");
			//print(boolElement3);
		}
		
		else{
			print ("Key is not found.");
		}
	}
	
	
	void TestIfMathTaskIsRight4(){
		
		//	print (bPTF + " " + bBTF + " " + bYTF);
		//	print (toggle1 + " " + toggle2 + " " + toggle3);
		
		
		if(boolElement24 == toggle24 && boolElement14 == toggle14 && boolElement34 == toggle34 && boolElement44 == toggle44){
			bComplete4 = true;
			bMathTask4 = false;
		}
		else{
			bFail4= true;
			bMathTask4 = false;
		}
		
	}
	
}
