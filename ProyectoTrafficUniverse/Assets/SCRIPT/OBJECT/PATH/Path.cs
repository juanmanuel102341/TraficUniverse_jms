using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path:PathInputs  {

	public List<Vector2>listNodes=new List<Vector2>();
	private AngleConstrain angleConstrain;
	private float my_distanceNodes;
	public int countNodes=0;
	public bool first=false;
	private PathGraphic pathGraphic;
	private bool constrainActive=false;
	private float distanceNodesGraphic;
	private float widthNode;
	private float magnitud=1.7f;
	public Path(){

	}
	public Path (float _distanceNodes,PathGraphic _graficPath,float _myConstrain, float _distanceNodesGraphic){
		my_distanceNodes=_distanceNodes;
		//Debug.Log("distance nodes "+my_distanceNodes);
		pathGraphic=_graficPath;
		distanceNodesGraphic=_distanceNodesGraphic;
		angleConstrain=new AngleConstrain(this,_myConstrain);
		print("distancia nodes "+my_distanceNodes);
		//widthNode=_graficPath.graphicPath.GetComponent<Transform>().localScale.x;
		//print("size node "+widthNode);
	}
	public void SetNewNode(Vector2 input){
		SetNodes(input);
//		float distanceNodes=0;
//
//		if(listNodes.Count!=0){
//			
//
//			print("node 1 "+listNodes[listNodes.Count-1]);
//			print("node 2 "+input);
//		//	distanceNodes=listNodes[listNodes.Count-1].x;
//			float n=input.x-listNodes[listNodes.Count-1].x;
//			n=Mathf.Abs(n);
//			distanceNodes+=n;
//			print("distance "+distanceNodes);
//
//			//mas d uno
//			//	if(!constrainActive)
//			//	constrainActive=angleConstrain.InitializeCalcConstrain(input);
//			//	if(!constrainActive){
//				if(distanceNodes>=1.5f)
//				{
//					Node node;
//				node=new Node(input);
//				listNodes.Add(node.posicion);
//				countNodes++;
//					distanceNodes=0;
//					pathGraphic.SpawnGraphicPath(node.posicion);
//				}
////				if(pathGraphic!=null)
////					{
////						Vector2 aux1=listNodes[listNodes.Count-2];
////						Vector2 aux2=listNodes[listNodes.Count-1];
////						print("node 1 "+aux1);
////						print("node 2 "+aux2);
////						float d=Vector2.Distance(aux1,aux2);
////						print("distancia "+d);
//////						if(d>distanceNodesGraphic)
////					pathGraphic.SpawnGraphicPath(node.posicion);
////					}
//						//	print("click") ;
//				return true;
//			//}else{
//				//Debug.Log("nodo n cumple condicion ");
//			//	return false;
//			//}
//			
//		}else{
//			//igual a 0
//			Node node;
//			node=new Node(input);
//			if(pathGraphic!=null)
//			pathGraphic.SpawnGraphicPath(node.posicion);
//			//Debug.Log("click") ;
//			listNodes.Add(node.posicion);
//			countNodes++;
//			first=true;
//			constrainActive=false;
//
//			return true;
//		}
//		
	}


	private void SetNodes(Vector2 _input){
		Vector2 vec;
		if(listNodes.Count>1){

			if(Apply(_input)&&!constrainActive){
			
				float px;
				float py;
				float hip;
				Vector2 vecR;
				Vector2 myVec; 
				vecR.x=Mathf.Abs(_input.x-listNodes[listNodes.Count-1].x);
				vecR.y=Mathf.Abs(_input.y-listNodes[listNodes.Count-1].y);
				hip=Vector2.Distance(_input,listNodes[listNodes.Count-1]);
				px=vecR.x/hip;
				py=vecR.y/hip;
							if(_input.x>listNodes[listNodes.Count-1].x){
							myVec.x=listNodes[listNodes.Count-1].x+magnitud*px*magnitud;
							}else{
								myVec.x=listNodes[listNodes.Count-1].x-magnitud*px*magnitud;				
							}
							if(_input.y>listNodes[listNodes.Count-1].y){
							myVec.y=listNodes[listNodes.Count-1].y+magnitud*py*magnitud;
							}else{
								myVec.y=listNodes[listNodes.Count-1].y-magnitud*py*magnitud;
							}
							print("my vec "+myVec);
				SetList(myVec);
				constrainActive=angleConstrain.InitializeCalcConstrain(_input);
					}
			}else {
					first=true;
					constrainActive=false;
					SetList(_input);
				}
		}
	private void SetList(Vector2 _vec){
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
		if(pathGraphic!=null)
		pathGraphic.Delete_ngraphics();
		countNodes=0;
	angleConstrain.setCounting=0;
	}
	public void DeleteMyElementlist(){
		listNodes.Remove(listNodes[0]);
		countNodes--;
	angleConstrain.setCounting--;

		pathGraphic.DeleteFirstElementGraphic();
//		Debug.Log("borrando node "+listNodes.Count);
	}
//	public bool SettingConstrain{
//		set{
//			constrainActive=value;
//		}
//	}

}
