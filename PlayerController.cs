using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rigid2D;
	float jumpForce = 680.0f;
	float walkForce = 30.0f;
	float maxwalkSpeed=2.0f;
	float threshod =0.2f;
	Animator animator;

	// Use this for initialization
	void Start () {
		this.rigid2D = GetComponent<Rigidbody2D> ();
		this.animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//ジャンプする
		if (Input.GetMouseButtonDown(0)) {
			this.rigid2D.AddForce (transform.up * this.jumpForce);
		}
		//左右移動
		int key=0;
		if (Input.acceleration.x>this.threshod) key = 1;
		if (Input.acceleration.x< this.threshod)key = -1;

		//プレイヤの速度
		float speedx =Mathf.Abs(this.rigid2D.velocity.x);

		//スピードの制限
		if (speedx < maxwalkSpeed) {
			this.rigid2D.AddForce (transform.right * key * this.walkForce);
		}

		//体の向きをかえる
		if (key != 0) {
			transform.localScale = new Vector3 (key, 1, 1);
		}

		//プレイヤの速度に応じてアニメーション速度を変える
		this.animator.speed = speedx / 2.0f;

		if (transform.position.y < -10) {
			SceneManager.LoadScene ("GameScene");
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("ゴール");
		SceneManager.LoadScene ("clearScene");
	}
	//画面外にでた場合は最初から

}
