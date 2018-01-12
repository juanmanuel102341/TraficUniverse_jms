using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPath {
	public List<GameObject>listGraphics=new List<GameObject>();
	private List<Vector2>listVectors=new List<Vector2>();
	private GameObject lastNode=null;
	private int indexLast=0;
	public MyPath(){
		
	}

	public void InsertVector(Vector2 v){
		listVectors.Add(v);

	}
	public void InsertGraphics(GameObject obj){
		listGraphics.Add(obj);
		if(lastNode!=null&&obj.tag=="lastNode"){
			//Debug.Log("cantidad nodes angtes lg"+listGraphics.Count);
		//	listGraphics.RemoveRange(indexLast,1);
			Debug.Log("suplantando node");
			listGraphics.Remove(lastNode);
			listVectors.RemoveRange(indexLast,1);
			lastNode.GetComponent<DeleteMe>().MyDelete();

			//DeleteNodeGraphic(indexLast);
		//	listVectors.Remove(listVectors[indexLast]);
		//	Debug.Log("cantidad nodes graficos despue "+listGraphics.Count);
		//	Debug.Log("cantidad nodes vectores antes "+listVectors.Count);
		//	listVectors.RemoveRange(indexLast,1);
		//	Debug.Log("cantidad nodes vectores despues "+listVectors.Count);
	//		Debug.Log("index node last "+indexLast);
		//	Debug.Log("cantidad de nodes "+listGraphics.Count);
		}
		if(obj.tag=="lastNode"){
			
			lastNode=obj;
			indexLast=listGraphics.Count-1;
			Debug.Log("guardando node ultimo "+lastNode.GetComponent<Transform>().position);
		}

	}
	//ublic void InsertListGraphic(List<game
	public void DeleteLastNode(){
		DeleteNodeGraphic(listGraphics.Count-1);

	}
	public void DeleteFirstNode(){

		DeleteNodeGraphic(0);


		listVectors.Remove(listVectors[0]);
	}
	public void DeleteAllNodes(){
		
		for(int i=0;i<listGraphics.Count;i++){
			GameObject obj=listGraphics[i];
			obj.GetComponent<DeleteMe>().MyDelete();
	
		}
		listGraphics.RemoveRange(0,listGraphics.Count);
		listVectors.RemoveRange(0,listVectors.Count);
	}
	private void DeleteNodeGraphic(int index){
		
		GameObject obj=listGraphics[index];
		if(obj==null){
			Debug.Log("Warning@ objeto nulo");
		}
//			Debug.Log("cant nodes antes borrar "+listGraphics.Count);
		listGraphics.Remove(listGraphics[index]);
		obj.GetComponent<DeleteMe>().MyDelete();
	

	}
	public List<Vector2> getListVectors{
		get{
			return listVectors;
		}
	}
}
