using UnityEngine;
using System.Collections;

public class Element8 : MonoBehaviour {
	
	public static Texture2D Element8Icon;
	
	// Use this for initialization
	void Start () {
		
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		
		Element8Icon = sr.sprite.texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}

