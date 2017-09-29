using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {
	private bool limite=false;
	private Camera cameraGame;
	private float widthScene;
	private float heightScene;
	private float widthObj;
	private float heightObj;
	void Awake () {
		//camara tiene q estar poscionada en (0,0)!!!
		cameraGame=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		//cameraGame.ScreenToWorldPoint(
		print ("camera "+cameraGame.orthographicSize);
		heightScene=cameraGame.orthographicSize;//alto de la camara 
		widthScene=cameraGame.aspect*cameraGame.orthographicSize;//ancho del tama;o d la camara multiplicado por la razon del ancho divido height(en mi caso 16/9)
		widthObj=GetComponent<SpriteRenderer>().bounds.extents.x;//ancho del objeto dividido 2
		heightObj=GetComponent<SpriteRenderer>().bounds.extents.y;//alto div2
		print("height "+heightScene);
		print("width "+widthScene);
	
		print("width obj "+widthObj);
		print("alto obj "+heightObj);
	}
	

	void Update () {
		if(AxisX()||AxisY()){
			print("limite activo");
			limite=true;		
		}else{
			limite=false;
		}
	}


	private bool AxisX(){
		if(transform.position.x+widthObj>widthScene||transform.position.x-widthObj<-widthScene){

			return true;
		}
		return false;
	}
	private bool AxisY(){
		if(transform.position.y+heightObj>heightScene||transform.position.y-heightObj<-heightScene){
			return true;
		}
		return false;
	}

	public bool limiteActive{
		get {
			return limite;
		}
	}



}

