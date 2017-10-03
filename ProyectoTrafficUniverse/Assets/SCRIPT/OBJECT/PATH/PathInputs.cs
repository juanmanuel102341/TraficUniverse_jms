﻿
using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
public class PathInputs : MonoBehaviour {

	//pasa data del mousse al path
	private bool activatePath=false;
	private bool clickObj=false;
	private int contador=0;
	private Camera cameraGame;
	public Path path;
	private ChangeColor colorObj;
	private PathGraphic pathGraphic;
	private bool over=false;
	private MovePath movePath;
	private Move move;
	public float distanceNodes;//distancia o frecuancia d calculo
	void Awake () {
		cameraGame=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		path=new Path(distanceNodes);
		colorObj=GetComponent<ChangeColor>();
		pathGraphic=GetComponent<PathGraphic>();
		movePath=GetComponent<MovePath>();
		move=GetComponent<Move>();	
	}
	void Update () {
//		print("cantidad d nodos"+path.listNodos.Count);
		GetInputMouse();
	}
	// Update is called once per frame
	void OnMouseDown(){
		colorObj.ColorFirstClick();
		if(path.listNodes.Count>0){
		Vector2 vecFinal=movePath.getCurrentVector;//vector q viene de movePath , osea es el vector en el q estaba hasta q hizo el click
		move.getFinalVec=vecFinal;
		}
		Delete();
		contador++;
		if(!clickObj){
			//***********primer click*******************
			//print("clickevento");
			clickObj=true;
			colorObj.ColorFirstClick();
		}
		if(!activatePath&&contador>1){
		//**************segundo click******************
			//print("activate path");
			activatePath=true;
			colorObj.ColorSecondClick();
		}

		movePath.setIndex=0;
	}
	void OnMouseUp(){
		if(activatePath){
			//*****************usuario suelta boton para dibujar el path**********************
			//print("reset paths inputs");
			activatePath=false;
			clickObj=false;
			contador=0;
			colorObj.MyColor();
		}

	}
	void OnMouseOver(){
		//si el jugador clickea encima "xra q n se genere ningun path" para eso este booleano
		over=true;
	
	
	}
	void OnMouseExit(){
		over=false;
		//print("mouse fuera");
	}
	private Vector2 GetPositionMouse(){
		//	print("CLICKmOUSE");
		Vector2 aux;
		aux=Input.mousePosition;
		aux=cameraGame.ScreenToWorldPoint(aux);
		return aux;

	}
	public void GetInputMouse(){
		Vector2 auxInput=GetPositionMouse();
		if(Input.GetMouseButton(0)&&clickObj&&activatePath&&!over){
			path.SetNewNode(auxInput);//parte codigo
			pathGraphic.SpawnGraphicPath(auxInput);//parte grafica

		}
	}
	public void Delete(){
			
		pathGraphic.Delete_ngraphics();
		path.Delete();
	}


}