using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallAnimator : MonoBehaviour {

	private Transform[] childrens;
	float value;
	public float animationSpeed;
	private float[] setScale;

	// Use this for initialization
	void Start () {
		childrens = transform.GetComponentsInChildren<Transform> ();
		Invoke ("AssignAgain", 1.0f);
	}

	private void AssignAgain(){
		childrens = transform.GetComponentsInChildren<Transform> ();

		setScale = new float[childrens.Length];
		for (int i = 0; i < childrens.Length; i++) {
			setScale [i] = childrens [i].localScale.z;

		}
	}
	
	// Update is called once per frame
	void Update () {
		value += Time.deltaTime * animationSpeed;

		if (value > 360) {
			value -= 360;
		}

		float sinValue = Mathf.Sin (value * Mathf.Deg2Rad) * 0.5f + 0.5f;

		for (int i = 1; i < childrens.Length; i++) {
			float mySinValue = (sinValue + ((i % 41) / 41)) % 1;
			childrens [i].localScale = new Vector3 (childrens [i].localScale.x, childrens [i].localScale.y, setScale[i] * mySinValue);
//			childrens [i].localScale = new Vector3 (childrens [i].localScale.x, childrens [i].localScale.y, 1);
		}
	}
}
