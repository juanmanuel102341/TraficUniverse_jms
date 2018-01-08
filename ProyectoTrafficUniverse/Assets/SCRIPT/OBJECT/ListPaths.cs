using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPaths{

	private List<GameObject>listPaths=new List<GameObject>();

	public void InsertPath(GameObject path){
		listPaths.Add(path);
		Debug.Log("agregando lista !!!!!!!!!!!"+listPaths.Count);
	}
	public void DeletePaths(){
		listPaths.RemoveRange(0,listPaths.Count);
	}
	public GameObject CurrenPath(){
		return listPaths[0];	
	}
	public void RemovePath(){
		listPaths.RemoveRange(0,1);
	}
	public List<GameObject> getListPaths{
		get{
			return listPaths;
		}
	}



}
