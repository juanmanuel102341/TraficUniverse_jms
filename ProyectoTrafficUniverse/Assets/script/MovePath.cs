
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MovePath : MonoBehaviour {
	private int index=0;
	//private PathInputs pathInput;
	private Move move;
	void Awake () {
	//	pathInput=GetComponent<PathInputs>();
		move=GetComponent<Move>();
	}

	void Update () {
		
	
		if(move.pathInputs.path.listNodos.Count>0){
			Move_01();
			ChangeIndexPath();	
		}
	}
	public void ChangeIndexPath(){
//		print("nodo desde move path  "+pathInputs.path.listNodos[index]);
		print("index "+index);
		if(Vector2.Distance(move.pathInputs.path.listNodos[index].posicion,transform.position)<=0){
			if(index<move.pathInputs.path.listNodos.Count-1){
			index++;			
				print("vambio indice");
			}else if(index==move.pathInputs.path.listNodos.Count-1){
				//ultimo path
				print("utlimo path");
				move.getFinalVec=CalcFinal();//guardamo data del ultimo vector 
				move.pathInputs.Delete();//borramos paths
				index=0;
			}
		}

	}
	private Vector2 CalcFinal(){
		Vector2 aux;
		if(move.pathInputs.path.listNodos.Count>1){
			//si hay 2 entras
			aux=move.pathInputs.path.listNodos[move.pathInputs.path.listNodos.Count-1].posicion-move.pathInputs.path.listNodos[move.pathInputs.path.listNodos.Count-2].posicion;
			print("vec final "+aux);
			return aux;
		}else{
			Vector2 aux2;
			aux2.x=transform.position.x;//busco posicion x e y
			aux2.y=transform.position.y;
			aux=move.pathInputs.path.listNodos[move.pathInputs.path.listNodos.Count-1].posicion-aux2;
			print("vec final path "+aux);
			return aux;
		}
	}

	private void Move_01(){
		
		transform.position=Vector2.MoveTowards(transform.position,move.pathInputs.path.listNodos[index].posicion,move.velocity*Time.deltaTime);
		transform.up=VecDirection();
		}
	private Vector2 VecDirection(){
		Vector2 posPlayer;
		Vector2 target;
		Vector2 r;
		posPlayer.x=transform.position.x;
		posPlayer.y=transform.position.y;
		target=move.pathInputs.path.listNodos[index].posicion;
		r=target-posPlayer;
		print("posplayer "+posPlayer);
		print("target "+target);
		print("res "+r);
		return r;
	}



}
