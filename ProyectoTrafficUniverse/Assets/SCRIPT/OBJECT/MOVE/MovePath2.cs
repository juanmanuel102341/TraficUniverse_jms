using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePath2 : MonoBehaviour {

	private int index=0;
	private Move move;
	private int direccion=1;
	private Bounds bounds;
	private Vector2 currentVector;
	private bool firstMove=false;
	void Awake () {
		//	pathInput=GetComponent<PathInputs>();
		move=GetComponent<Move>();
		bounds=GetComponent<Bounds>();
		print("move "+move);
	}

	void Update () {

		//print("cantidad nodes "+move.getPathInputs.path.listNodes.Count);
	
		if(!FinalPath()&&!bounds.limiteActive){
//			print("target "+move.getPathInputs.path.listNodes[index].posicion);
//			print("player "+transform.position);
//			print("distance "+Vector2.Distance(move.getPathInputs.path.listNodes[index].posicion,transform.position));
		if(index==0&&firstMove==false){
			currentVector=VecDirection();
//			print("get my first vector ");
			//ChangeAxisPathMetric();	
			transform.up=currentVector;

			firstMove=true;
		}
		if(ReachPathPosition()){
//			print("destiono cambio indice");
			index++;
			//ChangeAxisPathMetric();	
			currentVector=VecDirection();
			transform.up=currentVector;


//			print("vector actual "+currentVector);
//			print("index "+index);
		}

		}else{
//			print("final path");	
			if(move.getPathInputs.path.listNodes.Count>0||bounds.limiteActive){
				ResetListNodes();
				}
			}

		Move_01();
	}
	public void ResetListNodes(){
//		print("entrando borrando nodos ");
		GetComponent<Delete>().DeleteNodes();
		index=0;
		firstMove=false;
		enabled=false;
		bounds.limiteActive=false;
	}
	private  bool ReachPathPosition(){

		if(Vector2.Distance(move.getPathInputs.path.listNodes[index],transform.position)<=0.1f){
			return true;
		}
		return false;
	}
	private bool FinalPath(){
		if(index==move.getPathInputs.path.listNodes.Count-1){
			return true;
		}
		return false;
	}
	private void ChangeAxisPathMetric(){
		move.getPathInputs.path.listNodes[index]=VecDirection();
	//	print("new target axis "+move.getPathInputs.path.listNodes[index].posicion.y );
	}

	private void Move_01(){
		//transform.position=Vector2.MoveTowards(transform.position,move.getPathInputs.path.listNodes[index].posicion,move.velocity*Time.deltaTime*direccion);
		//	transform.up=currentVector;
		transform.Translate(Vector2.up*move.velocity*Time.deltaTime);
	}
	private Vector2 VecDirection(){
		Vector2 posPlayer;
		Vector2 target;
		Vector2 r;
		posPlayer.x=transform.position.x;
		posPlayer.y=transform.position.y;
		target=move.getPathInputs.path.listNodes[index];
		r=target-posPlayer;

		//		print("posplayer "+posPlayer);
		//print("target "+target);
		//print("res "+r);
		return r;
	}
	public int setIndex{
		set{
			index=value;//viene de path inputs cuando clickea usuario y se borran los nodos
		}
	}
	public Vector2 getCurrentVector{
		get{
			return VecDirection();
		}
	}
}
