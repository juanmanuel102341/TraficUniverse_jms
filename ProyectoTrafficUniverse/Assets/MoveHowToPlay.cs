
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MoveHowToPlay : MonoBehaviour {
	public NodeMovement nodeMovement;
	// Use this for initialization
	private bool activeMove=false;
	private int index=0;
	private List<Vector2> myListNodes;
	public float velocity;
	private Vector2 initialPos;

	void Start () {
		nodeMovement.active+=MyMove;
		initialPos=transform.position;
	}
	
	void MyMove(List<Vector2>_l){
		print("my move");
		if(!activeMove){
			activeMove=true;
			myListNodes=_l;

		}
		MyMove();
		ChangeNode();
	}

	void ChangeNode(){
		if(Vector2.Distance(transform.position,myListNodes[index])<=0){
			if(index<myListNodes.Count-1)
			index++;
			if(index==myListNodes.Count-1){
				//************llega a destino*****************
			print("destruir graficosnodos ");
			myListNodes.RemoveRange(0,myListNodes.Count);			
			nodeMovement.DeleteNodesData();//eliminamos nodos de posicion de how
			nodeMovement.DeleteNodesGraphic();//elimino parte grafica de nodos
			
			Destroy(this.gameObject);//destruyo objeto
			}	
		}
	}
	private void MyMove(){
		transform.position=Vector2.MoveTowards(transform.position,myListNodes[index],velocity*Time.deltaTime);
	}
//	private void Reset(){
//		activeMove=false;
//		transform.position=initialPos;
//		index=0;
//	}
}
