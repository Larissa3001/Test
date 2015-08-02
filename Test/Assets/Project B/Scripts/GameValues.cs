using UnityEngine;
using System.Collections;

public class GameValues : MonoBehaviour {

	public static float IconHeight = 5.0f;
	public static int ElementNumber;
	public static int ElementNumber4;

	public static bool bElement1;
	public static bool bElement2;
	public static bool bElement3;

	public static bool bElement14;
	public static bool bElement24;
	public static bool bElement34;
	public static bool bElement44;

	public static Vector3 Element1Vec;
	public static Vector3 Element2Vec;
	public static Vector3 Element3Vec;

	public static Vector3 Element14Vec;
	public static Vector3 Element24Vec;
	public static Vector3 Element34Vec;
	public static Vector3 Element44Vec;

	public static bool bAllEnemiesDead;
	public static bool bAllEnemiesDead4;

	public static int pickedEle;



	// Use this for initialization
	void Start () {


		//3 Enemies

		bElement1 = false;
		bElement2 = false;
		bElement3 = false;

		Element1Vec = LevelList3Enemies.VecElement1;
		Element2Vec = LevelList3Enemies.VecElement2;
		Element3Vec = LevelList3Enemies.VecElement3;

		ElementNumber = LevelList3Enemies.ElementCounter;

		//4 Enemies

		bElement14 = false;
		bElement24= false;
		bElement34 = false;
		bElement44 = false;

		Element14Vec = LevelList4Enemies.VecElement14;
		Element24Vec = LevelList4Enemies.VecElement24;
		Element34Vec = LevelList4Enemies.VecElement34;
		Element34Vec = LevelList4Enemies.VecElement44;

		ElementNumber4 = LevelList4Enemies.ElementCounter4;

		pickedEle = 0;
		IconHeight = 5.0f;

	}
	
	// Update is called once per frame
	void Update () {
		//3 Enemies

		Element1Vec = LevelList3Enemies.VecElement1;
		Element2Vec = LevelList3Enemies.VecElement2;
		Element3Vec = LevelList3Enemies.VecElement3;

		bElement1 = LevelList3Enemies.bEle1;
		bElement2 = LevelList3Enemies.bEle2;
		bElement3 = LevelList3Enemies.bEle3;

		bAllEnemiesDead = LevelList3Enemies.bAED;


		// 4 Enemies
		
		Element14Vec = LevelList4Enemies.VecElement14;
		Element24Vec = LevelList4Enemies.VecElement24;
		Element34Vec = LevelList4Enemies.VecElement34;
		Element44Vec = LevelList4Enemies.VecElement44;
		
		bElement14 = LevelList4Enemies.bEle14;
		bElement24 = LevelList4Enemies.bEle24;
		bElement34 = LevelList4Enemies.bEle34;
		bElement44 = LevelList4Enemies.bEle44;

		bAllEnemiesDead4 = LevelList4Enemies.bAED4;

	}
}
