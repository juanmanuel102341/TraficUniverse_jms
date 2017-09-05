using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	private Rigidbody2D rb;
	private Path path;
	private Transform transform_1;
	private Vector2 currentTarget;
	private int index=0;
	//private bool idle=true;
	public float velocity;


	void Awake () {
//		idle=true;
		rb=GetComponent<Rigidbody2D>();	
		path=GetComponent<Path>();
		transform_1=GetComponent<Transform>();
//		transform.Rotate(new Vector3 (0,0,180));
	}
	

	void Update () {
		//print("lista obj "+path.getPath.Count);
		if(path.getPath.Count>0&&index<path.getPath.Count){
			currentTarget=path.getPath[index]; 

			transform_1.position=Vector2.MoveTowards(this.transform.position,path.getPath[index],velocity*Time.deltaTime);
//			print("moviendo a nodo "+path.getPath[index]);
			Finish();
				
		}else if (index==path.getPath.Count){
		//	print("base entrando ");
			
			rb.transform.Translate(path.getLastVector*velocity*Time.deltaTime);

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
	private float RandomSet(float v1, float v2){
		float n=Random.Range(v1,v2);

		print("random "+n);
		return n;
	}
//	public bool setBoolIdle{
//		set{
//			idle=value;
//		}
//	}


}
