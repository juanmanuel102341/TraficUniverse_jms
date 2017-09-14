
using UnityEngine;
using System.Collections;
public class SetRotation : MonoBehaviour {

	public Bounds bounds;
	private float currentRotation=0;
	private bool apply=false;
	private float widhtObj;
	private float magnitudX;
	private float magnitudY;
	private float distance;
	private float angle;
	private bool applyPathRot=true;

	private Vector2 vecRelativeObj;
	private	 Vector2 vecRelativePath;
	private int currentCuadrante=0;
	private Move move;
	private Vector2 vectorSalida;
	void Awake () {
		apply=true;
		widhtObj=GetComponent<SpriteRenderer>().bounds.size.x;
		print("width "+widhtObj);
		currentRotation=0;
		move=GetComponent<Move>();
	}
	

	void Update () {
		if(bounds.limiteActive){
			GetVectorDirection(bounds.idLimite);
		}
		if(apply){
		RotateObject();
		apply=false;
		}
		}
	private void RotateObject(){
		transform.Rotate(new Vector3(0,0,currentRotation));
		apply=false;
	}
	private void GetVectorDirection(string _id){
		switch(_id)
		{

		case "up":
			transform.position=new Vector3(transform.position.x,bounds.lHeight_up,transform.position.z);
			apply=true;
			currentRotation=Random.Range(90,260);
		
//			print("rot up "+currentRotation);
		//	print("transform y "+transform.position.y);

			break;
		case "down":
			transform.position=new Vector3(transform.position.x,bounds.lHeight_down,transform.position.z);
			apply=true;
			//print("transform y "+transform.position.y);
			float n1=Random.Range(260,350);//aplico rotacion para un lado 
			float n2=Random.Range(0,80);//aplico para otro
			float r=Random.Range(1,3);//random entre las 2, lo hago por q no puedo hacer un solo random
			if(r==1){
				currentRotation=n1;
			}else{
				currentRotation=n2;
			}
			//print("rot down "+currentRotation);
			break;
		case "left":
			transform.position=new Vector3(bounds.lWidth_izq,transform.position.y,transform.position.z);

			apply=true;
			currentRotation=Random.Range(170,350);
			//print("rot left "+currentRotation);
		//	print("posicion x "+transform.position.x);
			break;
		case "right":
			transform.position=new Vector3(bounds.lWidth_der,transform.position.y,transform.position.z);
			apply=true;
		//	print("posicion x "+transform.position.x);
			currentRotation=Random.Range(10,170);
		//	print("rot right "+currentRotation);

			break;
		}

	}
	public float setRot{
		set{
			currentRotation=value;
		}
			
	}


	public Vector2 GetVectorDirection(Vector2 vfinal,Vector2 vafter){


		Vector2 vec =vfinal-vafter;
		return vec;
	}
	private float Cuadrante( Vector2 t){

		if(vecRelativePath.x>0&&vecRelativePath.y>0){
			//1er cuadrante
			return 270;
		}else if(vecRelativePath.x<0&&vecRelativePath.y>0){
		//2do cuadrante
			return 90;
		}else if(vecRelativePath.x<0&&vecRelativePath.y<0){
		//	float n1=Prop(t).x*90;//multiplico maximo d x
			//float n2=Prop(t).y*180;//multiplico maximo en y
//			float r=n1+n2;
			return 0;
		}else {
			//float n1=Prop(t)270;//multiplico maximo d x
			//float n2=Prop(t).y*180;//multiplico maximo en y
			//float r=n1+n2;
			return 0;
		}
			
	}


		
	public bool setBool{
		set{
			apply=value;
		}
	}


	public bool setRotation{
		set{
			applyPathRot=value;
		}
		get{
			return applyPathRot;
		}
	}
}
