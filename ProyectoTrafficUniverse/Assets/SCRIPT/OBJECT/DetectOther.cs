using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOther : MonoBehaviour {
	//public PathInputs pathInputs;
	// Use this for initialization
	private bool click=false;
	// Update is called once per frame
	//public GameObject id;
	void OnMouseDown(){
		
		print("click desde detect OTHERRRRRRRRR");
	//	id.SetActive(true);
		click=true;
	}
	public bool getMyClick{

		get{
			return click;
		}

	}
}
