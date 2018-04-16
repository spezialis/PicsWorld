using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsMenager : MonoBehaviour {

	AudioSource holeSound;

	//Play the music
	bool play;
	//Detect when you use the toggle, ensures music isn’t played multiple times
	bool toggleChange;

	// Use this for initialization
	void Start () {

		//Fetch the AudioSource from the GameObject
		holeSound = GetComponent<AudioSource>();
		//Ensure the toggle is set to true for the music to play at start-up
		play = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
