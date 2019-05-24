using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {


	public Text scoreText;
	public Text HighScore;
	int score;
	//テキストと数字を変えるための入れ物。


	// Use this for initialization
	void Start () {
		score = 0;

		if(SceneManager.GetActiveScene ().name == "Title") {
			HighScore.text = "High Score:" + PlayerPrefs.GetInt ("HighScore");
			//ハイスコアの表示
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().name == "Main") {
			
			scoreText.text = "Score:" + score;
		}
	}

	public void ScorePlus(){
		score += 10;
		//のちに、敵の戦闘機が爆発し、削除されたらこのメソッドを呼ぶように実装
		//EnemyControllerの中で、このスクリプトを参照した。
	}
	//ハイスコアを更新する
	//これまでのスコアより、HighScoreの数字が大きくなったら、セーブする。
	public void SaveHighScore(){
		if(PlayerPrefs.GetInt("HighScore") < score){
			PlayerPrefs.SetInt ("HighScore", score);

			//PlayerPrefs.SetInt(string key, int value);
			//ゲームデータのセーブを行います。
			//第一引数にはどのような名前で値を保存するか（キーと呼ばれるもの）、
			//第二引数には保存するint型の値を渡します。
	}
		//2秒後にタイトルへ
		Invoke("ReturnTitle",2.0f);
}
	    //タイトルに戻るメソッド
	void ReturnTitle(){
		SceneManager.LoadScene ("Title");
	}
			}
