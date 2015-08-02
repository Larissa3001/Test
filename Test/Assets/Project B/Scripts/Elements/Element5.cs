using UnityEngine;
using System.Collections;

public class Element5 : MonoBehaviour {
	
	public static Texture2D Element5Icon;
	
	// Use this for initialization
	void Start () {
		
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		
		Element5Icon = sr.sprite.texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
