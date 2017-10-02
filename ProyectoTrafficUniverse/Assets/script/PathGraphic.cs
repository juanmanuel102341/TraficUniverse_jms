using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGraphic : MonoBehaviour {

	public GameObject graphicPath;//parte grafica del path
	private List<GameObject>listGraphicsPaths=new List<GameObject>();
	void Start(){
	//	Path.activate+=SpawnGraphicPath;
	}
	
	public void SpawnGraphicPath(Vector2 pos){
		GameObject obj=Instantiate(graphicPath,pos,transform.rotation);
		listGraphicsPaths.Add(obj);
	}
	public void Delete_ngraphics(){
		for(int i=0;i<listGraphicsPaths.Count;i++){
		//	print("destruccion ");
			Destroy(listGraphicsPaths[i]);
		}
//		Debug.Log("borrando nodos "+listGraphicsPaths.Count);
	}
	public List<GameObject> getListGraphic{
		get{
			return listGraphicsPaths;
		}
	}
}
