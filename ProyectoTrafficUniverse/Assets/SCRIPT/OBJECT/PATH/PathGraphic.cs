using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGraphic : MonoBehaviour {

	public GameObject graphicPath;//parte grafica del path
	private List<GameObject>listGraphicsPaths=new List<GameObject>();
	public GameObject lastNode;
	private MoveSoft  moveSoft;

	void Awake(){
		
	}
	public void SpawnGraphicPath(Vector2 pos){
		GameObject obj=Instantiate(graphicPath,pos,transform.rotation);


		listGraphicsPaths.Add(obj);
	}

	public void SpawnGraphicLastNode(Vector2 pos,MyPath p){
		GameObject lastNodeObj=Instantiate(lastNode,pos,transform.rotation);
		lastNodeObj.GetComponent<PathInputs>().getMyPrinciplePath=p;
		lastNodeObj.GetComponent<PathInputs>().getMyPrinciplePath.InsertPathGrapchicList(listGraphicsPaths);
		print("set pp "+lastNodeObj.GetComponent<PathInputs>().getMyPrinciplePath.getListGraphic.Count);
//		if(gameObject.tag=="lastNode"){
//		lastNodeObj.GetComponent<PathInputs>().path.myPrincipalPath=_myPath;
//		}
		listGraphicsPaths.Add(lastNodeObj);
		//	lastNodeObj.GetComponent<PathInputs>().getNumberPathId=GetComponent<PathInputs>().getNumberPathId;
	//	print("nombre obj "+lastNodeObj.GetComponent<PathInputs>().getNumberPathId);
//		if(tag=="plane"){
//			
//		}else if(tag=="lastNode"){
//			lastNodeObj.GetComponent<PathInputs>().getNumberPathId=GetComponent<PathInputs>().getNumberPathId;
//			print("nombre objeot "+GetComponent<PathInputs>().getNumberPathId);
//		}
	}
	public void Delete_ngraphics(){
		//print("lista antes d borrar "+listGraphicsPaths.Count);
			for(int i=0;i<listGraphicsPaths.Count;i++){
		//	print("destruccion ");
			GameObject obj=listGraphicsPaths[i];//guardo
		//	listGraphicsPaths.Remove(listGraphicsPaths[i]);//saco d la lista
			Destroy(obj);//destruyo
			}
	//	DeleteLastElement();

			listGraphicsPaths.RemoveRange(0,listGraphicsPaths.Count);
		
		print("borrando nodos graficos "+listGraphicsPaths.Count);
	}

	public List<GameObject> getListGraphic{
		get{
			return listGraphicsPaths;
		}
	}
	public void DeleteFirstElementGraphic(){
		print("BORRAR LIST GRAPHICcantidad d elementos ANTES "+GetComponent<PathInputs>().getMyPrinciplePath.getListGraphic.Count);

		GetComponent<PathInputs>().getMyPrinciplePath.DeleteMyElementGraphic(listGraphicsPaths[0]);

		print("BORRAR LIST GRAPHCI cantidad d elementos DESPUES "+GetComponent<PathInputs>().getMyPrinciplePath.getListGraphic.Count);
		GameObject aux=listGraphicsPaths[0];



		listGraphicsPaths.Remove(listGraphicsPaths[0]);
		//listGraphicsPaths[lis]
		Destroy(aux);
			
}

	//public void DeleteAllLastNodes(){
	//	GameObject []objsNodes=GameObject.FindGameObjectsWithTag("lastNode");
	//	for(int i=0;i<objsNodes.Length;i++){
	//		objsNodes[i].GetComponent<DetectClick>().DeleteMe();
	//	}
	//}
	public void DeleteLastNode(){
		//borra ultimo nodo normal para generar "espacio" al nuevo nodo especial
		GameObject aux=listGraphicsPaths[listGraphicsPaths.Count-1];

		//GetComponent<PathInputs>().getMyPrinciplePath.DeleteMyElementGraphic(aux);
		listGraphicsPaths.Remove(listGraphicsPaths[listGraphicsPaths.Count-1]);
		Destroy(aux);

	}	


}
