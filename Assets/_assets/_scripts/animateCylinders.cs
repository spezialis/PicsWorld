using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateCylinders : MonoBehaviour {

	public Transform[] childrens;
//	public float animationSpeed;
//	private float[] setScale;

	public float perlinNoise = 0f;
	public float elapsedTime = 0f;
	public float multiplayer = 0f;

	// Use this for initialization
	void Start () {

		childrens = transform.GetComponentsInChildren<Transform> ();

		Debug.Log (childrens);
		
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime = Time.time; // amoun t of time passed since the app started
		perlinNoise = Mathf.PerlinNoise(elapsedTime, 0f);

		for (int i = 1; i < childrens.Length; i++) {
			childrens [i].localScale = new Vector3 (childrens [i].localScale.x, perlinNoise * multiplayer , childrens [i].localScale.z);
		}
		
	}
}
