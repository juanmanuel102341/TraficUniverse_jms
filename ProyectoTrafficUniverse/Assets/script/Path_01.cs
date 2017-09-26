using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_01  {

	public List<Nodo>listNodos=new List<Nodo>();
	private Nodo node;
	private float distanceNodes=0.5f;
	public delegate void NewPathCreation(Vector2 _pos);
	public static event NewPathCreation activate;

	void Awake () {
		
	}
	
	private void SetNewNode(Vector2 input){
		node=new Nodo();
		node.SetPosition(input);
//		Debug.Log("node "+node.posicion);
		listNodos.Add(node);

	}

	public void GeneratePath(Vector2 input){
		if(listNodos.Count!=0){
			//hay x lo menos 1
			float d=Vector2.Distance(listNodos[listNodos.Count-1].posicion,input);
			if(d>distanceNodes){
//				Debug.Log("distancia mayor  "+d);
				SetNewNode(input);
				activate(input);
			}
		}else{
//			Debug.Log("lista =0");
			//igual a 0 
			SetNewNode(input);
			activate(input);
		}
	}
	public void DeleteNodosPaths(){
		if(listNodos.Count>0){
			listNodos.Clear();
		}
		Debug.Log("borrando nodos "+listNodos.Count);
	}

}
