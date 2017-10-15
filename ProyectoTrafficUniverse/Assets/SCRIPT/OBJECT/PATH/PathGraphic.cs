using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGraphic : MonoBehaviour {

	public GameObject graphicPath;//parte grafica del path
	private List<GameObject>listGraphicsPaths=new List<GameObject>();
	public float frecuencia;//frecuancia de como se "ve el path"
	void Start(){
	//	Path.activate+=SpawnGraphicPath;
	}
	
	public void SpawnGraphicPath(Vector2 pos){
		if(listGraphicsPaths.Count>0){
			
			if(CheckDistance(pos)){
				print("dibujando");
			GameObject obj=Instantiate(graphicPath,pos,transform.rotation);
			listGraphicsPaths.Add(obj);
			}else{
				print("path grafics cerca");
			}
		}else{
			//igual a 0
			GameObject obj=Instantiate(graphicPath,pos,transform.rotation);
			listGraphicsPaths.Add(obj);

		}
	}
	public void Delete_ngraphics(){
		Debug.Log("lista antes d borrar "+listGraphicsPaths.Count);
			for(int i=0;i<listGraphicsPaths.Count;i++){
			print("destruccion ");
			GameObject obj=listGraphicsPaths[i];//guardo
		//	listGraphicsPaths.Remove(listGraphicsPaths[i]);//saco d la lista
			Destroy(obj);//destruyo
			}

		listGraphicsPaths.RemoveRange(0,listGraphicsPaths.Count);

		Debug.Log("borrando nodos graficos "+listGraphicsPaths.Count);
	}
	public List<GameObject> getListGraphic{
		get{
			return listGraphicsPaths;
		}
	}
	private bool CheckDistance(Vector2 _input){
		
		//la idea d este metodo es tener una frecuancia de dibujado separado de la frecuencia "via codigo"
		Vector2 auxPos;
		auxPos.x= listGraphicsPaths[listGraphicsPaths.Count-1].transform.position.x;
		auxPos.y=listGraphicsPaths[listGraphicsPaths.Count-1].transform.position.y;
		float d=Vector2.Distance(auxPos,_input);
		if(d>frecuencia||frecuencia==0){
			//es igual a 0 para q how to play 
			return true;
		}
		return false;
	}
		
}
