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
	private SetRotation setRot;

	//private Vector2 currentPath;

	void Awake () {
//		idle=true;

		rb=GetComponent<Rigidbody2D>();	
		path=GetComponent<Path>();
		transform_1=GetComponent<Transform>();
		setRot=GetComponent<SetRotation>();
		//		transform.Rotate(new Vector3 (0,0,180));
	}
	

	void Update () {
//		print("base entrando "+path.getLastVector);
		//print("lista obj "+path.getPath.Count);
		if(path.getPath.Count>0&&index<path.getPath.Count){

			currentTarget=path.getPath[index]; 
		
		transform_1.position=Vector2.MoveTowards(this.transform.position,path.getPath[index],velocity*Time.deltaTime);
//			print("moviendo a nodo "+path.getPath[index]);
		
			Vector2 vecBase2D;
			vecBase2D.x=this.transform.position.x;
			vecBase2D.y=this.transform.position.y;
			if(setRot.setRotation){
				
				setRot.ChangeRotation(currentTarget);	
			//	Quaternion a=Quaternion.FromToRotation(vecBase2D,currentTarget);	
				//float a=Quaternion.Angle(transform.rotation,path.transform.rotation);
				//print("a "+a);
		//		Quaternion a2=Quaternion.FromToRotation(transform.position,Vector2.Distance(transform.position,currentTarget));

				//transform.rotation.Set(a2);
				//transform.Rotate(0,0,a);
			//	print("angulo final "+	a2);

		//		setRot.setRotation=false;
			}
		
			Finish();
		}else if (index==path.getPath.Count){
			
		//	print("base entrando ");
			//Vector2 vecBase2D;
			//vecBase2D.x=this.transform.position.x;
			//vecBase2D.y=this.transform.position.y;
			//rb.transform.Rotate(0,0,setRot.ChangeRotation(vecBase2D,path.getPath[index]));
			//rb.transform.Translate(Vector2.up*velocity*Time.deltaTime);
			rb.transform.Translate(path.getLastVector*velocity*Time.deltaTime);
	
		}
	
	}

	void Finish(){
		Vector2 aux;
		aux.x=transform_1.position.x;
		aux.y=transform_1.position.y;

		if(Vector2.Distance(aux,currentTarget)<=0.0f){
			print("entrando cambio rotacion");
			//setRot.setRotation=true;
			index++;
		//	rb.transform.Rotate(0,0,setRot.ChangeRotation(aux,currentTarget));
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

	public Vector2 getCurrentPath{
		get{
			return currentTarget;
		}
	} 
}
