using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame

		//左矢印が押されたとき
		public void LButtonDown() {
			transform.Translate ( -3, 0, 0);
			//左に動かす
		}
		//右矢印が押されたとき
		public void RButtonDown()  {
			transform.Translate (3, 0, 0);
		}//右に動かす

}
