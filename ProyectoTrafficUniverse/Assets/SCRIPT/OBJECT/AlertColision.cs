
using UnityEngine;

public class AlertColision : MonoBehaviour {
	private string id;
	public GameObject sprite;
	public GameObject objColision;
	private CheckTargetColision checkTarget;
	void Awake () {
		id=gameObject.tag;
		objColision.SetActive(false);

		sprite.SetActive(false);
		checkTarget=GetComponent<CheckTargetColision>();

	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag=="colisionRed"||col.gameObject.tag=="colisionBlue"||col.gameObject.tag=="colisionGreen"){
			print("area colsion activa");
			objColision.SetActive(true);
			sprite.SetActive(true);

		}
		if(checkTarget.CheckMyTarget(col.tag)){
		
			print("prendo collider para un posible aterrizaje");
			objColision.SetActive(true);
		}
		
	}

	void OnTriggerExit2D(Collider2D col){
		print("exit");
		sprite.SetActive(false);
		objColision.SetActive(false);
	}


}
