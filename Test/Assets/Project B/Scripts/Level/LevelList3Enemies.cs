using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class LevelList3Enemies: MonoBehaviour {

	int num;
	string element;

	 Vector3 pos1;
	 Vector3 pos2;
	 Vector3 pos3;

	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;

	public GameObject Element1;
	public GameObject Element2;
	public GameObject Element3;

	public List<GameObject> Enemies1; 
	public List<GameObject> Elements1;
	public List<Vector3> Positions1;

	public static Dictionary<GameObject, GameObject> dict = new Dictionary<GameObject, GameObject>();

	public static int ElementCounter;

	public static bool bEle1;
	public static bool bEle2;
	public static bool bEle3;

	public static bool bAED;

	public static Vector3 VecElement1;
	public static Vector3 VecElement2;
	public static Vector3 VecElement3;

	


	// Use this for initialization
	void Start () {

		bAED = false;

		pos1 = Enemy1.transform.position;
		pos2 = Enemy2.transform.position;
		pos3 = Enemy3.transform.position;

		bEle1 = false;
		bEle3 = false;
		bEle2 = false;

			Positions1 = new List<Vector3>();
			Positions1.Add(pos1);
		    Positions1.Add(pos2);
		    Positions1.Add(pos3);

			for (int i = 0; i < Positions1.Count; i++) {
//				print (Positions1[i]);
			}

			Enemies1 = new List<GameObject>();
			Enemies1.Add(Enemy1);
			Enemies1.Add(Enemy2);
			Enemies1.Add(Enemy3);

			for (int i = 0; i < Enemies1.Count; i++) {
//				print (Enemies1[i]);
			}

			Elements1 = new List<GameObject>();
			Elements1.Add(Element1);
			Elements1.Add(Element2);
			Elements1.Add(Element3);

			ElementCounter = Elements1.Count;
			
			for (int i = 0; i < Elements1.Count; i++) {
//				print (Elements1[i]);
			}

		for (int i = 0; i < Enemies1.Count; i++) {
			num = UnityEngine.Random.Range(0, Enemies1.Count - i);
			dict.Add(Enemies1[i],Elements1[num]);
			Elements1.RemoveAt(num);
			//print (dict.Values);
			//print (dict.Keys);
		}
		//print (Elements.Count);
		//print (Enemies.Count);
		//print (dict.Count);

		//GameObject go1 = dict.Values.ElementAt(dict.Count-1);
		//GameObject go2 = dict.Values.ElementAt(dict.Count-2);
		//GameObject go3 = dict.Values.ElementAt(dict.Count-3);
		//print (go1);
		//print (go2);
		//print (go3);


	/*	GameObject value = null;
		if (dict.TryGetValue(Enemy1, out value))
		{
			print("For key = \"Enemy1\", value = {0}.");
			print (value);
		}
		else
		{
			print("Key = \"Enemy1\" is not found.");
		}*/


	}
	
	// Update is called once per frame
	void Update () {

		if (Enemy1 != null) {
			pos1 = Enemy1.transform.position;
		} else {
			Positions1[0] = pos1;
			//print (pos1);
		}

		if (Enemy2 != null) {
			pos2 = Enemy2.transform.position;
		} else {
			Positions1[1] = pos2;
			//print (pos2);
		}

		if (Enemy3 != null) {
			pos3 = Enemy3.transform.position;
		} else {
			Positions1[2] = pos3;
			//print (pos3);
		}

		//print (pos1.x + " " + pos1.y);
		//print (pos2.x + " " + pos2.y);
		//print (pos3.x + " " + pos3.y);

		AllEnemiesDead ();

		ElementTest ();

	}

	void ElementTest(){

		for (int i = 0; i < Enemies1.Count; i++) {
			
			if(Enemies1[i] == null){
				
				GameObject value = null;
				
				if(dict.TryGetValue(Enemies1[i], out value)){
					//print ("For Key " + Enemies[i] + " =");
					element = value.name;
					//print (value.name);

						if(element == "Element1"){
							bEle1 = true;
							VecElement1 = Positions1[i];
						}
						if(element == "Element2"){
							bEle2 = true;
							VecElement2 = Positions1[i];
						}
						if(element == "Element3"){				
							bEle3 = true;
							VecElement3 = Positions1[i];
						}
						

				}
				else{
					print ("Key " + Enemies1[i] + " is not found.");
				}
			}

			/*if(element == "Element1"){
				bElement1 = true;
			}
			if(element == "Element2"){
				bElement2 = true;
			}
			if(element == "Element3"){
				bElement3 = true;
			}*/
		}

	}

	void AllEnemiesDead(){

		if (Enemy1 == null && Enemy2 == null && Enemy3 == null) {
			bAED = true;
		}
	}

	//OLD DRY s.o.
	
	/*if(Enemy1 == null){
			print ("Enemy1111111");

			GameObject value = null;
			if (dict.TryGetValue(Enemy1, out value))
			{
				print("For key = \"Enemy1\", value = {0}.");
				print (value);
				print(value.name);
			}
			else
			{
				print("Key = \"Enemy1\" is not found.");
			}
		}

		if(Enemy2 == null){
			print ("Enemy1111111");
			
			GameObject value = null;
			if (dict.TryGetValue(Enemy2, out value))
			{
				print("For key = \"Enemy2\", value = {0}.");
				print (value);
				print(value.name);
			}
			else
			{
				print("Key = \"Enemy2\" is not found.");
			}
		}

		if(Enemy3 == null){
			print ("Enemy1111111");
			
			GameObject value = null;
			if (dict.TryGetValue(Enemy3, out value))
			{
				print("For key = \"Enemy3\", value = {0}.");
				print (value);
				print(value.name);
			}
			else
			{
				print("Key = \"Enemy3\" is not found.");
			}
		}*/
}
