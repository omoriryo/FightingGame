using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	//PlayerBase[] players;
	public static bool isBlackTurn;
	public static int Result = 0;
	bool isEnd = true;
	public static int TrunNum;
	public AudioClip PutSound;

	void Awake ()
	{
		//********** 開始 **********// 
		//ゲーム開始時にGameManagerをinstanceに指定
		if (instance == null) {
			instance = this;
			//このオブジェクト以外にGameManagerが存在する時
		} else if (instance != this) {
			//このオブジェクトを破壊する
			Destroy(gameObject);
		}
		//シーン遷移時にこのオブジェクトを受け継ぐ
		DontDestroyOnLoad(gameObject);
		//********** 終了 **********// 
	}

	 //Update is called once per frame
	void Update () {
	} 
}