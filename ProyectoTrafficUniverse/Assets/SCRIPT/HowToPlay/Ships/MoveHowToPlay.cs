
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MoveHowToPlay : MonoBehaviour {
	public DataShips dataShips;
	private int index=0;
	private float velocity;
	PathGenerator pathGenerator;
	public Transform target;
	private PathGraphic pathGraphic;

	private AnimationPath animationPath;

	void Awake () {

		pathGraphic=GetComponent<PathGraphic>();
		velocity=dataShips.velocity;
		animationPath=GetComponent<AnimationPath>();
		pathGenerator=new PathGenerator(transform.position,target.position,dataShips.totalNodes,pathGraphic);
		print("name obj destny "+target.transform.gameObject.name);
		print("pos planeta destno player mhplay "+target.position);

		for(int i=0;i<pathGenerator.myPath.getListGraphic.Count;i++){
			pathGenerator.myPath.getListGraphic[i].GetComponent<ViewSprite>().setOffMySprite();	
		}

	
	}
	void Start(){
		animationPath.finish+=OnComplete;

	}

	void OnComplete(){
//		print("desde how moveeee");
		MyMove();
		ChangeNode();
	}
	void ChangeNode(){
		if(Vector2.Distance(transform.position,pathGenerator.myPath.getListVectors[index])<=0){
			if(index<pathGenerator.myPath.getListVectors.Count-1)
			index++;
			if(index==pathGenerator.myPath.getListVectors.Count-1){
				//************llega a destino*****************
	
			}	
		}
	}
	private void MyMove(){
		transform.position=Vector2.MoveTowards(transform.position,pathGenerator.myPath.getListVectors[index],velocity*Time.deltaTime);
	}

	public PathGenerator getPathGenerator{
		get{
			return pathGenerator;
		}
	}


}
