using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {
	private bool limite=false;
	private Camera cameraGame;
	private float widthScene;
	private float heightScene;
	private float widthObj;
	private float heightObj;
	void Awake () {
		//camara tiene q estar poscionada en (0,0)!!!
		cameraGame=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		//cameraGame.ScreenToWorldPoint(
		print ("camera "+cameraGame.orthographicSize);
		heightScene=cameraGame.orthographicSize;//alto de la camara 
		widthScene=cameraGame.aspect*cameraGame.orthographicSize;//ancho del tama;o d la camara multiplicado por la razon del ancho divido height(en mi caso 16/9)
		widthObj=GetComponent<SpriteRenderer>().bounds.extents.x;//ancho del objeto dividido 2
		heightObj=GetComponent<SpriteRenderer>().bounds.extents.y;//alto div2
		print("height "+heightScene);
		print("width "+widthScene);
	
		print("width obj "+widthObj);
		print("alto obj "+heightObj);
	}
	void Update () {
		if(AxisXMin()||AxisYMin()||AxisXMax()||AxisYMax()){
			print("limite activo");
			limite=true;		
		}else{
			limite=false;
		}
	}
	private bool AxisXMin(){
		if(transform.position.x-widthObj<-widthScene){
			
			float l=-widthScene+widthObj;
			transform.position=new Vector2(l,transform.position.y);
//			print("w "+widthObj);
//			print("scene max "+widthScene);
//			print("lim x min "+l);
//			print("pos x "+transform.position.x);
			return true;
		}
		return false;
	}
	private bool AxisXMax(){
		if(transform.position.x+widthObj>widthScene){
			transform.position=new Vector2 (widthScene-widthObj,transform.position.y);//posiciono el objeto en el punto maximo menos el ancho para q n traiga prblemas cuando le cambie d direccion
			return true;
		}
		return false;
	}
	private bool AxisYMin(){
		if(transform.position.y-heightObj<-heightScene){
			transform.position=new Vector2 (transform.position.x,-heightScene+heightObj);
			return true;
		}
		return false;
	}
	private bool AxisYMax(){
		if(transform.position.y+heightObj>heightScene){
			transform.position=new Vector2 (transform.position.x,heightScene-heightObj);
			return true;
		}
		return false;	
	}
	public bool limiteActive{
		get {
			return limite;
		}
		set{
			limite=value;
		}
	}



}

