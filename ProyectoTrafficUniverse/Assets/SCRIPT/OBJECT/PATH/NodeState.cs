﻿
using UnityEngine;

public class NodeState {
	Path myPath;
	MoveSoft myMoveSoft;
	private Vector2 playerPos; 
	private bool final=false;
	public bool first=false;
	public NodeState(Path path,MoveSoft moveSoft){
		myMoveSoft=moveSoft;
		myPath=path;
		moveSoft.onUpdate+=OnUpdate;
		//Debug.Log("initialize nodeState");
	}
	public void OnUpdate () {
		playerPos=myMoveSoft.getPlayerPos;
	//	Debug.Log("actualizando");

//	Debug.Log("player pos "+playerPos);
		if(myPath.listNodes.Count>0){
		//	Debug.Log("my path nodes cantidad state"+ myPath.listNodes.Count);
			if(myPath.countNodes==1&&!final&&myPath.first){
				Debug.Log("click first");
				final=true;//1er nodo
				myPath.first=false;
			}
		//	Debug.Log("my path node state"+ myPath.listNodes[0]);
			if(Reach()){
				//Debug.Log("llego")
				myPath.DeleteMyElementlist();
				//Debug.Log("cantidiad nodes "+myPath.countNodes);
				final=true;
			}
		}
	}

	private bool Reach(){
		if(Vector2.Distance(myPath.listNodes[0],playerPos)<=0.1f){
			Debug.Log("nodo llego cambio ");
			return true;
		}
		return false;
	}
	private bool Final(){
		if(myPath.countNodes==1){
			Debug.Log("final Node!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
			return true;
		}
		return false;
	}
	public bool getFinal{
		get{
			return final;
		}
		set{
			final=value;
		}
	}
}
