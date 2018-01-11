using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGraphic : MonoBehaviour {

	public GameObject graphicPath;//parte grafica del path

	public GameObject lastNode;


	void Awake(){
		
	}
	public GameObject SpawnGraphicPath(Vector2 pos){
		GameObject obj=Instantiate(graphicPath,pos,transform.rotation);

		return obj;

	}

	public GameObject SpawnGraphicLastNode(Vector2 pos,MyPath _myPath){
		GameObject lastNodeObj=Instantiate(lastNode,pos,transform.rotation);
		lastNodeObj.GetComponent<PathInputs>().getMyPrinciplePath=_myPath;
		return lastNodeObj;
	}


//		if(gameObject.tag=="lastNode"){
//		lastNodeObj.GetComponent<PathInputs>().path.myPrincipalPath=_myPath;
//		}

		//	lastNodeObj.GetComponent<PathInputs>().getNumberPathId=GetComponent<PathInputs>().getNumberPathId;
	//	print("nombre obj "+lastNodeObj.GetComponent<PathInputs>().getNumberPathId);
//		if(tag=="plane"){
//			
//		}else if(tag=="lastNode"){
//			lastNodeObj.GetComponent<PathInputs>().getNumberPathId=GetComponent<PathInputs>().getNumberPathId;
//			print("nombre objeot "+GetComponent<PathInputs>().getNumberPathId);
//		}
//}
//	public void Delete_ngraphics(){
//		//print("lista antes d borrar "+listGraphicsPaths.Count);
//			for(int i=0;i<listGraphicsPaths.Count;i++){
//		//	print("destruccion ");
//			GameObject obj=listGraphicsPaths[i];//guardo
//		//	listGraphicsPaths.Remove(listGraphicsPaths[i]);//saco d la lista
//			Destroy(obj);//destruyo
//			}
//	//	DeleteLastElement();
//
//			listGraphicsPaths.RemoveRange(0,listGraphicsPaths.Count);
//		
//		print("borrando nodos graficos "+listGraphicsPaths.Count);
//	}
//
//	public List<GameObject> getListGraphic{
//		get{
//			return listGraphicsPaths;
//		}
//	}
//	public void DeleteFirstElementGraphic(){
//		GameObject aux=listGraphicsPaths[0];
//
//
//
//		listGraphicsPaths.Remove(listGraphicsPaths[0]);
//		//listGraphicsPaths[lis]
//		Destroy(aux);
//
//}
//		
//	//public void DeleteAllLastNodes(){
//	//	GameObject []objsNodes=GameObject.FindGameObjectsWithTag("lastNode");
//	//	for(int i=0;i<objsNodes.Length;i++){
//	//		objsNodes[i].GetComponent<DetectClick>().DeleteMe();
//	//	}
//	//}
//	public void DeleteLastNode(){
//		//borra ultimo nodo normal para generar "espacio" al nuevo nodo especial
//		GameObject aux=listGraphicsPaths[listGraphicsPaths.Count-1];
//
//		//GetComponent<PathInputs>().getMyPrinciplePath.DeleteMyElementGraphic(aux);
//		listGraphicsPaths.Remove(listGraphicsPaths[listGraphicsPaths.Count-1]);
//		Destroy(aux);
//
//	}	


}
