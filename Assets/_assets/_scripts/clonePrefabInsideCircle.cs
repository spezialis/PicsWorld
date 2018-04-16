using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clonePrefabInsideCircle : MonoBehaviour {

	public Transform prefab;
	public Transform hole;

//	public float angleX;
//	public float angleY;
//	public float angleZ;

	public float waveSpeed = 0.5f;
	public float perlinScale = 0.1f;
	public float waveHeight = 15f;

	List<Transform> holePics;

	public bool animateHolePics = false;

	void Start() {
		// Initialize list
		holePics = new List<Transform> ();

		// Get the radius of the hole
		float holeRadius = hole.localScale.x / 2;
		int quantity = Mathf.RoundToInt(hole.localScale.x * 10);

		Vector3 holePosition = gameObject.transform.position;
		Quaternion holeRotation = gameObject.transform.rotation;

		for (int i = 0; i < quantity; i++) {
			// Instantiate prefab
//			var clone = Instantiate (prefab, holePosition, Quaternion.Euler(angleX, angleY, angleZ), gameObject.transform);
			var clone = Instantiate (prefab, holePosition, holeRotation, gameObject.transform);
				
			// Assign position of clone inside a cricle
			clone.transform.localPosition = Random.insideUnitCircle * holeRadius;

			// Assign a random scale
//			float height = Random.Range (2f, 3f);
//			float width = Random.Range (2f, 3f);
//			clone.transform.localScale = new Vector3(width, width, height);

			// Create perlin noise values
			float pX = (clone.position.x * perlinScale) + (Time.time * waveSpeed);
			float pY = (clone.position.y * perlinScale) + (Time.time * waveSpeed);

			// Assign a the perlin noise to the clone
			Vector3 scale = clone.localScale;
			scale.x = Mathf.Abs((Mathf.PerlinNoise (pX, pY) - 0.5f ) * waveHeight);
			scale.y = Mathf.Abs((Mathf.PerlinNoise (pX, pY) - 0.5f ) * waveHeight);
			scale.z = Mathf.Abs((Mathf.PerlinNoise (pX, pY) - 0.5f ) * waveHeight);

			// Assign a scale to clone
			clone.transform.localScale = scale;

			// Name each clone with index
			clone.name = "PicCircle" + i;

			// Add each clone into a list of clones
			holePics.Add (clone);
		}
	}

	void animateHolesPics() {
		if (animateHolePics) {

			// Animate each clone Z scale with a perlin noise
			for (int i = 0; i < holePics.Count; i++) {
				if (holePics [i] != null) {

					float pX = (holePics[i].position.x * perlinScale) + (Time.time * waveSpeed);
					float pY = (holePics[i].position.y * perlinScale) + (Time.time * waveSpeed);

					Vector3 scale = holePics[i].localScale;
					scale.x = Mathf.Abs((Mathf.PerlinNoise (pX, pY) - 0.5f ) * waveHeight);
					scale.y = Mathf.Abs((Mathf.PerlinNoise (pX, pY) - 0.5f ) * waveHeight);
					scale.z = Mathf.Abs((Mathf.PerlinNoise (pX, pY) - 0.5f ) * waveHeight);

					// scale.z = Mathf.Sin (Time.time);

					holePics[i].transform.localScale = scale;
				}
			}
		}
	}

	void Update () {

		animateHolesPics ();

	}
}