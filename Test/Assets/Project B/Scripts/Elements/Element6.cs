using UnityEngine;
using System.Collections;

public class Element6 : MonoBehaviour {
	
	public static Texture2D Element6Icon;
	
	// Use this for initialization
	void Start () {
		
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		
		Element6Icon = sr.sprite.texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
