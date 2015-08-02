using UnityEngine;
using System.Collections;

public class Element7 : MonoBehaviour {
	
	public static Texture2D Element7Icon;
	
	// Use this for initialization
	void Start () {
		
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		
		Element7Icon = sr.sprite.texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
