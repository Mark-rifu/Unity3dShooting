using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 5);

		//thisはアタッチされているオブジェクトのインスタンスを示す。
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.forward * Time.deltaTime * speed);
	}
	//具体的には、Time.deltaTimeは1秒当たりに3メートルの速度で動かしたいときなどに使用します。
}
