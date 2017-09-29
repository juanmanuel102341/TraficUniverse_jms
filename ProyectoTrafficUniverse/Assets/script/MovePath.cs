﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MovePath : MonoBehaviour {
	private int index=0;
	//private PathInputs pathInput;
	private Move move;
	private int direccion=1;
	private Bounds bounds;
	void Awake () {
	//	pathInput=GetComponent<PathInputs>();
		move=GetComponent<Move>();
		bounds=GetComponent<Bounds>();
	}

	void Update () {
		
	
		if(move.getPathInputs.path.listNodos.Count>0){
			if(!bounds.limiteActive){
			Move_01();
			ChangeIndexPath();	
			}else{
				//limite activo , path "dentro" del limite, borro paths, entra en juego moveWhithouth path q "cambia de sentido"
				DeletePaths();
				bounds.limiteActive=false;
			}
		}
	}
	public void ChangeIndexPath(){
//		print("nodo desde move path  "+pathInputs.path.listNodos[index]);
		print("index "+index);
		if(Vector2.Distance(move.getPathInputs.path.listNodos[index].posicion,transform.position)<=0){
			if(index<move.getPathInputs.path.listNodos.Count-1){
			index++;			
				print("vambio indice");
			}else if(index==move.getPathInputs.path.listNodos.Count-1){
				//ultimo path
				print("utlimo path");
				DeletePaths();
				index=0;
			}
		}

	}
	private void DeletePaths(){
		move.getFinalVec=CalcFinal();//guardamo data del ultimo vector 
		move.getPathInputs.Delete();//borramos paths
	}
	private Vector2 CalcFinal(){
		Vector2 aux;
		if(move.getPathInputs.path.listNodos.Count>1){
			//si hay 2 entras
			aux=move.getPathInputs.path.listNodos[move.getPathInputs.path.listNodos.Count-1].posicion-move.getPathInputs.path.listNodos[move.getPathInputs.path.listNodos.Count-2].posicion;
			print("vec final "+aux);
			return aux;
		}else{
			Vector2 aux2;
			aux2.x=transform.position.x;//busco posicion x e y
			aux2.y=transform.position.y;
			aux=move.getPathInputs.path.listNodos[move.getPathInputs.path.listNodos.Count-1].posicion-aux2;
			print("vec final path "+aux);
			return aux;
		}
	}

	private void Move_01(){
		
		transform.position=Vector2.MoveTowards(transform.position,move.getPathInputs.path.listNodos[index].posicion,move.velocity*Time.deltaTime*direccion);
		transform.up=VecDirection();
		}
	private Vector2 VecDirection(){
		Vector2 posPlayer;
		Vector2 target;
		Vector2 r;
		posPlayer.x=transform.position.x;
		posPlayer.y=transform.position.y;
		target=move.getPathInputs.path.listNodos[index].posicion;
		r=target-posPlayer;
//		print("posplayer "+posPlayer);
		//print("target "+target);
		//print("res "+r);
		return r;
	}
	public int setIndex{
		set{
			index=value;
		}
	}


}