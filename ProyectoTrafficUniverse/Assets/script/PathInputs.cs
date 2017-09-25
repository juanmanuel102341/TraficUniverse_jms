
using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
public class PathInputs : MonoBehaviour {

	//pasa data del mousse al path
	private bool activatePath=false;
	private bool clickObj=false;
	private int contador=0;
	public Camera cameraGame;
	public Path_01 path;
	private ChangeColor colorObj;
	private PathManagment pathManagment;
	private bool over=false;
	void Awake () {
		path=new Path_01();
		colorObj=GetComponent<ChangeColor>();
		pathManagment=GetComponent<PathManagment>();
	}
	void Update () {
		print("mouse fuera "+over);
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
	private void Delete(){
		
		//over=false;
		if(path.listNodos.Count>0){
			colorObj.ColorIdle();
		}
		pathManagment.DeleteMyList();
		path.DeleteNodosPaths();
	}

}
