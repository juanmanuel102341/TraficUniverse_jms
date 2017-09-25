using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManagment : MonoBehaviour {

	public GameObject graphicPath;//parte grafica del path
	private List<GameObject>listGraphicsPaths=new List<GameObject>();



	void Awake () {

	
	
	}
	void Start(){
		Path_01.activate+=SpawnGraphicPath;
	}
	
	private void SpawnGraphicPath(Vector2 pos){
		listGraphicsPaths.Add(Instantiate(graphicPath,pos,transform.rotation));
	}
	public void DeleteMyList(){
		for(int i=0;i<listGraphicsPaths.Count;i++){
//			print("destruccion ");
			Destroy(listGraphicsPaths[i]);
		}
//		Debug.Log("borrando nodos "+listGraphicsPaths.Count);
	}
}
