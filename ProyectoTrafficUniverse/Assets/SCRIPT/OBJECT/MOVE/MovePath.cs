using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MovePath : Move {
	private int index=0;

	private int direccion=1;
	public List<Vector2>list_Vec=new List<Vector2>();
	public Vector2 posPlayer;
	public MovePath(){
		Debug.Log("instancia move path");
	}

	void Update () {
		





	}
	public void ChangeIndexPath(){
		Debug.Log("nodo desde move path  "+list_Vec[index]);
				print("index "+index);
		Debug.Log("Vector2.Distance(list_Vec[index],posPlayer)"+Vector2.Distance(list_Vec[index],posPlayer));
		if(Vector2.Distance(list_Vec[index],posPlayer)<=0){
			if(index<list_Vec.Count-1){
				index++;			
				Debug.Log("cambio indice");
			}else if(index==list_Vec.Count-1){
				//borro nodos
//				getFinalVec=CalcFinal();//guardamo data del ultimo vector y lo setiemos
				//GetComponent<Delete>().DeleteNodes();//borro nodos
				index=0;
				Debug.Log("ultimos nodos");
			}
		}

	}
	public void CalcFinal(){
		
		//metodo publico asi puedo accede desde path inputs y obtener el vectir apropiado cuando clickea de nuevo el usuario sobre y genera otro path
		Debug.Log("entrando move path "+list_Vec.Count);
//		for(int i=0;i<list_Vec.Count;i++){
//		Debug.Log("nodo desde move path "+list_Vec[i]);
//		
//		}
	Debug.Log("pos player "+posPlayer);
		Debug.Log("index "+index);
				ChangeIndexPath();
		Vector2 aux;
//		if(list_Vec.Count>1){
//			//si hay 2 entras, calculo de diferencia de nodos entre el ultimo y anteultimo, obteniendo el vector correspondiente
//			aux=list_Vec[list_Vec.Count-1]-list_Vec[list_Vec.Count-2];
//			print("vec final+ de 1 "+aux);
//			return aux;
//		}else{
//			print("vec final menos d 1 ");
//
//
//			aux=posPlayer-list_Vec[index];
//			print("pos player "+posPlayer);
//			print("vec path "+list_Vec[index]);
//		
//			return aux;
//		}


	}

	public Vector2 GetVecDirection(){
		

	
		Debug.Log("index "+index);
		Vector2 target;
		target=list_Vec[index];
		Debug.Log("posplayer "+posPlayer);
		Debug.Log("vecPath "+list_Vec[index]);
		Debug.Log("target "+target);
		//print("res "+r);
		ChangeIndexPath();
		return target;
	}
	public int setIndex{
		set{
			index=value;//viene de path inputs cuando clickea usuario y se borran los nodos
		}
	}
	public Vector2 getCurrentVector{
		get{
			return GetVecDirection();
		}
	}

}
