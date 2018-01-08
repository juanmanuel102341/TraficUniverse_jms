using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path:PathInputs  {

	public List<Vector2>listNodes=new List<Vector2>();
	public AngleConstrain angleConstrain;
	private float my_distanceNodes;
	public int countNodes=0;
	public bool first=false;
	public PathGraphic pathGraphic;
	private GameObject mylastNode;
	private bool constrainActive=false;
	private float magnitud=1.7f;
	private MoveSoft moveSoft;
	private MyPath myPrincipalPath;
	public Path(){

	}
	public Path (PathGraphic _graficPath,float _myConstrain,MyPath _myPath){
		pathGraphic=_graficPath;

		angleConstrain=new AngleConstrain(this,_myConstrain);
		myPrincipalPath=_myPath;


	}

	public void SetNewNode(Vector2 input){
		Vector2 vec;
		if(listNodes.Count>1){

			if(Apply(input)&&!constrainActive){

				float px;
				float py;
				float hip;
				Vector2 vecR;
				Vector2 myVec; 
				vecR.x=Mathf.Abs(input.x-listNodes[listNodes.Count-1].x);
				vecR.y=Mathf.Abs(input.y-listNodes[listNodes.Count-1].y);
				hip=Vector2.Distance(input,listNodes[listNodes.Count-1]);
				px=vecR.x/hip;
				py=vecR.y/hip;
				if(input.x>listNodes[listNodes.Count-1].x){
					myVec.x=listNodes[listNodes.Count-1].x+magnitud*px*magnitud;
				}else{
					myVec.x=listNodes[listNodes.Count-1].x-magnitud*px*magnitud;				
				}
				if(input.y>listNodes[listNodes.Count-1].y){
					myVec.y=listNodes[listNodes.Count-1].y+magnitud*py*magnitud;
				}else{
					myVec.y=listNodes[listNodes.Count-1].y-magnitud*py*magnitud;
				}
				//	print("my vec "+myVec);
				SetList(myVec);
				constrainActive=angleConstrain.InitializeCalcConstrain(input);
			}
		}else {
			first=true;
			constrainActive=false;
			SetList(input);
		}

	}

	private void SetList(Vector2 _vec){
		//lista vectores
		Node node;
		node=new Node(_vec);
		listNodes.Add(node.posicion);
		pathGraphic.SpawnGraphicPath(node.posicion);
		countNodes++;
	}

	private bool Apply(Vector2 _input){
	//	print("distnce "+d);
		if(listNodes.Count>1){
				Vector2 vec;
				float n;
				n=Vector2.Distance(_input,listNodes[listNodes.Count-1]);
				if(n>magnitud){
						return true;
				}
					return false;
		}
		return true;
	}

	public void Delete(){
//		Debug.Log("borrando path");
		if(listNodes.Count>0){
		//	Debug.Log("borrando nodos "+listNodes.Count);
			listNodes.RemoveRange(0,listNodes.Count);
		}
		if(pathGraphic!=null){
		pathGraphic.Delete_ngraphics();
		countNodes=0;
		angleConstrain.setCounting=0;
		}
	}
	public void DeleteMyElementlist(){
//		print("borrando node");
		listNodes.Remove(listNodes[0]);
		countNodes--;
		angleConstrain.setCounting--;
		pathGraphic.DeleteFirstElementGraphic();
//		Debug.Log("borrando node "+listNodes.Count);
	}
	public void ResetValuesList(){
	
		countNodes=0;
		angleConstrain.setCounting=0;
		listNodes.RemoveRange(0,listNodes.Count);

	}
	public void OnMouseUp(){
	//	print("hijo boton up");
		if(listNodes.Count>0){
		pathGraphic.DeleteLastNode();	
		pathGraphic.SpawnGraphicLastNode(listNodes[listNodes.Count-1],myPrincipalPath);//genero el ultimo node y despues [athGraphic le paso la lista de objetos graficos
			myPrincipalPath.InsertPath(this);
			//print("ultimo nodo "+listNodes[listNodes.Count-1]);
		}
	}

}
