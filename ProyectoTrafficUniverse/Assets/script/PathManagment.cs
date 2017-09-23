using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManagment : MonoBehaviour {

	public Path_01 path;
	public Camera cameraGame;
	void Awake () {
		path=new Path_01();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown(0)){
			GetPositionMouse();
		}

	}

	private void GetPositionMouse(){
		print("CLICKmOUSE");
		Vector3 vec=new Vector3(0,0,0);
		vec=Input.mousePosition;
		vec.z=10;
		cameraGame.ScreenToWorldPoint(vec);
		Vector2 aux;
		aux.x=vec.x;
		aux.y=vec.y;
		path.DataMousse(aux);
				
	}
}
