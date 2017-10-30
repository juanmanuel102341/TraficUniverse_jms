using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : Path {

	public int contadorNodes=0;
	public Vector2 playerPos2;
		public List<Vector2>myListNodes=new List<Vector2>();
	public Vector2 myVector;
	public bool active=false;
	//public bool finalNode=false;
	public bool limit_active=false;
	private int contadorTotalNodes=0;
	public bool finalNode2=false;
	private bool clearNodes=false;
	public MoveShip(){
		myVector.x=0;
		myVector.y=1;
		//Debug.Log("clase princepsm "+_distanceNodes);
	}
	public void Update () {
		
		if(!limit_active){
			if(myListNodes.Count>0){
				print("list nodes desde my move "+listNodes.Count);
				if(ReachPathPosition()&&!finalNode2){
					
			DeleteMyElementList();
			if(myListNodes.Count>0)
			myVector=CalcVectorUp();
			
			if(myListNodes.Count==1){
			finalNode2=true;
			
			}
			Debug.Log("contadorNodesReach "+myListNodes.Count);
					//Debug.Log("changing my vector "+myVector);
			
			}else if(finalNode2){
					//legaste al final
					Debug.Log("final path");
				//DeleteMyElementList();
						DeleteMyList();
				
					
						finalNode2=false;
					}
			}
		}else{
			myVector*=-1;
			finalNode2=true;
			limit_active=false;
		}
	}
	public Vector2 CalcVectorUp(){
		
		active=true;
		Vector2 aux=myListNodes[0]-playerPos2;
		return aux;
	}

	private bool ReachPathPosition(){
		if(Vector2.Distance(myListNodes[0],playerPos2)<=0.1f){
//			Debug.Log("cambio d nodo distancia 0");
			return true;
		}
			return false;	
	}

	private bool FinalPath(){
		if(contadorNodes!=0&&contadorNodes==myListNodes.Count){
			return true;
		}
		return false;
	}
	public void DeleteMyList(){
		
		myListNodes.RemoveRange(0,myListNodes.Count);

	}
	public void DeleteMyElementList(){
		myListNodes.Remove(myListNodes[0]);
		//contadorNodes--;
	}
	public bool finalNode{
		get{
			return finalNode2;
		}
		set{
			finalNode2=value;
		}

	}
		

}
