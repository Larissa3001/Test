using UnityEngine;
using System.Collections;

public class PickElement : MonoBehaviour {
	
	float YPos;
	bool bPickUp;
	public static int Pnum;

	public static int MathTask;


	// Use this for initialization
	void Start () {

		Pnum = 0;

		MathTask = 0;

		bPickUp = false;

		YPos = GameValues.IconHeight;

	}
	
	// Update is called once per frame
	void Update () {


		YPos = GameValues.IconHeight;

		if (bPickUp) {
			if(Input.GetButtonDown("Fire1")){
				PickUp();
			}
		}
		print (Pnum);

	}

	void PickUp(){
			//Destroy(gameObject);
			gameObject.transform.localScale = new Vector3(transform.localScale.x * 0.5f ,transform.localScale.y * 0.5f, transform.localScale.z);
			gameObject.transform.position = new Vector3(-7.7f,YPos,0);
			print ("Element eingesammelt");

			Pnum += 1;
			GameValues.pickedEle = Pnum;
			GameValues.IconHeight = YPos - 0.75f;


	}

		
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals (EnemyAWConst.PLAYER)) {
			bPickUp = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag.Equals (EnemyAWConst.PLAYER)) {
			bPickUp = false;
		}
	}
}
