using UnityEngine;
using System.Collections;
using MonobitEngine;
using System;

public class InstantiatePlayer : MonobitEngine.MonoBehaviour {

	// 自身がルームに入室を試みたかどうかのフラグ
	bool isJoinOrCreateRoom = false;

	// 自身のプレイヤーキャラクタが生成されたかどうかのフラグ
	bool isMakeMyPlayer = false;
	// Use this for initialization
	void Start () {
		// MUNサーバに接続する
		MonobitNetwork.autoJoinLobby = true;
		MonobitNetwork.ConnectServer("v0.1.1");
	}

	// Update is called once per frame
	void Update () {
		// 未接続状態なら何もしない
		if (!MonobitNetwork.isConnect)
		{
			return;
		}
		// ルーム入室処理未実行であれば、ルームの作成or入室をする
		if (!isJoinOrCreateRoom)
		{
			MonobitNetwork.JoinOrCreateRoom("MonobitTest", new RoomSettings(), null);
			isJoinOrCreateRoom = true;
			return;
		}
		// ルーム入室済みでキャラクタ未生成であれば、キャラクタを生成する
		if(MonobitNetwork.inRoom && !isMakeMyPlayer)
		{
			MonobitNetwork.Instantiate ("Player", Vector3.zero, Quaternion.identity, 0);
			isMakeMyPlayer = true;
			return;
		}
	}
}
