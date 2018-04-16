using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clonePrefab_1 : MonoBehaviour {

	public Transform prefab;
	public float dist;
	//dist 0.875 = 41; 1.75 = 21; 3.5 = 11

	public int dirX;
	public int dirY;
	public int dirZ;

//	public int size;

	public float angleX;
	public float angleY;
	public float angleZ;

	private float perlinNoise = 0f;
	private float refinement = 0.1f;
	private float multiplayer = 2.5f;

	void Start() {

		float posX = gameObject.transform.localPosition.x;
		float posY = gameObject.transform.localPosition.y;
		float posZ = gameObject.transform.localPosition.z;

		for (int i = 0; i < dirX; i++) {
			for (int j = 0; j < dirY; j++) {
				for (int k = 0; k < dirZ; k++) {
					perlinNoise = Mathf.PerlinNoise (i * refinement, j * refinement);

					var clone = Instantiate (prefab, new Vector3 (i * dist - posX, j * dist - posY, k * dist - posZ), Quaternion.Euler(angleX, angleY, angleZ));

					// Perlin noise to disturb the width and heigth of the pics on walls
					clone.transform.localScale = new Vector3 (1f, 1f, perlinNoise * multiplayer);
					clone.name = "Pic";
					clone.transform.parent = gameObject.transform;
				}
			}
		}

	}
}