using UnityEngine;
using System.Collections;

public class Element4 : MonoBehaviour {
	
	public static Texture2D Element4Icon;
	
	// Use this for initialization
	void Start () {
		
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		
		Element4Icon = sr.sprite.texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
