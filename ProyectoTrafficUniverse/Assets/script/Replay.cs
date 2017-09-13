using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour {
	public delegate void ReplayGame();
	public static event ReplayGame activateReplay;

	void Awake () {
		
	}
	

	void Update () {
		//ReplayMethod();
	}
	public void ReplayMethod(){
		print("replay ");
		activateReplay();
	}
}
