using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteClones : MonoBehaviour {

//	void OnCollisionEnter(Collision col){
//		if (col.gameObject.name == "Pic") {
//			Destroy (col.gameObject);
//		}
//	}

	void Start (){
		Invoke ("DeleteAll", 0.05f);
	}


	private void DeleteAll(){
		GameObject rootParent = GameObject.Find("Pics_walls");

//		if (transform.childCount > 0) {
			Transform[] childrens = rootParent.GetComponentsInChildren<Transform> ();

			// Delete all cylinder inside holes
			for (int i = 0; i < childrens.Length; i++) {
				float distance = (childrens [i].transform.position - transform.position).magnitude;

				if (distance < transform.localScale.x / 2.0f) {
					Destroy (childrens [i].gameObject);
				}
			}
//		}
	}
}
