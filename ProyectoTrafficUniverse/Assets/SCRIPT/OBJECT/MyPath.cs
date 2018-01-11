using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPath {
	public List<GameObject>listGraphics=new List<GameObject>();
	private List<Vector2>listVectors=new List<Vector2>();


	public MyPath(){
		
	}

	public void InsertVector(Vector2 v){
		listVectors.Add(v);

	}
	public void InsertGraphics(GameObject obj){
		listGraphics.Add(obj);
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
		
		for(int i=0;i<listVectors.Count;i++){
			DeleteNodeGraphic(0);
		}
		listVectors.RemoveRange(0,listVectors.Count);
	}
	private void DeleteNodeGraphic(int index){
		GameObject obj=listGraphics[index];
		listGraphics.Remove(listGraphics[index]);
		obj.GetComponent<DeleteMe>().MyDelete();
	}
	public List<Vector2> getListVectors{
		get{
			return listVectors;
		}
	}
}
