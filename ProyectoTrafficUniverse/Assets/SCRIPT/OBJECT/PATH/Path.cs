using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path  {

	public List<Node>listNodes=new List<Node>();

	private float distanceNodes;

	public Path (float _distanceNodes){
		distanceNodes=_distanceNodes;
	}
	
	public bool SetNewNode(Vector2 input){
		if(listNodes.Count!=0){
			if(DistanceBetween(input)){
			//mas d uno
			Node node;
			node=new Node(input);
			listNodes.Add(node);
				//Debug.Log("creacion nodo "+node.posicion);
				return true;
			}else{
				//Debug.Log("nodo n cumple condicion ");
				return false;
			}
		}else{
			
			//igual a 0
			Node node;
			node=new Node(input);
			listNodes.Add(node);
			//Debug.Log("promer node "+node.posicion);
			return true;
		}
	
	}


	private bool DistanceBetween(Vector2 _input){
		float d=Vector2.Distance(listNodes[listNodes.Count-1].posicion,_input);//distancia entre el nodo q hay y el input del mouse
		if(d>distanceNodes||d==0){
			//la igualo a 0 asi n se complica el codigo en how to play, ya q la cantidad d nodos lo establezco con otra condicion no por distancia entre elloss
			return true;
		}
		return false;
	}

	public void Delete(){
		if(listNodes.Count>0){
		//	Debug.Log("borrando nodos "+listNodes.Count);
			listNodes.RemoveRange(0,listNodes.Count);
	
		}
//		Debug.Log("nodos codigo "+listNodes.Count);
	
	}

}
