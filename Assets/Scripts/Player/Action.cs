using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {

	public GameObject punch;
	public Vector2 SPEED = new Vector2(0.1f, 0.1f);

	private bool isPunch = false;
	private bool isJump = false;
	private bool isPressed = false;
	private bool isDown = false;
	private Animator animator;
	private BoxCollider2D bc;
	private Rigidbody2D rb;
	float jumpForce = 350; //ジャンプ力
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		bc = GetComponent<BoxCollider2D>();
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		// 移動処理
		Move();
		Debug.Log (isPunch);
		if (isPunch) {
			if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Punch")) { // ここに到達直後はnormalizedTimeが"Default"の経過時間を拾ってしまうので、Resultに遷移完了するまではreturnする。
				return;
			} else {
				Vector2 Punch = transform.position;
				Punch.x += 1.6f;
				Punch.y += 0.4f;
				punch.transform.position = Punch;
				punch.SetActive (true);
			}
			if (animator.GetCurrentAnimatorStateInfo (0).normalizedTime < 1.0f)    // 待機時間を作りたいならば、ここの値を大きくする。
				return;
			isPunch = false;
		}
		if(!isPunch)
			punch.SetActive(false);
		if(!(Input.GetKey ("down")))
			isDown = false;
	}

	// 移動関数
	void Move(){
		// 現在位置をPositionに代入
		Vector2 Position = transform.position;
		// 左キーを押し続けていたら
		if (Input.GetKey ("left")) {
			// 代入したPositionに対して加算減算を行う
			if (!isDown) {
				Position.x -= SPEED.x;
				animator.SetBool ("isMove", true);
			}

		} else if (Input.GetKey ("right")) { // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			if (!isDown) {
				Position.x += SPEED.x;
				animator.SetBool ("isMove", true);
			}

		} else if (Input.GetKey ("up")) { // 上キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			if (!isJump) {
				isJump = true;
				rb.AddForce (Vector2.up * jumpForce);
				animator.SetBool ("isDown", true);
			}

		} else if (Input.GetKey ("down")) { // 下キーを押し続けていたら
			animator.SetBool ("isDown", true);
			isDown = true;
			if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Down")) {
				bc.offset = new Vector2 (0f, -0.5f);
				bc.size = new Vector2 (0.7f, 1f);
			}

		} else if (Input.GetKey ("p")) { // 下キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			if (!isPressed) {
				if (!isPunch) {
					isPressed = true;
					animator.SetTrigger ("Punch");
					isPunch = true;
					//punch.SetActive (false);
				}
			}
		} 

		else {
			animator.SetBool ("isDown", false);
			bc.offset = new Vector2 (0f,0f);
			bc.size = new Vector2 (0.7f,2f);
			animator.SetBool ("isMove", false);
			isPressed = false;
		}
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = Position;
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Ground") {
			isJump = false;
		}
	}
}
