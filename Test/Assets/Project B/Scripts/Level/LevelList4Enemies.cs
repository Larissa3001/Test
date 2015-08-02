using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class LevelList4Enemies: MonoBehaviour {
	
	int num4;
	string element4;
	
	Vector3 pos14;
	Vector3 pos24;
	Vector3 pos34;
	Vector3 pos44;
	
	public GameObject Enemy14;
	public GameObject Enemy24;
	public GameObject Enemy34;
	public GameObject Enemy44;
	
	public GameObject Element14;
	public GameObject Element24;
	public GameObject Element34;
	public GameObject Element44;
	
	public List<GameObject> Enemies14; 
	public List<GameObject> Elements14;
	public List<Vector3> Positions14;
	
	public static Dictionary<GameObject, GameObject> dict4 = new Dictionary<GameObject, GameObject>();
	
	public static int ElementCounter4;
	
	public static bool bEle14;
	public static bool bEle24;
	public static bool bEle34;
	public static bool bEle44;
	
	public static bool bAED4;
	
	public static Vector3 VecElement14;
	public static Vector3 VecElement24;
	public static Vector3 VecElement34;
	public static Vector3 VecElement44;
	
	
	
	// Use this for initialization
	void Start () {
		
		bAED4 = false;
		
		pos14 = Enemy14.transform.position;
		pos24 = Enemy24.transform.position;
		pos34 = Enemy34.transform.position;
		pos44 = Enemy44.transform.position;

		
		bEle14 = false;
		bEle34 = false;
		bEle24 = false;
		bEle44 = false;
		
		Positions14 = new List<Vector3>();
		Positions14.Add(pos14);
		Positions14.Add(pos24);
		Positions14.Add(pos34);
		Positions14.Add(pos44);

		for (int i = 0; i < Positions14.Count; i++) {
				//		print (Positions14[i]);
		}
		
		Enemies14 = new List<GameObject>();
		Enemies14.Add(Enemy14);
		Enemies14.Add(Enemy24);
		Enemies14.Add(Enemy34);
		Enemies14.Add(Enemy44);
		
		for (int i = 0; i < Enemies14.Count; i++) {
				//		print (Enemies14[i]);
		}
		
		Elements14 = new List<GameObject>();
		Elements14.Add(Element14);
		Elements14.Add(Element24);
		Elements14.Add(Element34);
		Elements14.Add(Element44);
		
		ElementCounter4 = Elements14.Count;
		
		for (int i = 0; i < Elements14.Count; i++) {
			//			print (Elements14[i]);
		}
		
		for (int i = 0; i < Enemies14.Count; i++) {
			num4 = UnityEngine.Random.Range(0, Enemies14.Count - i);
			dict4.Add(Enemies14[i],Elements14[num4]);
			Elements14.RemoveAt(num4);
			//print (dict.Values);
			//print (dict.Keys);
		}
		//print (Elements.Count);
		//print (Enemies.Count);
		//print (dict.Count);
		
		//GameObject go1 = dict4.Values.ElementAt(dict4.Count-1);
		//GameObject go2 = dict4.Values.ElementAt(dict4.Count-2);
		//GameObject go3 = dict4.Values.ElementAt(dict4.Count-3);
		//GameObject go4 = dict4.Values.ElementAt(dict4.Count-4);
		//print (go1);
		//print (go2);
		//print (go3);
		//print (go4);
		
		
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
		
		if (Enemy14 != null) {
			pos14 = Enemy14.transform.position;
		} else {
			Positions14[0] = pos14;
			//print (pos14);
		}
		
		if (Enemy24 != null) {
			pos24 = Enemy24.transform.position;
		} else {
			Positions14[1] = pos24;
			//print (pos24);
		}
		
		if (Enemy34 != null) {
			pos34 = Enemy34.transform.position;
		} else {
			Positions14[2] = pos34;
			//print (pos34);
		}
		if (Enemy44 != null) {
			pos44 = Enemy44.transform.position;
		} else {
			Positions14[3] = pos44;
			//print (pos44);
		}
		
		//print (pos1.x + " " + pos1.y);
		//print (pos2.x + " " + pos2.y);
		//print (pos3.x + " " + pos3.y);
		
		AllEnemiesDead4 ();
		
		ElementTest4 ();
		
	}
	
	void ElementTest4(){
		
		for (int i = 0; i < Enemies14.Count; i++) {
			
			if(Enemies14[i] == null){
				
				GameObject value = null;
				
				if(dict4.TryGetValue(Enemies14[i], out value)){
					//print ("For Key " + Enemies[i] + " =");
					element4 = value.name;
					//print (value.name);
					
					if(element4 == "Element1"){
						bEle14 = true;
						VecElement14 = Positions14[i];
					}
					if(element4 == "Element2"){
						bEle24 = true;
						VecElement24 = Positions14[i];
					}
					if(element4 == "Element3"){				
						bEle34 = true;
						VecElement34 = Positions14[i];
					}
					if(element4 == "Element4"){				
						bEle44 = true;
						VecElement44 = Positions14[i];
					}
					
					
				}
				else{
					print ("Key " + Enemies14[i] + " is not found.");
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
	
	void AllEnemiesDead4(){
		
		if (Enemy14 == null && Enemy24 == null && Enemy34 == null && Enemy44 == null) {
			bAED4 = true;
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
