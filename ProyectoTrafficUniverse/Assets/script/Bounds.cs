using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {
	//private Transform transform;

	public float lWidth_izq;
	public float lWidth_der;
	public float lHeight_up;
	public float lHeight_down;
	private bool up=false;
	private bool down=false;
	private bool left=false;
	private bool right=false;
//	private bool faceUp=false;
	private bool limite=false;
	private string id;


	void Awake () {
		

	}
	

	void Update () {
//		print("euler "+transform.eulerAngles.z);
		up=BoundUp();
		down=BoundDown();
		right=BoundRight();
		left=BoundLeft();
		limite=ActiveLimit();
	}
	public Vector2 ChangeVector(){
		Vector2 aux;
		print("limite "+id);
		switch(id){
		case "down":
			transform.position=new Vector2(transform.position.x,lHeight_down);
			aux=transform.up;
			print("lim down "+aux);
			return aux;
			break;
		case "up":
			transform.position=new Vector2(transform.position.x,lHeight_up);
			aux=transform.up*-1;
			print("lim up "+aux);
			return aux;
			break;
		case "left":
			transform.position=new Vector2(lWidth_izq,transform.position.y);
			aux=transform.right;
			print("lim up "+aux);
			return aux;
			break;
		case"right":
			transform.position=new Vector2(lWidth_der,transform.position.y);
			aux=transform.right*-1;
			print("lim up "+aux);
			return aux;
			break;
		}
		return transform.up;
	}
	private bool BoundUp(){
		if(transform.position.y>lHeight_up){
//			print("limite up");
			id="up";
			limite=true;
		
			return true;
			}
		limite=false;
		return false;
	}
	private bool BoundDown(){
		if(transform.position.y<lHeight_down){
//			print("limite down!");
			id="down";
			limite=true;
			//faceUp=GetFaceUp("down");
		
			return true;
		}
		return false;
	}
	private bool BoundRight(){
		if(transform.position.x>lWidth_der){
		//	print("limite right");
			id="right";
			limite=true;

			return true;
		}
		return false;
	}
	private bool BoundLeft(){
		if(transform.position.x<lWidth_izq){
		//	print("limite left");
			id="left";
		//	faceUp=GetFaceUp("left");
			return true;
		}
		return false;
	}
	private bool ActiveLimit(){
		if(up==false&&down==false&&right==false&&left==false){
			return false;
		}else{
			print("limite activo");
			return true;
		}
	
	}
//	private bool GetFaceUp(string currentLimite){
//		switch(currentLimite){
//		case "up":
//			if(transform.eulerAngles.z<90||transform.transform.eulerAngles.z>270){
//				print("face up  true");
//				return true;
//			}else{
//				print("face up  false");
//				return false;
//				}
//			break;
//	
//		case "left":
//			if(transform.eulerAngles.z<180){
//				print("face up left true");
//				return true;
//			}else{
//				print("face up left false");
//				return false;
//			}
//			break;
//		
//		case "right":
//			if(transform.eulerAngles.z>180){
//				print("face up right true");
//				return true;
//			}else{
//				print("face up right false");
//				return false;
//			}
//			break;
//		}
//		return false;
//	}
	public bool limiteActive{
		get {
			return limite;
		}
	}
//	public bool getFaceUp{
//		//obtiene si esta mirando para arriba
//		get{
//			return faceUp;
//		}
//	}
	public string idLimite{
		get{
			return id; 
		}
	}
	public float lWidth_der_prop{
		get{
			return lWidth_der;
		}
	}
	public float lWidth_der_izq_prop{
		get{
			return lWidth_izq;
		}
	}
	public float lHeight_up_prop{
		get{
			return lHeight_up;
		}
	}
	public float lHeight_down_prop{
		get{
			return lHeight_down;
		}
	}
}

