
using UnityEngine;

public class AlertColision : MonoBehaviour {
	private string id;
	public GameObject sprite;



	void Awake () {
		id=gameObject.tag;
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag=="colisionArea"&&id=="colisionArea"){
		print("area");
		sprite.SetActive(true);
		
		}
		
	}
	void OnTriggerExit2D(Collider2D col){
		print("exit");
		sprite.SetActive(false);
	
	}
	void OnTriggerStay2D(Collider2D col){
		print("stay");
	}

}
