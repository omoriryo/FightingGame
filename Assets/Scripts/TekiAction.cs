﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TekiAction : MonoBehaviour {

	// 速度
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
		if(Input.GetKey("j")){
			// 代入したPositionに対して加算減算を行う
			Position.x -= SPEED.x;
		} else if(Input.GetKey("l")){ // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.x += SPEED.x;
		} else if(Input.GetKey("i")){ // 上キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.y += SPEED.y* 2;
		} else if(Input.GetKey("k")){ // 下キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.y -= SPEED.y;
		}
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = Position;
	}
}
