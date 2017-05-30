using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {
	GameObject player;

	// Use this for initialization
	void Start () {
		this.player = GameObject.Find ("player");
		//追加
	}
	// Update is called once per frame
	void Update () {
		//フレームごとに等速で落下する
		transform.Translate (0, -0.1f, 0);
		//画面の外に出たらオブジェクトを破棄する
		if (transform.position.y < -5.0f) {
			Destroy (gameObject);
		}
		Vector2 p1 = transform.position; //矢の中心座標
		Vector2 p2 = this.player.transform.position;//プレイヤの中心座標
		Vector2 dir = p1-p2;
		float d = dir.magnitude;
		float r1 = 0.5f; //矢の半径
		float r2 = 1.0f;
		if (d < r1 + r2) {
			//衝突した矢は消す
			Destroy(gameObject);
			GameObject director = GameObject.Find ("GameDirector");
			director.GetComponent<GameDirector> ().DecreaseHp ();
		}
	}
}
