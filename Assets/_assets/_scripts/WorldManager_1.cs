using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WorldManager_1 : MonoBehaviour {

	private GameObject box;

	private GameObject world;

	public GameObject[] hole = new GameObject[4];
	private bool [] holeActive = new bool[4];

	public GameObject[] walls = new GameObject[6];

	private GameObject credits;

	public float endTime;
	public float restartDelay;
	private float restartTimer;

	Tween scalingBox;
	Tween scalingWorld;
	Vector3 startScale = new Vector3(0, 0, 0);
	Vector3 endScale = new Vector3(1, 1, 1);
	float duration = 1f;

	float startWallAnim;
	float delay = 2f;

	float hideWorldTime;
	public float hiddenDalay;

	public int[] timeTouched = new int[4];

	AudioSource[] sound = new AudioSource[4];
	public bool sensorsAuthorization = false;

//	public AudioClip clip1;
//	public AudioClip clip2;

	void Start () {

		// Find GameObjcets
		box = GameObject.Find("Box");
		world = GameObject.Find ("World");
		credits = GameObject.Find ("Canvas");

		credits.GetComponent<Animator>().SetTrigger("Start");

		// Make each hole false
		for (int i = 0; i < hole.Length; i++) {
			holeActive [i] = false;

			sound[i] = hole [i].transform.GetChild (0).GetComponent<AudioSource> ();
			sound[i].pitch = Random.Range(1f, 3f);

			timeTouched [i] = 0;
		}
	}

	IEnumerator delayBeforeAuthorize(){
		yield return new WaitForSeconds(1f);
		sensorsAuthorization = true;
	}

	public void showWorld(bool showHide) {

		AudioSource audio = gameObject.GetComponent<AudioSource> ();
		
		if (!showHide) {
			StopCoroutine ("delayBeforeAuthorize");
			sensorsAuthorization = false;
	//			scalingBox = box.transform.DOScale (endScale, duration);
				scalingWorld = world.transform.DOScale (startScale, duration);

				// TODO: Play sound1 when world is srinking

	//			audio.clip = clip2;
	//			audio.PlayOneShot(clip2, 1f);

	//			audio.enabled = true;
		}

		if (showHide) {
//			scalingBox = box.transform.DOScale (startScale, duration);
			scalingWorld = world.transform.DOScale (endScale, duration).SetEase(Ease.InSine);
			StartCoroutine ("delayBeforeAuthorize");
			// TODO: Play sound2

//			audio.clip = clip1;

//			audio.enabled = true;
//			audio.PlayOneShot(clip1, 0.5f);
		}
	}

	public void activateHole(int holeIndex, bool sensorState){
		int newHoleIndex = holeIndex - 1; // Index without the pin0
		if(sensorsAuthorization){ 

		//		Debug.Log ("hole: " + newHoleIndex + " is " + sensorState);

		// Possibility 1 activate holes and animation once
//		holeActive [newHoleIndex] = true; // Set the hole active
//		if (holeActive [newHoleIndex]) {
//			
//			sound [newHoleIndex].enabled = true;
//			hole [newHoleIndex].transform.GetChild (1).GetComponent<clonePrefabInsideCircle> ().animateHolePics = true;
//		}

		// Possibility 2 "toggle" activation
		sound [newHoleIndex].enabled = sensorState;
		hole [newHoleIndex].transform.GetChild (1).GetComponent<clonePrefabInsideCircle> ().animateHolePics = sensorState;

//		// If the user touches the hole for a long period animate the hole forever
//		if (sensorState) {
//			timeTouched [newHoleIndex]++;
//		}

//		if (timeTouched [newHoleIndex] >= 100) {
//			sound [newHoleIndex].enabled = true; // Enable the sound forever
//			hole [newHoleIndex].transform.GetChild (1).GetComponent<clonePrefabInsideCircle> ().animateHolePics = true; // Enable animation of the holes pics forever
//			holeActive [newHoleIndex] = true; // Set the hole active
			//		}
		} else {
			sound [newHoleIndex].enabled = false;
			hole [newHoleIndex].transform.GetChild (1).GetComponent<clonePrefabInsideCircle> ().animateHolePics = false;
		}
	}

	private bool allHolesActive() {
		for (int i = 0; i < 4; i++) {
			if (holeActive [i] == false) {
				return false;
			}
		}
		return true;
	}

	private void animateWalls() {
		startWallAnim += Time.deltaTime;

		if (startWallAnim >= delay) {
			for (int i = 0; i < walls.Length; i++) {
				walls [i].GetComponent<PerlinCylinderGen_3>().animate = true;
			}
		}
	}

	private void showCredits() {
		// Trigger the animation of the credits
//		bool finish = allHolesActive();
		if (allHolesActive()) {
			credits.GetComponent<Animator> ().SetBool("End", true);
		}
//		finish = 
////		if () {

//			credits.GetComponent<Animator>().SetTrigger("End");
//			credits.GetComponent<Animator>().SetBool("Fin") = true;
//		}

	}

	// Restart application
	private void restartGame(){
		
		restartTimer += Time.deltaTime;

		if (restartTimer >= restartDelay) {
			// QUESTION: there is another way to reload the whole experience? For example when the user remove the headset?
			Application.LoadLevel (Application.loadedLevel);
		}
	}
		
	void Update () {
		// Check if all holes are active and animate
		if (allHolesActive()) {
			Debug.Log ("All holes are active");
			StartCoroutine (endGame (endTime));
		}
	}

	private IEnumerator endGame(float time){
		
		animateWalls ();
		yield return new WaitForSeconds (time);
//		showCredits ();
//		restartGame ();
	}
}