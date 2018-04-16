using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorManager_1 : MonoBehaviour {

	public int[] thresholds = new int[5];

	public bool[] sensorState = new bool[5];

//	public bool debug = true;

	float startListenToSensor;
	float delay = 2f;

	public bool ArduinoUpdateFromPin(string pin, int threshold){ // Return a bool if the pin value is small than the threshold
//		if (!debug) {
			if (!MessageListener.pins.ContainsKey (pin))
				return false;
//		}
			
		int pinValue = MessageListener.pins [pin];
		return pinValue < threshold;
	}
		
	void Start () {

	}

	void Update () {
		
		for (int i = 0; i < thresholds.Length; i++) {

//			if (!debug) {
				// Checking the threshold values
				sensorState[i] = ArduinoUpdateFromPin(MessageListener.pinNames[i], thresholds[i]);
//			}

			if (i == 0) { // The first pin is the distance sensor
				// TODO: let the sensor remain active when the sensor value is changing
				gameObject.GetComponent<WorldManager_1> ().showWorld(sensorState [0]);
			}

			/*if (!sensorState [0]) {
				sensorState [i] = false;
			}*/

			// TODO: Start listening at photocells sensor after sensorState0 is active
			//if (sensorState [0]) {
//				startListenToSensor += Time.deltaTime;
//
//				if (startListenToSensor >= delay) {
////					Debug.Log ("star listening to photocell sensors");
//
//					if (i >= 1) {
//						gameObject.GetComponent<WorldManager_1> ().activateHole (i, sensorState [i]);
//					}
//				}

				if (i >= 1) {
					gameObject.GetComponent<WorldManager_1> ().activateHole (i, sensorState [i]);
				}
			//}
		}	
	}
}
