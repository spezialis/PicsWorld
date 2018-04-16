using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorManager_0 : MonoBehaviour {

	public string pin0;
	public string pin1;
	public string pin2;
	public string pin3;
	public string pin4;

	public int threshold0;
	public int threshold1;
	public int threshold2;
	public int threshold3;
	public int threshold4;

	public bool[] sensorActive = new bool[5];

//	public bool boxVisible;
//
//	AudioSource noise;
//
//	public GameObject box;
//	private GameObject world;

	// Use this for initialization
	void Start () {
		// When the user begin, the box is visible
//		boxVisible = true;
//
//		box = GameObject.Find("Box");
//		box.SetActive(true);
//
//		// If the treshold of the sensor is bigger than... the world is invisible
//		world = gameObject;
////		world.transform.localScale = new Vector3 (0, 0, 0);


//		GameObject hole = GameObject.Find("Cover");
//		noise = hole.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

//		if (boxVisible) { // If the bos is visible
//			box.SetActive(true);
//
//			// Hide the world
////			world.transform.localScale = new Vector3 (0, 0, 0);
//			//			noise = hole.GetComponent<AudioSource> ();
//
//		} else if (!boxVisible){ // If the user isert his hand in the real box, check treshold 
//			box.SetActive(false);
//
//			// Show the world
//			// TODO: use a tween for this transformation
//			// QUESTION: why the pics on the wall disapear?
////			world.transform.localScale = new Vector3 (1, 1, 1);
//		}

//		if (active) {
//			noise.Play ();
//		} else {
//			noise.Stop ();
//		}
		
	}
}
