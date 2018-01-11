using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path:PathInputs  {


	public AngleConstrain angleConstrain;
	private float my_distanceNodes;

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
		myPrincipalPath=_myPath;
		angleConstrain=new AngleConstrain(myPrincipalPath,_myConstrain);
	
		}

	public void SetNewNode(Vector2 input){
		Vector2 vec;
		if(myPrincipalPath.getListVectors.Count>1){

			if(Apply(input)&&!constrainActive){

				float px;
				float py;
				float hip;
				Vector2 vecR;
				Vector2 myVec; 
				vecR.x=Mathf.Abs(input.x-myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].x);
				vecR.y=Mathf.Abs(input.y-myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].y);
				hip=Vector2.Distance(input,myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1]);
				px=vecR.x/hip;
				py=vecR.y/hip;
				if(input.x>myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].x){
					myVec.x=myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].x+magnitud*px*magnitud;
				}else{
					myVec.x=myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].x-magnitud*px*magnitud;				
				}
				if(input.y>myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].y){
					myVec.y=myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].y+magnitud*py*magnitud;
				}else{
					myVec.y=myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].y-magnitud*py*magnitud;
				}
				//	print("my vec "+myVec);
				SetList(myVec);
				//constrainActive=angleConstrain.InitializeCalcConstrain(input);
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
		myPrincipalPath.InsertVector(node.posicion);
		GameObject obj=pathGraphic.SpawnGraphicPath(node.posicion);
		myPrincipalPath.InsertGraphics(obj);

	}

	private bool Apply(Vector2 _input){
	//	print("distnce "+d);
		if(myPrincipalPath.getListVectors.Count>1){
				Vector2 vec;
				float n;
			n=Vector2.Distance(_input,myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1]);
				if(n>magnitud){
						return true;
				}
					return false;
		}
		return true;
	}

	public void OnMouseUp(){
	//	print("hijo boton up");
		if(myPrincipalPath.getListVectors.Count>0){
			 
			myPrincipalPath.DeleteLastNode();
			GameObject lastNode=pathGraphic.SpawnGraphicLastNode(myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1],myPrincipalPath);//genero el ultimo node y despues [athGraphic le paso la lista de objetos graficos
			myPrincipalPath.InsertGraphics(lastNode);
			//print("ultimo nodo "+listNodes[listNodes.Count-1]);
		}
	}

}
