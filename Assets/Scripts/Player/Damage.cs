using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
	
	public GameObject hpbar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){

		//  on damage
//		if(col.gameObject.tag == "enemy"){
//			hpbar.gameObject.SendMessage("onDamage", 0.1);
//		}
		if(col.gameObject.tag == "punch"){
			hpbar.gameObject.SendMessage("onDamage", 0.1);
		}
	}
}
