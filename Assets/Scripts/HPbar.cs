using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour {

	public Image RedGage;
	public Image GreenGage;
	private float Damage;
	// Use this for initialization
	void Start ()
	{
		Damage = 1;
	}
	// Update is called once per frame
	void Update ()
	{
		if(GreenGage.fillAmount < RedGage.fillAmount){
			RedGage.fillAmount -= 0.01f;
		}
	}

	void onDamage(float damage)
	{
		//Debug.Log ("Damage");
		Damage -= damage;
		if(Damage <= 0){
			Damage = 0;
		}
		GreenGage.fillAmount = Damage;
	}

}
