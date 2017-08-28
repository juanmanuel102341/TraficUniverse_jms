using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	private Rigidbody2D rb;
	private Path path;
	private Transform transform_1;
	private Vector2 currentTarget;
	private int index=0;
	public float velocity;
	void Awake () {
		rb=GetComponent<Rigidbody2D>();	
		path=GetComponent<Path>();
		transform_1=GetComponent<Transform>();
	}
	

	void Update () {
		if(path.getPath.Count>0&&index<path.getPath.Count){
			currentTarget=path.getPath[index];  
			transform_1.position=Vector2.MoveTowards(this.transform.position,path.getPath[index],velocity*Time.deltaTime);
//			print("moviendo a nodo "+path.getPath[index]);
			Finish();
				}
	
	}

	void Finish(){
		Vector2 aux;
		aux.x=transform_1.position.x;
		aux.y=transform_1.position.y;

		if(Vector2.Distance(aux,currentTarget)<=0.0f){
			index++;

		}		
	}
	public int SetIndex{
		set {
			index=value;
		}
	}

}
