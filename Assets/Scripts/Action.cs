using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {

	public Vector2 SPEED = new Vector2(0.1f, 0.1f);
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		// 移動処理
		Move();
	}

	// 移動関数
	void Move(){
		// 現在位置をPositionに代入
		Vector2 Position = transform.position;
		// 左キーを押し続けていたら
		if (Input.GetKey ("left")) {
			// 代入したPositionに対して加算減算を行う
			Position.x -= SPEED.x;
			GetComponent<Animator> ().SetBool ("isMove", true);
		} else if (Input.GetKey ("right")) { // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.x += SPEED.x;
			GetComponent<Animator> ().SetBool ("isMove", true);
		} else if (Input.GetKey ("up")) { // 上キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.y += SPEED.y * 2;
			GetComponent<Animator> ().SetBool ("isDown", true);
		} else if (Input.GetKey ("down")) { // 下キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			//Position.y -= SPEED.y;
			GetComponent<Animator> ().SetBool ("isDown", true);
		} else if (Input.GetKey ("p")) { // 下キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			//Position.y -= SPEED.y;
			GetComponent<Animator> ().SetTrigger("Punch");
		}  
		else {
			GetComponent<Animator> ().SetBool ("isDown", false);
			GetComponent<Animator> ().SetBool ("isMove", false);
		}
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = Position;
	}
}
