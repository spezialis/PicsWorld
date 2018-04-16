 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinGen_0 : MonoBehaviour {

	public Vector2 perlinPos;
	public float perlinNoise = 0f;
	 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		perlinNoise = Mathf.PerlinNoise (perlinPos.x, perlinPos.y);
	}
}
