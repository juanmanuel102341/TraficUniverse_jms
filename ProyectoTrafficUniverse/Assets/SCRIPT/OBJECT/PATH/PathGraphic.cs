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
		
		GameObject lastNodeObj;
		lastNodeObj=Instantiate(lastNode,pos,transform.rotation);

		lastNodeObj.GetComponent<PathInputs>().getMyPrinciplePath=_myPath;
		return lastNodeObj;
	}





}
