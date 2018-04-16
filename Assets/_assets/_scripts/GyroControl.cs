using UnityEngine;
using System.Collections;

public class GyroControl : MonoBehaviour {

	Gyroscope gyro;
	Quaternion quatMult;
	Quaternion quatMap;
	GameObject camGrandparent;
	GameObject camParent;

	//stocker l'objet qu'on voit
	GameObject objectSeen;

	void Awake(){
		//crée un nouvel objet autour de la camera
		camParent = new GameObject("camParent");
		camGrandparent = new GameObject("camGrandParent");
		camParent.transform.position = this.gameObject.transform.position;
		camGrandparent.transform.position = transform.position;

		camParent.transform.SetParent(camGrandparent.transform);
		transform.SetParent(camParent.transform);

		gyro = Input.gyro;
		gyro.enabled = true;

		//fait pivoter la camera de 90°
		camParent.transform.eulerAngles = new Vector3(90,90,0);

		if(Screen.orientation == ScreenOrientation.LandscapeLeft){
			quatMult = new Quaternion(0f,0f,0.7071f, 0.7071f);
		}else if(Screen.orientation == ScreenOrientation.LandscapeRight){
			quatMult = new Quaternion(0f,0f,-0.7071f, -0.7071f);
		}else if(Screen.orientation == ScreenOrientation.Portrait){
			quatMult = new Quaternion(0f,0f,1f,0f);
		}else if(Screen.orientation == ScreenOrientation.PortraitUpsideDown){
			quatMult = new Quaternion(0f,0f,0f,1f);
		}
	}


	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

		quatMap = gyro.attitude;
		transform.localRotation = quatMap * quatMult;
	}
}
