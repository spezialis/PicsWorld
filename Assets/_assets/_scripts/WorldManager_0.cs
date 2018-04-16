using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager_0 : MonoBehaviour {

//	public GameObject box;
//	private bool boxVisible = true;
//
//	private GameObject world;
//
//	private GameObject[] holes;
//	//	bool [] holes = new bool[4];
//	AudioSource noise;
//
//	public GameObject[] walls;
//	private bool animateWalls = false;
//
//	private GameObject credits;
//
//
//	// Use this bool on private
//	public bool endAll = false;
//	public float endTime;
//
//	public float restartDelay;
//	private float restartTimer;
//
//	// Use this for initialization
//	void Start () {
//
//		// Find sensors
//		bool[] sensors = gameObject.GetComponent<SensorManager_0>().sensorActive;
//
//		// Find GameObjcets
//		box = GameObject.Find("Box");
//		credits = GameObject.Find ("Canvas");
//
//		bool boxVisible = true;
//		hideBox (boxVisible);
//	}
//
//	public void activateHole(int holeIndex){
//
////		holes [holeIndex] = true;
////
////		bool allHoles = true;
////		for (int i = 0; i < holes.Length; i++) {
////			if (holes[i] == false) {
////				allHoles = false;
////			}
////		}
//
////		if (allHoles) {
////			StartCoroutine (endGame (endTime));
////		}
//
//	}
//
//	private void animWalls() {
//
//		if (animateWalls) {
//			for (int i = 0; i < walls.Length; i++) {
//				walls [i].GetComponent<PerlinCylinderGen_3>().animate = true;
//			}
//		} else {
//			for (int i = 0; i < walls.Length; i++) {
//				walls [i].GetComponent<PerlinCylinderGen_3>().animate = false;
//			}
//		}
//	}
//
//	private void showCredits() {
//		// Trigger the animation of the credits
//		credits.GetComponent<Animator>().SetTrigger("EndExperience");
//	}
//
//	// Restart application
//	private void restartGame(){
//		
//		restartTimer += Time.deltaTime;
//
//		if (restartTimer >= restartDelay) {
//			// TODO: restart application or experience
//			// QUESTION: there is another way to reload the whole experience? For example when the user remove the headset?
//			Application.LoadLevel (Application.loadedLevel);
//		}
//	}
//		
//	// Update is called once per frame
//	void Update () {
//
//		if (gameObject.GetComponent<SensorManager_0>().sensorActive) {
//			boxVisible = false; 
//		}
//
//		hideBox (boxVisible);
//
//
//		if (endAll) {
//			animateWalls = true;
//			StartCoroutine (endGame (endTime));
//		}
//
//
//	}
//
//	private IEnumerator endGame(float time){
//
//		animWalls ();
//		yield return new WaitForSeconds (time);
//		showCredits ();
//		restartGame ();
//
//	}
//
//	void hideBox(bool boxVisible){
//		if (boxVisible) { // If the box is visible
//			box.SetActive(true);
//
//			// Hide the world
//			//			world.transform.localScale = new Vector3 (0, 0, 0);
//			//			noise = hole.GetComponent<AudioSource> ();
//
//		} else if (!boxVisible){ // If the user isert his hand in the real box, check treshold 
//			box.SetActive(false);
//
//			// Show the world
//			// TODO: use a tween for this transformation
//			// QUESTION: why the pics on the wall disapear?
//			//			world.transform.localScale = new Vector3 (1, 1, 1);
//		}
//	}
}
