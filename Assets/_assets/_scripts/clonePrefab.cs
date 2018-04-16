using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clonePrefab : MonoBehaviour {

	public Transform prefab;
	public float dist;
	//dist 0.875 = 41; 1.75 = 21; 3.5 = 11

	public int dirX;
	public int dirY;
	public int dirZ;

	public float angleX;
	public float angleY;
	public float angleZ;

	void Start() {

		float posX = gameObject.transform.localPosition.x;
		float posY = gameObject.transform.localPosition.y;
		float posZ = gameObject.transform.localPosition.z;

		for (int i = 0; i < dirX; i++) {
			for (int j = 0; j < dirY; j++) {
				for (int k = 0; k < dirZ; k++) {
					var clone = Instantiate (prefab, new Vector3 (i * dist - posX, j * dist - posY, k * dist - posZ), Quaternion.Euler(angleX, angleY, angleZ));

					// TODO: instead of a random range use a perlin noise to disturb the width and heigth of the pics on walls
					float height = Random.Range (1f, 1.5f);
					float width = Random.Range (1f, 1.5f);
					clone.transform.localScale = new Vector3(width, width, height);
					clone.name = "Pic";
					clone.transform.parent = gameObject.transform;
				}
			}
		}
	}
}