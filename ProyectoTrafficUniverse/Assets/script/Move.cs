using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	private Rigidbody2D rb;
	private Path path;
	//private Transform transform_1;
	private Vector2 currentTarget;
	private int index=0;
	//private bool idle=true;
	public float velocity;
	private SetRotation setRot;
	private Vector2 lastVector;
	//private Vector2 currentPath;

	void Awake () {
//		idle=true;

		rb=GetComponent<Rigidbody2D>();	
		path=GetComponent<Path>();
		//transform_1=GetComponent<Transform>();
		setRot=GetComponent<SetRotation>();
		lastVector.x=0;
		lastVector.y=1;
		//		transform.Rotate(new Vector3 (0,0,180));
	}
	

	void Update () {
//		print("base entrando "+path.getLastVector);
		//print("lista obj "+path.getPath.Count);
		if(path.getPathVectors.Count>0&&index<path.getPathVectors.Count){

			currentTarget=path.getPathVectors[index]; 
		
			transform.position=Vector2.MoveTowards(this.transform.position,path.getPathVectors[index],velocity*Time.deltaTime);
//			print("moviendo a nodo "+path.getPath[index]);
		
			Vector2 vecBase2D;
			vecBase2D.x=this.transform.position.x;
			vecBase2D.y=this.transform.position.y;
			Vector2 fv=setRot.GetVectorDirection(currentTarget,vecBase2D);
			print("tamanio lista "+path.getPathVectors.Count);

			transform.up=fv;

			Finish();
		}else if (index==path.getPathVectors.Count){
			print("ultimo vector "+lastVector);
	//		transform_1.position=Vector2.MoveTowards(this.transform.position,path.getLastVector,velocity*Time.deltaTime);

			rb.transform.Translate(Vector2.up*velocity*Time.deltaTime);

		}
		if(path.getMouseUp&&path.getMouseDown&&path.getPathVectors.Count>=2){
			//si dejaste d clickear y has clickiado y has generado un path
			//ya se cual es el ultimo
			print("obteniendo valore buscados ");

			lastVector=setRot.GetVectorDirection(path.getPathVectors[path.getPathVectors.Count-1],path.getPathVectors[path.getPathVectors.Count-2]);
			transform.up=lastVector;
			print("vector ultimo "+lastVector);
		}
	}

	void Finish(){
		Vector2 aux;
		aux.x=transform.position.x;
		aux.y=transform.position.y;

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
