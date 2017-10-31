using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path:PathInputs  {

	public List<Vector2>listNodes=new List<Vector2>();
	public MoveShip moveShip;
	private float distanceNodes;

	public Path(){
		
	}
	public Path (float _distanceNodes){
		distanceNodes=_distanceNodes;
		moveShip=new MoveShip();
	}
	public void Update(){
		moveShip.Update();

	}
	
	public bool SetNewNode(Vector2 input){
		if(listNodes.Count!=0){
			if(DistanceBetween(input)){
			//mas d uno
			Node node;
			node=new Node(input);
		
			moveShip.myListNodes.Add(node.posicion);		
			listNodes.Add(node.posicion);
		//		Debug.Log("cant nodes "+	moveShip.myListNodes.Count);
				//	moveShip.Update();
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

			listNodes.Add(node.posicion);

			moveShip.myListNodes.Add(node.posicion);
		//	Debug.Log("cant nodes "+	moveShip.myListNodes.Count);
			moveShip.myVector=moveShip.CalcVectorUp();

		//	Debug.Log("first vector path"+moveShip.myVector);
			//moveShip.Update();
			//Debug.Log("promer node "+node.posicion);
			return true;
		}
	
	}


	private bool DistanceBetween(Vector2 _input){
		float d=Vector2.Distance(listNodes[listNodes.Count-1],_input);//distancia entre el nodo q hay y el input del mouse
		if(d>distanceNodes||d==0){
			//la igualo a 0 asi n se complica el codigo en how to play, ya q la cantidad d nodos lo establezco con otra condicion no por distancia entre elloss
			return true;
		}
		return false;
	}

	public void Delete(){
//		Debug.Log("borrando path");
		if(listNodes.Count>0){
		//	Debug.Log("borrando nodos "+listNodes.Count);
			listNodes.RemoveRange(0,listNodes.Count);
	
		}
//		MethodPapa();
		moveShip.DeleteMyList();
//		Debug.Log("nodos codigo "+listNodes.Count);
	
	}

}
