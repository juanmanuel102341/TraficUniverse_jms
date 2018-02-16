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
	private float magnitud;
	private MoveSoft moveSoft;
	private MyPath myPrincipalPath;
	private Vector2 playerPos;
	private float magnitudTotal;

	public Path(){

	}
	public Path (PathGraphic _graficPath,float _myConstrain,MyPath _myPath, float distanceNodes){
		pathGraphic=_graficPath;
		myPrincipalPath=_myPath;
		angleConstrain=new AngleConstrain(myPrincipalPath,_myConstrain);
		magnitud=distanceNodes;
		magnitudTotal=pathGraphic.getMagnitudLine+magnitud;
//		print("magn total "+magnitudTotal);
	}

	public void SetNewNode(Vector2 input){
		Vector2 vec;
		if(myPrincipalPath.getListVectors.Count>1){
			constrainActive=angleConstrain.InitializeCalcConstrain(input);
			if(Apply(input)&&!constrainActive){

				float px;
				float py;
				float hip;
				Vector2 vecR;
				Vector2 myVec; 
				vecR.x=Mathf.Abs(input.x-myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].x);//distancia en x desde el input en xal ultimo nodo
				vecR.y=Mathf.Abs(input.y-myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].y);//idem pero en y 
				hip=Vector2.Distance(input,myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1]);//saco distancia input a ultimo nodo
				px=vecR.x/hip;//proporcion en x con respecto a la distancia
				py=vecR.y/hip;// en y con respect a distancia
				if(input.x>myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].x){
					myVec.x=myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].x+magnitud*px*magnitud;//pregunto si el input esta a la derecha del utlimo node sino esta a la ixquierda para poder sumar o restar
				}else{
					myVec.x=myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].x-magnitud*px*magnitud;//multiplico x magnitud 2 veces porque sn el puntero y el path quedan un poco desfasados				
				}
				if(input.y>myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].y){
					myVec.y=myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].y+magnitud*py*magnitud;
				}else{
					myVec.y=myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1].y-magnitud*py*magnitud;
				}
				//	print("my vec "+myVec);
				SetList(myVec);

			}
		}else {
			first=true;
			constrainActive=false;
//			if(input.x>playerPos.x){
//				input.x=playerPos.x+0.6f;
//			}else{
//				input.x=playerPos.x-0.6f;
//			}
			SetList(input);
		}

	}

	private void Insert(Vector2 input){
		//Vector2 vec;
	
	}
	private void Check(Vector2 v1,Vector2 v2){
		float d=Vector2.Distance(v1,v2);
		//print("distance "+d);
		if(d>magnitud){
			SetNewNode(v2);
		//	print("entrando");
		}
	}
	private void SetList(Vector2 _vec){
		//lista vectores
		//Vector2 p1=new Vector2(0,0);
		//Vector2 p2;
		Node node;
		node=new Node(_vec);
		Vector2 vec1;
		Vector2 vec2;
		float angle;

		if(myPrincipalPath.getListVectors.Count!=0){
			Vector2 aux1= myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1];//ultimo node
			vec1=node.posicion-aux1;//vector diferencia entre posicion nodo potencial - nodo anterior o ultio

		}else{
			
			vec1=node.posicion-playerPos;
		}
		myPrincipalPath.InsertVector(node.posicion);
		GameObject obj=pathGraphic.SpawnGraphicPath(node.posicion,vec1);
	
		myPrincipalPath.InsertGraphics(obj);

	}

	private bool Apply(Vector2 _input){
		//	print("distnce "+d);
		Vector2 vec;
		float n;
		n=Vector2.Distance(_input,myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1]);
		if(n>magnitud){
			return true;
		}
		return false;
		}




	public void OnMouseUp(){
	//	print("hijo boton up");
		if(myPrincipalPath.getListVectors.Count>0){
			 
			myPrincipalPath.DeleteLastNode();
			GameObject lastNode=pathGraphic.SpawnGraphicLastNode(myPrincipalPath.getListVectors[myPrincipalPath.getListVectors.Count-1],myPrincipalPath);//genero el ultimo node y despues [athGraphic le paso la lista de objetos graficos
			if(myPrincipalPath.setlastNode!=null){
			//	print("setiando ultimo path anterior pos"+myPrincipalPath.setlastNode.GetComponent<Transform>().position);
				myPrincipalPath.setlastNode.GetComponent<ReplaceMe>().Replace();
			}
			myPrincipalPath.setlastNode=lastNode;
			myPrincipalPath.InsertGraphics(lastNode);
			myPrincipalPath.CalcLastNodeVectors();


		}
	}
	public void UpdatePlayerPos(Vector2 pos){
	//	print("player pos "+pos);
		playerPos=pos;

	}

}
