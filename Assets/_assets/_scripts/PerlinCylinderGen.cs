using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinCylinderGen : MonoBehaviour {

	public int size = 0;
	private Transform[] childrens;
	public float scale = 0.1f;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				GameObject go = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
				go.transform.position = new Vector3 (i, 0f, j);
				go.transform.parent = gameObject.transform;
			}
		}

		childrens = transform.GetComponentsInChildren<Transform> ();

		foreach (Transform child in childrens) {
//			print (child);
			float heigth = Mathf.PerlinNoise (child.transform.position.x/scale, child.transform.position.z/scale);
//			child.renderer.material.color = Color (heigth, heigth, heigth, heigth);
		}

	}
	
	// Update is called once per frame
	void Update () {

	}
}
