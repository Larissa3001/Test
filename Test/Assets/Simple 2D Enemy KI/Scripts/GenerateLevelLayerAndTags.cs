using UnityEngine;
using System.Collections;

/*
 * Needed to add layers and tags programmatically to the gameobjects after importing the 2D Enemy KI Asset 
 * 
 * You don't need to implement it on your project
*/
public class GenerateLevelLayerAndTags : MonoBehaviour {

	public bool TagEnemy = false;
	public bool TagPlayer = false;
	public bool TagFieldEdge = false;
	public bool TagFieldTop = false;
	public bool TagShot = false;
	public bool LayerGround = false;
	public bool LayerEnemy = false;
	
	void Awake(){

		if (TagEnemy) {
			gameObject.tag = EnemyAWConst.ENEMY;
		} else if (TagPlayer) {
			gameObject.tag = EnemyAWConst.PLAYER;
		} else if (TagFieldEdge) {
			gameObject.tag = EnemyAWConst.FIELD_EDGE;
		} else if (TagFieldTop) {
			gameObject.tag = EnemyAWConst.FIELD_TOP;
		} else if (TagShot) {
			gameObject.tag = EnemyAWConst.SHOT;
		}

		if (LayerGround) {
			gameObject.layer = LayerMask.NameToLayer (EnemyAWConst.GROUND);
		} else if (LayerEnemy) {
			gameObject.layer = LayerMask.NameToLayer (EnemyAWConst.ENEMY);
		}
	}
}
