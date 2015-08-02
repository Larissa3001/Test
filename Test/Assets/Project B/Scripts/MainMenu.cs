using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{

	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnGUI(){
		
		
		GUI.Box (new Rect (10, Screen.height / 2 - 100, 200, 125), "MathGame");
	
			if (GUI.Button (new Rect (35, Screen.height / 2 - 65, 150, 25), "Play Game")) {
				Application.LoadLevel ("LevelMenu");
			}
			
			if (GUI.Button (new Rect (35, Screen.height / 2 - 30, 150, 25), "Quit Game")) {
				Application.Quit ();
			}

			if (GUI.Button (new Rect (35, Screen.height / 2 + 65, 150, 25), "Reset Level")) {
				ResetLevel();;
			}

	}

	void ResetLevel(){
		PlayerPrefs.SetInt ("Level2",0);
		PlayerPrefs.SetInt ("Level3",0);
		PlayerPrefs.SetInt ("Level4",0);
		PlayerPrefs.SetInt ("Level5",0);
	}
}
