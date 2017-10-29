
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PathInputs : MonoBehaviour {

	//pasa data del mousse al path
	private bool activatePath=false;
	private bool clickObj=false;
	private int contador=0;
	private Camera cameraGame;
	public Path path;
	
	private PathGraphic pathGraphic;
	private bool over=false;
//	private MovePath2 movePath;
//	private Move move;
	public float distanceNodes;//distancia o frecuancia d calculo
	public GameObject id;
	protected Vector2 playerPos;

	protected List<Vector2>listNodesVec=new List<Vector2>();
	protected void Awake () {
		cameraGame=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		path=new Path(distanceNodes);

	
		pathGraphic=GetComponent<PathGraphic>();
//		movePath=GetComponent<MovePath2>();
//		move=GetComponent<Move>();	
		id.SetActive(false);
		print("clase path inputs");
	}


	protected void Update () {
//		print("cantidad d nodos"+path.listNodos.Count);

		path.Update();
	
		GetInputMouse();
	}
	// Update is called once per frame
	void OnMouseDown(){
		//colorObj.ColorFirstClick();
		id.SetActive(true);
		Delete();
		contador++;
		if(!clickObj){
			//***********primer click*******************
			//print("clickevento");
			clickObj=true;
//			movePath.ResetListNodes();
		}
		if(!activatePath&&contador>1){
		//**************segundo click******************
			//print("activate path");
			activatePath=true;
			//colorObj.ColorSecondClick();
		}

//		movePath.setIndex=0;
	}
	void OnMouseUp(){
		if(activatePath){
			//*****************usuario suelta boton para dibujar el path**********************
			//print("reset paths inputs");
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
		print("dekete path nputs");	
		pathGraphic.Delete_ngraphics();
		path.Delete();
	}
//	protected void MethodPapa(){
//		pathGraphic.Delete_ngraphics();
//		print("metodo papa inputs");
//	}


}
