using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour {
	private bool active=false;
	// Use this for initialization
	float t=0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		t+=Time.deltaTime;
		if(active==false)
		{
			transform.Translate(Vector2.up*1*Time.deltaTime);
		}
	
		if(t>4){
			active=true;
		}
	}
}
