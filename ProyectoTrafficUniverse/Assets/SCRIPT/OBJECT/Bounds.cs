using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {
	private bool limite=false;
	private ScreenValues screenData;
	private float widthObj=0;
	private float heightObj=0;
	private bool limitOutside=false;
	void Start () {
		screenData=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenValues>();
		transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Detect>().OnContactFrontier+=onBoundFrontier;
	}

	void Update () {
//		Debug.Log("UP "+transform.up);
		if(AxisXMin()||AxisYMin()||AxisXMax()||AxisYMax()||limitOutside){
			//print("limite activo");
		limite=true;
		}else{
			limite=false;
		}
//		print("frontier "+limite);
	}
	private bool AxisXMin(){
		if(transform.position.x-widthObj<-screenData.getWidthScene){
			
			//Debug.Log("limite izq "+transform.position.x);
			transform.position=new Vector2(-screenData.getWidthScene+widthObj,transform.position.y);
			return true;
		}
		return false;
	}
	private bool AxisXMax(){
		if(transform.position.x+widthObj>screenData.getWidthScene){
			transform.position=new Vector2 (screenData.getWidthScene-widthObj,transform.position.y);//posiciono el objeto en el punto maximo menos el ancho para q n traiga prblemas cuando le cambie d direccion
			//Debug.Log("limite x max");
			return true;
		}
		return false;
	}
	private bool AxisYMin(){
		if(transform.position.y-heightObj<-screenData.getHeightScene){
			transform.position=new Vector2 (transform.position.x,-screenData.getHeightScene+heightObj);
			//Debug.Log("limite inferior");
			return true;
		}
		return false;
	}
	private bool AxisYMax(){
		if(transform.position.y+heightObj>screenData.getHeightScene){
			transform.position=new Vector2 (transform.position.x,screenData.getHeightScene-heightObj);
	//Debug.Log("limite superior "+transform.position);
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
	public float setWidth{
		set{
			widthObj=value;
		//	print("width b "+widthObj);
		}
	}
	public float setHeight{
		set{
			heightObj=value;
		//	print("height b"+heightObj);
		}
	}
	public bool setLimitOutside{
		set{
			limitOutside=value;
		
		}
			
	}

	public void onBoundFrontier(){
		print("activando frontier");
		limitOutside=true;
	}


}

