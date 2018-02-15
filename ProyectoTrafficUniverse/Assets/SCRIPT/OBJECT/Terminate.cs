using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void FinalExplosion(){
		print("fin explosion");
		Destroy(this.gameObject);
	}
}
