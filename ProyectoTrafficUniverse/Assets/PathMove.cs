using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMove : MonoBehaviour {
	private List<Vector2> listPaths=new List<Vector2>();
	public GameObject obj;
	private Transform tf;

	private Vector3 ve;
	public float anchoScreenMundo;
	public float altoScreenMundo;
	public float lix;
	public float liy;
	public float distanceNode;//distancia entre los nodos del path
	 

	Transform n;
	void Awake () {
		tf=GetComponent<Transform>();
		ve=new Vector3(100.0f,100.0f,0.0f);
		lix=Mathf.Abs(lix);
		liy=Mathf.Abs(liy);
		anchoScreenMundo+=lix;
		altoScreenMundo+=liy;
		//n=GetComponent<Transform>();
	}
		

	void Update () {
	//	tf.position=new Vector3(Input.mousePosition.x,Input.mousePosition.y,0.0f);
		//print("click screen"+Input.mousePosition);
		//print("mundo width "+Input.mousePosition.x*anchoScreenMundo/Screen.width );
		print("click screen"+Input.mousePosition);
		//print("mundo  "+Input.mousePosition.x*anchoScreenMundo/Screen.width );
		if(Input.GetMouseButton(0)){

			Vector2 posw;
			posw.x=TransformScreenToWorldX(Input.mousePosition.x)-lix;
			posw.y=TransformScreenToWorldY(Input.mousePosition.y)-liy;

			if(listPaths.Count==0){
				listPaths.Add(posw);
				Instantiate(obj,posw,transform.rotation);
				print("entrando 1er nodo "+posw);
			}else{
				if(CalcDistancePoint(listPaths[listPaths.Count-1],posw)>distanceNode){
					listPaths.Add(posw);
					Instantiate(obj,posw,transform.rotation);
					print("nodo adentro "+posw);
				}else{
					print("nodo demasiado cerca");
				}
			
			}
		
		}
	
		//print("click x"+Input.mousePosition);
	}
	private void AddPoint(Vector3 input){
//		Vector3 vec=camara.ScreenToWorldPoint(input);
		//vec.z=0;
	
		//listPaths.Add(vec);
	}
	private float CalcDistancePoint(Vector2 v1, Vector2 v2){
		return Vector2.Distance(v1,v2);
	}
	private void Dibujo(){
		for(int i=0;i<listPaths.Count;i++){
			//print("click transformado "+listPaths[i].x);
			Instantiate(obj,(listPaths[i]),transform.rotation);
			//print(i +")x "+listPaths[i].x);
		}

	}
	void OnMouseDown()
	{
			
		//Instantiate(obj,transform.position,transform.rotation)

	}
	float TransformScreenToWorldX(float inputSx){
		float n=(inputSx*anchoScreenMundo);
			n=n/Screen.width;
		print("x mundo "+n);
		return n;
	}
	float TransformScreenToWorldY(float inputSy){
		float n=(inputSy*altoScreenMundo)/Screen.height;
		print("y mundo "+n);
		return n;
	}


}
