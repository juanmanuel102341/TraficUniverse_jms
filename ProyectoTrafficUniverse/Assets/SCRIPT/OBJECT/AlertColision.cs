﻿
using UnityEngine;

public class AlertColision : MonoBehaviour {
	private string id;
	public GameObject sprite;
	public GameObject objColision;
	private CheckTargetColision checkTarget;
	public delegate void ColisionInminent();
	public event ColisionInminent onAlertColsion;
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
			onAlertColsion();
		}
		if(checkTarget.CheckMyTarget(col.tag)){
			if(col.tag=="asteroide")
			sprite.SetActive(true);//activo carte de sprite attention
			//print("prendo collider para un posible aterrizaje");
			objColision.SetActive(true);
			onAlertColsion();
		}
			
	}

	void OnTriggerExit2D(Collider2D col){
		print("exit");
		if(sprite.gameObject.activeSelf)
		sprite.SetActive(false);

		objColision.SetActive(false);
	}


}
