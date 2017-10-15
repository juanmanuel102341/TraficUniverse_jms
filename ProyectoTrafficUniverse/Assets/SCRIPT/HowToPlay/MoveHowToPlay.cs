
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MoveHowToPlay : MonoBehaviour {
	public NodeMovement nodeMovement;
	// Use this for initialization
	private bool activeMove=false;
	private int index=0;
	public float velocity;
	private Vector2 initialPos;
	PathGenerator pathGenerator;
	public Transform target;
	public int totalNodes;
	public Path path;
	private AnimationPath animationPath;
	void Awake () {
	//	nodeMovement.active+=MyMove;
	//	initialPos=transform.position;
	
		pathGenerator=new PathGenerator(transform.position,target.position,totalNodes);
	//	PathGenerator.completeLoad+=getPath;
		path=pathGenerator.getPath;
//				for(int i=0;i<	path.listNodes.Count;i++){
//					Debug.Log("path desde hpowwww"+pathGenerator.path.listNodes[i].posicion);
//						}
		animationPath=GetComponent<AnimationPath>();
	}
	void Start(){
		animationPath.finish+=OnComplete;
	}

	void OnComplete(){
		print("desde how moveeee");
		MyMove();
		ChangeNode();
	}
	void ChangeNode(){
		if(Vector2.Distance(transform.position,path.listNodes[index].posicion)<=0){
			if(index<path.listNodes.Count-1)
			index++;
			if(index==path.listNodes.Count-1){
				//************llega a destino*****************
			print("destruir graficosnodos ");
			//myListNodes.RemoveRange(0,myListNodes.Count);			
			//nodeMovement.DeleteNodesData();//eliminamos nodos de posicion de how
			//nodeMovement.DeleteNodesGraphic();//elimino parte grafica de nodos
			
			//Destroy(this.gameObject);//destruyo objeto
			}	
		}
	}
	private void MyMove(){
		transform.position=Vector2.MoveTowards(transform.position,path.listNodes[index].posicion,velocity*Time.deltaTime);
	}
//	private void Reset(){
//		activeMove=false;
//		transform.position=initialPos;
//		index=0;
//	}



}
