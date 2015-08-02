using UnityEngine;
using System.Collections;

public class Element1 : MonoBehaviour {
	
	public static Texture2D Element1Icon;
	
	// Use this for initialization
	void Start () {
		
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		
		Element1Icon = sr.sprite.texture;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
}
