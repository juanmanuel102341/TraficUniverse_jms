
using UnityEngine;

public class DeactiveEvent : MonoBehaviour {
	public MyEvent myEvent;
	// Use this for initialization

	void Start () {
//		myEvent.finishing2+=DeactiveMe;	
	}

	public void DeactiveMe(){

			print("desactivando componente");
			gameObject.SetActive(false);

	}
}
