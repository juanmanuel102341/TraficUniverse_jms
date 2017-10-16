
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MoveHowToPlay : MonoBehaviour {
	private int index=0;
	public float velocity;
	PathGenerator pathGenerator;
	public Transform target;
	public Path path;
	private AnimationPath animationPath;

	void Awake () {

		animationPath=GetComponent<AnimationPath>();
		pathGenerator=new PathGenerator(transform.position,target.position,animationPath.totalNodes);
		path=pathGenerator.getPath;
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
			print("destino final red ");
			
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
