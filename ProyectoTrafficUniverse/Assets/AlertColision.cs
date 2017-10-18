
using UnityEngine;

public class AlertColision : MonoBehaviour {
	private string id;
	// Use this for initialization
	void Awake () {
		id=gameObject.tag;
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag=="colisionArea"&&id=="colisionArea"){
		print("area");
		}
		
	}
}
