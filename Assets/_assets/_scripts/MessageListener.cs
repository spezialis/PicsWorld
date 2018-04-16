/**
 * SerialCommUnity (Serial Communication for Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class MessageListener : MonoBehaviour {
	
	public static Dictionary<string, int> pins = new Dictionary<string, int>();
	public static string[] pinNames = {"pin0", "pin1", "pin2", "pin3", "pin4"};

	public string messageIn;
	
	// Invoked when a line of data is received from the serial device.
	void OnMessageArrived(string msg) {
		//Debug.Log("Message arrived: " + msg);
		messageIn = msg;

		string[] msgs = msg.Split('\t');
		//Debug.Log (msgs[0]);

		for(int i = 0; (i < msgs.Length && i < pinNames.Length); i++) {
			int value = int.Parse (msgs [i]);

			if (pins.ContainsKey (pinNames [i])) { 
				pins [pinNames [i]] = value;

			} else {
				pins.Add(pinNames [i], value);
			}
		}
	}

	// Invoked when a connect/disconnect event occurs. The parameter 'success'
	// will be 'true' upon connection, and 'false' upon disconnection or
	// failure to connect.
	void OnConnectionEvent(bool success) {
		if (success)
			Debug.Log("Connection established");
		else
			Debug.Log("Connection attempt failed or disconnection detected");
	}
}
