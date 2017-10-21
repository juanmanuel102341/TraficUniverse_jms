using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMyPosition : MonoBehaviour {

	private Vector2 pos;
	void Update () {
		transform.position=pos;
	}
	public Vector2 MyPos{
		set{
			pos=value;
		}
	}
}
