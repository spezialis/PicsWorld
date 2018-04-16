using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinCylinderGen_3 : MonoBehaviour {

	private float perlinNoise = 0f;
	public float refinement = 0.1f;
	public float multiplayer = 2.5f;

	public int x = 0;
	public int y = 0;
	public int z = 0;

	public float waveSpeed = 0.5f;
	public float perlinScale = 0.1f;
	public float waveHeight = 5f;

	public Transform prefab;
	private Transform clone;

	List<Transform> pics;

	public bool refinement_xy;
	public bool refinement_xz;
	public bool refinement_yz;

	public bool animate = false;

	// Use this for initialization
	void Start () {
		pics = new List<Transform> ();
		int index = -1;

		for (int i = 0; i < x; i++) {
			for (int j = 0; j < y; j++) {
				for (int k = 0; k < z; k++) {
										
					clone = Instantiate (prefab, transform.position, transform.rotation, gameObject.transform);
					clone.transform.position = new Vector3 (transform.position.x + i, transform.position.y + j,transform.position.z + k);

					index++;
					clone.name = "Pic" + index;

					pics.Add (clone);
				}
			}
		}

		for (int j = 0; j < pics.Count; j++) {
			if (pics[j] != null) {

				float pX = (pics [j].position.x * perlinScale) + (Time.time * waveSpeed);
				float pY = (pics [j].position.y * perlinScale) + (Time.time * waveSpeed);
				float pZ = (pics [j].position.z * perlinScale) + (Time.time * waveSpeed);

				Vector3 scale = pics[j].localScale;

				if (refinement_xy) {
					scale.z = Mathf.Abs((Mathf.PerlinNoise (pX, pY) - 0.5f ) * waveHeight);
				} 
				else if (refinement_xz) {
					scale.z = Mathf.Abs((Mathf.PerlinNoise (pX, pZ) - 0.5f ) * waveHeight);
				} 
				else if (refinement_yz) {
					scale.z = Mathf.Abs((Mathf.PerlinNoise (pY, pZ) - 0.5f ) * waveHeight);
				}

				// Options
				//				scale.z = Mathf.Sin (Time.time * 0.001f * j);
				//				scale.z = Mathf.Sin (Time.time * j );
				//				scale.z = Mathf.Tan (Time.time);
				//				scale.z = Mathf.Tan (Time.time * j);
				//				scale.z = Mathf.Tan (Time.time * 0.001f * j);

				pics[j].transform.localScale = scale;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: animate the z val of pics with perlin noise
		float elapsedTime = Time.time; // amount of time passed since the app started
		perlinNoise = Mathf.PerlinNoise(elapsedTime, 0f);

		AnimatePics();
	}
		
	void AnimatePics() {

		if (animate) {
			for (int j = 0; j < pics.Count; j++) {
				if (pics[j] != null) {

					Vector3 scale = pics[j].localScale;

					float pX = (pics [j].position.x * perlinScale) + (Time.time * waveSpeed);
					float pY = (pics [j].position.y * perlinScale) + (Time.time * waveSpeed);
					float pZ = (pics [j].position.z * perlinScale) + (Time.time * waveSpeed);

					if (refinement_xy) {
						scale.z = Mathf.Abs((Mathf.PerlinNoise (pX, pY) - 0.5f ) * waveHeight);
					} 
					else if (refinement_xz) {
						scale.z = Mathf.Abs((Mathf.PerlinNoise (pX, pZ) - 0.5f ) * waveHeight);
					} 
					else if (refinement_yz) {
						scale.z = Mathf.Abs((Mathf.PerlinNoise (pY, pZ) - 0.5f ) * waveHeight);
					}

					// Options
					//				scale.z = Mathf.Sin (Time.time * 0.001f * j);
					//				scale.z = Mathf.Sin (Time.time * j );
					//				scale.z = Mathf.Tan (Time.time);
					//				scale.z = Mathf.Tan (Time.time * j);
					//				scale.z = Mathf.Tan (Time.time * 0.001f * j);

					pics[j].transform.localScale = scale;
				}
			}
		}
	}
}
