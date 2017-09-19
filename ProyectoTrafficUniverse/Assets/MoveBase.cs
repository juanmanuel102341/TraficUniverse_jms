using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour {
	private Rigidbody2D rb;
	// Use this for initialization
	void Awake () {
		rb=GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.transform.Translate(Vector2.up*1*Time.deltaTime);
	}
}
