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
	void Awake () {
		cameraGame=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		path=new Path();
		colorObj=GetComponent<ChangeColor>();
		pathGraphic=GetComponent<PathGraphic>();
		movePath=GetComponent<MovePath>();
	}
	void Update () {
//		print("cantidad d nodos"+path.listNodos.Count);
		GetInputMouse();
	}
	// Update is called once per frame
	void OnMouseDown(){
		colorObj.ColorActive();

		Delete();
		contador++;
		if(!clickObj){
			print("clickevento");
			clickObj=true;
		}
		if(!activatePath&&contador>1){
			print("activate path");
			activatePath=true;
		}
		movePath.setIndex=0;
	}
	void OnMouseUp(){
		if(activatePath){
			print("reset paths inputs");
			activatePath=false;
			clickObj=false;
			contador=0;
		}

	}
	void OnMouseOver(){
		over=true;
	
	
	}
	void OnMouseExit(){
		over=false;
		print("mouse fuera");
	}
	private Vector2 GetPositionMouse(){
		//	print("CLICKmOUSE");
		Vector2 aux;
		aux=Input.mousePosition;
		aux=cameraGame.ScreenToWorldPoint(aux);
		return aux;

	}
	public void GetInputMouse(){
		if(Input.GetMouseButton(0)&&clickObj&&activatePath&&!over){
			path.GeneratePath(GetPositionMouse());
		}
	}
	public void Delete(){
		print("borrando");
		//over=false;
		if(path.listNodos.Count>0){
			colorObj.ColorIdle();
		}
		pathGraphic.Delete_ngraphics();
		path.Delete();
	}

	public PathGraphic getPathGraphic{
		get{
			return pathGraphic;
		}
	}
	 
}