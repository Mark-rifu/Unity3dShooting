using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Vector3 diff;
	//playerとカメラの差分を入れるための変数。距離を格納するので、Vector3。
	public GameObject player;
	public float speed;


	// Use this for initialization
	void Start () {
		diff = player.transform.position - transform.position;
	}
		


	void LateUpdate(){
		if(player){transform.position = Vector3.Lerp(
			transform.position,player.transform.position -diff,Time.deltaTime * speed
		);
		//player.transform.position -diffはプレイヤーの位置のこと。
		}
	}

	void Update(){

	}

}
