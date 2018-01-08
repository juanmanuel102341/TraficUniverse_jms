using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMoveSoft : MonoBehaviour {
	private PathInputs myPath;
	// Use this for initialization
	private MoveSoft moveSoft;
	void Awake () {
//		myPath=GetComponent<PathInputs();
	}
	public MoveSoft setMoveSoft{
		set{
			moveSoft=value;
		}
	}


}
