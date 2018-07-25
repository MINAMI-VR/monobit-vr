using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonobitEngine.MonoBehaviour {
	public GameObject Target;
	public string TargetName;
	// Use this for initialization
	void Start () {
		if (!monobitView.isMine) {
			return;
		}
		Target = GameObject.Find (TargetName);
	}
	
	// Update is called once per frame
	void Update () {
		if (!monobitView.isMine) {
			return;
		}
		transform.position = Target.transform.position;
		transform.rotation = Target.transform.rotation;
	}
}
