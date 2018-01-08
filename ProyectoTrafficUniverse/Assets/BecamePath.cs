
using UnityEngine;

public class BecamePath : MonoBehaviour {
	private PathInputs pathInputs;
	// Use this for initialization
	void Awake(){
		pathInputs=GetComponent<PathInputs>();
	}
	void Start(){
		
	}
//	void SetMyEvent(GameObject obj){
//		obj.GetComponent<MoveSoft>().changePath+=change;
//
//	}

//	void change(MoveSoft moveSoft){
//		print("getting my move soft");
//	}

}
