using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speedX;
	public float speedZ;


	//弾をスペースキーで発射の実装
	public GameObject bullet;
	float bulletInterval;

	//敵
	public GameObject enemy;
	float enemyInterval;

	//爆発
	public GameObject explosion;

	//sliderと体力
	Slider slider;
	int playerLife;

	// Use this for initialization
	void Start () {
		bulletInterval = 0.0f;

		enemyInterval = 0.0f;

		//体力の設定
		playerLife = 3;
		//スライダーコンポーネントを取得
		slider = GameObject.Find("Slider").GetComponent<Slider>();
	}

	// Update is called once per frame
	void Update () {
			float vertical = Input.GetAxis("Vertical");
			float horizontal = Input.GetAxis("Horizontal");
			//Inputクラスは入力全般の取得を行うクラスです。
			//ゲームパッドやキーボード、マウスなどから入力を受け取ることができます。


			if (Input.GetKey ("up")) {
				MoveToUp (vertical);
			}if (Input.GetKey ("right")) {
				MoveToRight (horizontal);
			}if (Input.GetKey ("left")) {
				MoveToLeft (horizontal);
			}if (Input.GetKey ("down")) {
				MoveToDown (vertical);
			}

		//弾の生成
		bulletInterval += Time.deltaTime;
		if (Input.GetKey ("space")) {
			if(bulletInterval >= 0.2f){
				GenerateBullet ();
		}
		}

		//敵の生成
		enemyInterval += Time.deltaTime;
		if (enemyInterval >= 5.0f) {
			GenerateEnemy ();
		}
	}



		//移動するためのメソッド。
		//「Horizontal」 の文字列を渡すと水平方向の値、「Vertical」の文字列を渡すと垂直方向の値になります。

		void MoveToUp(float vertical ){
			transform.Translate (0, 0, vertical * speedZ);
		}

		void MoveToRight(float horizontal){
			transform.Translate (horizontal*speedX, 0, 0);
		}

		void MoveToLeft(float horizontal){
			transform.Translate (horizontal*speedX, 0, 0);
		}

		void MoveToDown(float vertical){
			transform.Translate (0, 0, vertical * speedZ);
		}
			
		//弾を生成するためのメソッド

		void GenerateBullet(){
			bulletInterval = 0.0f;
			Instantiate(bullet,transform.transform.position,Quaternion.identity);
		  //ここで、bulletInterval = 0.0f;が必要なのは、
		  //弾が生成されたら0秒にまた戻し、再度bulletInterval += Time.deltaTime;で差分を取得するため
		}

	    //敵を生成するためのメソッド

	    void GenerateEnemy(){
		Quaternion q = Quaternion.Euler (0, 180, 0);
		enemyInterval = 0.0f;
		//ランダムな場所に生成
		Instantiate(enemy,new Vector3(Random.Range(-100,100),transform.position.y,transform.position.z +200),q);
		//戦闘機の200先に生成するために、+200
		//自分の前に生成
		Instantiate(enemy,new Vector3(transform.position.x,transform.position.y,transform.position.z +200),q);


	}

	//爆発
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "EnemyBullet") {
			//体力がへる。
			playerLife--;
			//sliderのvalueが変わる。
			slider.value = playerLife;
			Instantiate (explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Destroy (coll.gameObject);
			//戦闘機のHPがゼロになったら、消滅。
			if (playerLife <= 0) {
				Destroy (this.gameObject);

				//ハイスコア更新
				//ScoreControllerを参照。

				ScoreController obj = GameObject.Find("Main Camera").GetComponent<ScoreController>();
				obj.SaveHighScore ();
			}

		}
	}
		
}




