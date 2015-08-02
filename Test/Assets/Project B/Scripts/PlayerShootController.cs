using UnityEngine;
using System.Collections;

public class PlayerShootController : MonoBehaviour {

	public GameObject ShootObject;
	private float horizontal;

	bool bRight;
	bool bLeft;

	// Use this for initialization
	void Start () {
	
		bRight = true;
		bLeft = false;
	}
	
	// Update is called once per frame
	void Update () {

		horizontal = Input.GetAxis(EnemyAWConst.HORIZONTAL);
		horizontal = Mathf.Clamp( horizontal, -1f, 1f );

		
		if( horizontal > 0f){
			bRight = true;
			bLeft = false;
		}
			
			
		else if( horizontal < 0f){
			bRight = false;
			bLeft = true;
		}

	//	print ("Rechts " + bRight + " Left " + bLeft);


		if(Input.GetButtonDown("Jump")){
			PlayerShoot();
		}
	}

	void PlayerShoot(){
		GameObject go = (GameObject) Instantiate(ShootObject, transform.position, Quaternion.identity);
		
		//Fire left or right
		if(bRight){
			go.GetComponent<PlayerShootObject> ().Right = true;
		} if(bLeft) {
			go.GetComponent<PlayerShootObject> ().Left = true;
		}
	}
}
