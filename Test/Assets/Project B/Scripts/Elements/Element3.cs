using UnityEngine;
using System.Collections;

public class Element3 : MonoBehaviour {
	
	public static Texture2D Element3Icon;
	
	// Use this for initialization
	void Start () {
		
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		
		Element3Icon = sr.sprite.texture;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
}
