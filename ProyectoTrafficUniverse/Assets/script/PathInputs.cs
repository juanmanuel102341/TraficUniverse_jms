
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
	public float distanceNodes;
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
		colorObj.ColorActive();
		if(path.listNodes.Count>0){
		Vector2 vecFinal=movePath.getCurrentVector;//vector q viene de movePath , osea es el vector en el q estaba hasta q hizo el click
		move.getFinalVec=vecFinal;
		}
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
		//si el jugador clickea encima "xra q n se genere ningun path" para eso este booleano
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
		Vector2 auxInput=GetPositionMouse();
		if(Input.GetMouseButton(0)&&clickObj&&activatePath&&!over){
			if(path.SetNewNode(auxInput))//genero un nuevo nodo parte codigo
			{//si se inserta un nodo se crea el respectivo grafico
					pathGraphic.SpawnGraphicPath(auxInput);
			
			}
		}
	}
	public void Delete(){
		print("borrando "+path.listNodes.Count);
		//over=false;
		if(path.listNodes.Count>0){
			colorObj.ColorIdle();
		}
	
		pathGraphic.Delete_ngraphics();
		path.Delete();
	}


}
