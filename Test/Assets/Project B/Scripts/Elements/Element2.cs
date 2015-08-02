using UnityEngine;
using System.Collections;

public class Element2 : MonoBehaviour {

	public static Texture2D Element2Icon;

	// Use this for initialization
	void Start () {

		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
	
		Element2Icon = sr.sprite.texture;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
}
