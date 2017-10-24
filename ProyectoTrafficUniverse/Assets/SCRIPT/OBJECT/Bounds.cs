using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {
	private bool limite=false;
	private ScreenValues screenData;
	private float widthObj=0;
	private float heightObj=0;
	void Start () {
		screenData=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenValues>();
	}

	void Update () {
		if(AxisXMin()||AxisYMin()||AxisXMax()||AxisYMax()){
			//print("limite activo");
			limite=true;		
		}else{
			limite=false;
		}
	}
	private bool AxisXMin(){
		if(transform.position.x-widthObj<-screenData.getWidthScene){
			

			transform.position=new Vector2(-screenData.getWidthScene+widthObj,transform.position.y);
//			print("w "+widthObj);
//			print("scene max "+widthScene);
//			print("lim x min "+l);
//			print("pos x "+transform.position.x);
			return true;
		}
		return false;
	}
	private bool AxisXMax(){
		if(transform.position.x+widthObj>screenData.getWidthScene){
			transform.position=new Vector2 (screenData.getWidthScene-widthObj,transform.position.y);//posiciono el objeto en el punto maximo menos el ancho para q n traiga prblemas cuando le cambie d direccion
			return true;
		}
		return false;
	}
	private bool AxisYMin(){
		if(transform.position.y-heightObj<-screenData.getHeightScene){
			transform.position=new Vector2 (transform.position.x,-screenData.getHeightScene+heightObj);
			return true;
		}
		return false;
	}
	private bool AxisYMax(){
		if(transform.position.y+heightObj>screenData.getHeightScene){
			transform.position=new Vector2 (transform.position.x,screenData.getHeightScene-heightObj);
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
}

