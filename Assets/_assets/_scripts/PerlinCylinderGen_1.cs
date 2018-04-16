using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinCylinderGen_1 : MonoBehaviour {

	private float perlinNoise = 0f;
	public float refinement = 0.1f;
	public float multiplayer = 0f;

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

	public float randomizer;

	// Use this for initialization
	void Start () {
		pics = new List<Transform> ();

		for (int i = 0; i < x; i++) {
			for (int j = 0; j < y; j++) {
				for (int k = 0; k < z; k++) {

					if (refinement_xy) {
						perlinNoise = Mathf.PerlinNoise (i * refinement, j * refinement);
					} else if (refinement_xz) {
						perlinNoise = Mathf.PerlinNoise (i * refinement, k * refinement);
					} else if (refinement_yz) {
						perlinNoise = Mathf.PerlinNoise (j * refinement, k * refinement);
					}
						
					clone = Instantiate (prefab, transform.position, transform.rotation, gameObject.transform);
					clone.transform.position = new Vector3 (transform.position.x + i, transform.position.y + j,transform.position.z + k);
					clone.transform.localScale = new Vector3 (1f, 1f, perlinNoise * multiplayer);
					clone.name = "Pic";

					pics.Add (clone);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: animate the z val of pics with perlin noise
		float elapsedTime = Time.time; // amount of time passed since the app started
		perlinNoise = Mathf.PerlinNoise(elapsedTime, 0f);

//		AnimateWall();
		AnimateDifferently();
	}
		
	void AnimateDifferently () {
		for (int j = 0; j < pics.Count; j++) {
			if (pics[j] != null) {
				
				Vector3 scale = pics[j].localScale;
				Quaternion rotation = pics[j].localRotation;

				float pX = (pics [j].position.x * perlinScale) + (Time.time * waveSpeed);
				float pY = (pics [j].position.y * perlinScale) + (Time.time * waveSpeed);
				float pZ = (pics [j].position.z * perlinScale) + (Time.time * waveSpeed);
			
				if (refinement_xy) {
					scale.z = Mathf.Abs((Mathf.PerlinNoise (pX, pY) - 0.5f ) * waveHeight);
					rotation.y = Mathf.Abs((Mathf.PerlinNoise (pX, pY) - 0.5f ) * waveHeight);
				} 
				else if (refinement_xz) {
					scale.z = Mathf.Abs((Mathf.PerlinNoise (pX, pZ) - 0.5f ) * waveHeight);
				} 
				else if (refinement_yz) {
					scale.z = Mathf.Abs((Mathf.PerlinNoise (pY, pZ) - 0.5f ) * waveHeight);
				}

				// Options
//				scale.z = Mathf.Sin (Time.time * 0.001f * j);
//				rotation.x = Mathf.Sin (Time.time * 0.001f * j);

//				scale.z = Mathf.Sin (Time.time * j );
//				scale.z = Mathf.Tan (Time.time);
//				scale.z = Mathf.Tan (Time.time * j);
//				scale.z = Mathf.Tan (Time.time * 0.001f * j);

				pics[j].transform.localScale = scale;
				pics[j].transform.localRotation = rotation;
			}
		}
	}

	void AnimateWall() {

//		/for (int i = 0; i < pics.Count; i++) {
		for (int j = 0; j < pics.Count; j++) {
				if (pics[j] != null) {
					Vector3 scale = pics[j].localScale;

					//				scale.z = Mathf.Sin (Time.time * 0.001f * i);
				scale.z = Mathf.PerlinNoise (Time.time * 0.001f * j, j * Time.time  * 0.001f *pics[j].localScale.z);

					pics[j].transform.localScale = scale;

//				}

			}

//
//			if (pics [i] != null) {
//				Vector3 scale = pics [i].localScale;
//
//				//				scale.z = Mathf.Sin (Time.time * 0.001f * i);
//				scale.z = Mathf.PerlinNoise (Time.time * 0.001f * i, i * Time.time * 0.001f);
//
//				pics [i].transform.localScale = scale;
//			}
//
//
		}
//		int m = 0;
//		for (int i = 0; i < x; i++) {
//			for (int j = 0; j < y; j++) {
//				for (int k = 0; k < z; k++) {
//					
//					if (refinement_xy) {
//						perlinNoise = Mathf.PerlinNoise (i * refinement + Time.time, j * refinement + Time.time);
//					} else if (refinement_xz) {
//						perlinNoise = Mathf.PerlinNoise (i * refinement + Time.time, k * refinement + Time.time);
//					} else if (refinement_yz) {
//						perlinNoise = Mathf.PerlinNoise (j * refinement + Time.time, k * refinement + Time.time);
//					}
//
//					Transform pic = pics [m];
//					if (pic != null) {
//						Vector3 scale =  new Vector3 (1f, 1f, perlinNoise * multiplayer);
//
//						pic.transform.localScale = scale;
//					}
//					m++;
//				}
//			}
//		}


//		int i = 0;
//		foreach (Transform pic in pics) {
//			if (pic != null) {
//				Vector3 scale = pic.localScale;
//
////				scale.z = Mathf.Sin (Time.time * 0.001f * i);
//				scale.z = Mathf.PerlinNoise (Time.time * 0.001f * i, i * Time.time  * 0.001f);
//
//				pic.transform.localScale = scale;
//				i++;
//			}
//		}

//		Transform 
//		for (int i = 0; i < x; i++) {
//			newZ [i] = clonesZ [i] * perlinNoise;
//		}
	}
}
