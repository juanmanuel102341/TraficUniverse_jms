
using UnityEngine;

public class FrontierDetection : MonoBehaviour {
	
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col){
		print("contacto frontier");
		//col.gameObject.GetComponent<Bounds>().limiteActive=true;
	
	}
}
