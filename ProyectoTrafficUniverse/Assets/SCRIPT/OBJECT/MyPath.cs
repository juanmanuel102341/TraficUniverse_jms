using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPath {
	public List<GameObject>listGraphics=new List<GameObject>();
	private List<Vector2>listVectors=new List<Vector2>();
	private List<GameObject>listLastNodeOld=new List<GameObject>();//parte grafica de los ultimo nodes q ya fueron desehechados por la creacion de otro nuevo en el mismo path
	private GameObject lastNode=null;
	private int indexLast=0;
	private PathGraphic pathGraphic;
	public MyPath(PathGraphic _pathGraphic){
		pathGraphic=_pathGraphic;
	}

	public void InsertVector(Vector2 v){
		listVectors.Add(v);

	}
	public void InsertGraphics(GameObject obj){
		listGraphics.Add(obj);
		}

	public void DeleteLastNode(){
		DeleteNodeGraphic(listGraphics.Count-1);

	}
	public void DeleteFirstNode(){
		if(listGraphics!=null)
		DeleteNodeGraphic(0);


		listVectors.Remove(listVectors[0]);
	}
	public void DeleteAllNodes(){
		
		for(int i=0;i<listGraphics.Count;i++){
			GameObject obj=listGraphics[i];
			if(obj!=null)
			obj.GetComponent<DeleteMe>().MyDelete();
	
		}
		listGraphics.RemoveRange(0,listGraphics.Count);
		listVectors.RemoveRange(0,listVectors.Count);
	}
	private void DeleteNodeGraphic(int index){
		
		GameObject obj=listGraphics[index];

		listGraphics.RemoveAt(index);
		if(obj!=null)
		obj.GetComponent<DeleteMe>().MyDelete();
	

	}
	public List<Vector2> getListVectors{
		get{
			return listVectors;
		}
	}
	public GameObject setlastNode{
		set{
			lastNode=value;
		}
		get{
			return lastNode;
		}
	}

}
