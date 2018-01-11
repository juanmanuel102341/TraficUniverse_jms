
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MoveHowToPlay : MonoBehaviour {
	public DataShips dataShips;
	private int index=0;
	private float velocity;
	PathGenerator pathGenerator;
	public Transform target;
	public Path path;
	private AnimationPath animationPath;

	void Awake () {
		velocity=dataShips.velocity;
		animationPath=GetComponent<AnimationPath>();
		pathGenerator=new PathGenerator(transform.position,target.position,dataShips.totalNodes);
		path=pathGenerator.getPath;//obtengo el path
	}
	void Start(){
		animationPath.finish+=OnComplete;
	}

	void OnComplete(){
//		print("desde how moveeee");
	//	MyMove();
//		ChangeNode();
	}
//	void ChangeNode(){
//		if(Vector2.Distance(transform.position,path.listNodes[index])<=0){
//			if(index<path.listNodes.Count-1)
//			index++;
//			if(index==path.listNodes.Count-1){
//				//************llega a destino*****************
//	
//			}	
//		}
//	}
//	private void MyMove(){
//		transform.position=Vector2.MoveTowards(transform.position,path.listNodes[index],velocity*Time.deltaTime);
//	}




}
