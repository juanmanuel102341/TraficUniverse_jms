using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGraphic : MonoBehaviour {

	public GameObject graphicPath;//parte grafica del path
	private List<GameObject>listGraphicsPaths=new List<GameObject>();
	public float frecuencia;//frecuancia de como se "ve el path"

	public void SpawnGraphicPath(Vector2 pos){
		GameObject obj=Instantiate(graphicPath,pos,transform.rotation);
		listGraphicsPaths.Add(obj);
	}
	public void Delete_ngraphics(){
		//Debug.Log("lista antes d borrar "+listGraphicsPaths.Count);
			for(int i=0;i<listGraphicsPaths.Count;i++){
		//	print("destruccion ");
			GameObject obj=listGraphicsPaths[i];//guardo
		//	listGraphicsPaths.Remove(listGraphicsPaths[i]);//saco d la lista
			Destroy(obj);//destruyo
			}

		listGraphicsPaths.RemoveRange(0,listGraphicsPaths.Count);

		//Debug.Log("borrando nodos graficos "+listGraphicsPaths.Count);
	}
	public List<GameObject> getListGraphic{
		get{
			return listGraphicsPaths;
		}
	}
	public void DeleteFirstElementGraphic(){
		GameObject aux=listGraphicsPaths[0];
		listGraphicsPaths.Remove(listGraphicsPaths[0]);
		Destroy(aux);
			
	}

		
}
