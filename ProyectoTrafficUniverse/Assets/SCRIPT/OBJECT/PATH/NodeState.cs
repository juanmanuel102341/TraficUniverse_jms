
using UnityEngine;

public class NodeState {
	Path myPath;

	MyPath myPrincipPath;
	MoveSoft myMoveSoft;
	private Vector2 playerPos; 
	private bool final=true;
	public bool first=false;

	public NodeState(MoveSoft moveSoft,MyPath _myPathPrincip){
		myMoveSoft=moveSoft;

		moveSoft.onUpdate+=OnUpdate;
		myPrincipPath=_myPathPrincip;

		//Debug.Log("initialize nodeState");
	}
	public void OnUpdate () {
		playerPos=myMoveSoft.getPlayerPos;
	
			if(Reach()){
			final=true;
			//	Debug.Log("llego");
				//	Debug.Log("cant nodes "+myPath.countNodes);
		//	Debug.Log("node ultimo "+myPrincipPath.getListVectors[myPrincipPath.getListVectors.Count-1]);
	//		Debug.Log("node 1ro "+myPrincipPath.getListVectors[0]);
				myPrincipPath.DeleteFirstNode();
				//Debug.Log("cantidiad nodes "+myPath.countNodes);
//			Debug.Log("cant list nodes restantes "+myPrincipPath.getListVectors.Count);
			//Debug.Log("cant list nodes restantes "+myPrincipPath.listGraphics.Count);
		}

	}

	private bool Reach(){
		if(Vector2.Distance(myPrincipPath.getListVectors[0],playerPos)<=0.1f){
		//	Debug.Log("nodo llego cambio "+myPrincipPath.getListVectors[0]);
			return true;
		}
		return false;
	}
//	private bool Final(){
//		if(myPath.countNodes==1){
//	//		Debug.Log("final Node!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
//			return true;
//		}
//		return false;
//	}
	public bool getFinal{
		get{
			return final;
		}
		set{
			final=value;
		}
	}
//	public Path ResetMyPath{
//		set{
//			myPath=value;
//		}
//	}
}
