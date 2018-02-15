using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGraphic : MonoBehaviour {

	public GameObject graphicPath;//parte grafica del path

	public GameObject lastNode;

	private float widthLine;
	private float heighLine;
	void Awake(){
		widthLine=graphicPath.GetComponent<Transform>().localScale.x;
	
//		print("widh line "+widthLine);
	
			
	}
	public GameObject SpawnGraphicPath(Vector2 pos,Vector2 v){
		GameObject obj=Instantiate(graphicPath,pos,transform.rotation);
		obj.GetComponent<Transform>().up=v;
		return obj;

	}
	public GameObject SpawnGraphicLastNode(Vector2 pos,MyPath _myPath){
		
		GameObject lastNodeObj;
		lastNodeObj=Instantiate(lastNode,pos,transform.rotation);

		lastNodeObj.GetComponent<PathInputs>().getMyPrinciplePath=_myPath;
		return lastNodeObj;
	}


	public float getMagnitudLine{
		get{
			return widthLine;
		}
	}



}
