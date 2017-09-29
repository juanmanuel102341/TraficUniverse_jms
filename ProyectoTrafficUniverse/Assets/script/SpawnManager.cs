﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnManager : MonoBehaviour {
	
	public float frecuencia;

//	private float limitMinX;
//	private float limitMaxX;
//	private float limitMinY;
//	private float limitMaxY;
//
//	public Transform tLimitMinX;
//	public Transform tLimitMaxX;
//	public Transform tLimitMinY;
//	public Transform tLimitMaxY;

	public GameObject objA;
	public GameObject objB;
	public GameObject objC;
	private float time;

	private List<GameObject>listaObj=new List<GameObject>();
	private ScreenValues screenData;
	//private float widthA;


	void Awake () {
		time=frecuencia;


//		limitMinX=tLimitMinX.position.x;
//		limitMaxX=tLimitMaxX.position.x;
//		limitMinY=tLimitMinY.position.y;
//		limitMaxY=tLimitMaxY.position.y;
		//	widthA=objA.GetComponent<SpriteRenderer>().bounds.extents;
	}
	void Start(){
		screenData=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenValues>();
	}
	
	// Update is called once per frame
	void Update () {
		time+=Time.deltaTime;	


		if(time>frecuencia){
			float widthObj;
			float heightObj;
			GameObject obj;
			int n=GetRandomSpawns(1,5);
			n=1;
			switch(n){
			case 1://**left
				
				obj=GetObjetRandom();
			
				widthObj=obj.GetComponent<SpriteRenderer>().bounds.extents.x;//ancho del objeto dividido 2
				heightObj=obj.GetComponent<SpriteRenderer>().bounds.extents.y;//alto div2

				obj.GetComponent<Bounds>().setWidth=widthObj;//seteo del width del obj para calculo de bounds
				obj.GetComponent<Bounds>().setHeight=heightObj;
				GenerateSpawn(obj,-screenData.getWidthScene+widthObj,-screenData.getHeightScene+widthObj,screenData.getHeightScene-heightObj,false,270);
			//	GenerateSpawn(obj,limitMinX,limitMinY,limitMaxY,false,270);
				break;
			case 2:
				//down
				obj=GetObjetRandom();

				widthObj=obj.GetComponent<SpriteRenderer>().bounds.extents.x;//ancho del objeto dividido 2
				heightObj=obj.GetComponent<SpriteRenderer>().bounds.extents.y;//alto div2
				obj.GetComponent<Bounds>().setWidth=widthObj;//seteo del width del obj para calculo de bounds
				obj.GetComponent<Bounds>().setHeight=heightObj;
				GenerateSpawn(obj,-screenData.getHeightScene+heightObj,-screenData.getWidthScene+widthObj,screenData.getWidthScene-widthObj,true,0);
			//	GenerateSpawn(obj,limitMaxY,limitMinX,limitMaxX,true,0);
				break;
			case 3:
				//**right
				obj=GetObjetRandom();

				widthObj=obj.GetComponent<SpriteRenderer>().bounds.extents.x;//ancho del objeto dividido 2
				heightObj=obj.GetComponent<SpriteRenderer>().bounds.extents.y;//alto div2
				obj.GetComponent<Bounds>().setWidth=widthObj;//seteo del width del obj para calculo de bounds
				obj.GetComponent<Bounds>().setHeight=heightObj;
				GenerateSpawn(obj,screenData.getWidthScene-widthObj,-screenData.getHeightScene+heightObj,screenData.getHeightScene-heightObj,false,90);
			//	GenerateSpawn(obj,limitMaxX,limitMinY,limitMaxY,false,90);
				break;
			case 4:
				//up
				obj=GetObjetRandom();

				widthObj=obj.GetComponent<SpriteRenderer>().bounds.extents.x;//ancho del objeto dividido 2
				heightObj=obj.GetComponent<SpriteRenderer>().bounds.extents.y;//alto div2
				obj.GetComponent<Bounds>().setWidth=widthObj;//seteo del width del obj para calculo de bounds
				obj.GetComponent<Bounds>().setHeight=heightObj;
				GenerateSpawn(obj,screenData.getHeightScene-heightObj,-screenData.getWidthScene+widthObj,screenData.getWidthScene-widthObj,true,180);
			//	GenerateSpawn(obj,limitMinY,limitMinX,limitMaxX,true,180);
				break;
				}
			time=0;
		}
	}
	private int  GetRandomSpawns(int v1,int v2Exclusive){
		return Random.Range(v1,v2Exclusive);  
	}

	public List<GameObject> getValuesList{
		get{
			return listaObj;
		}
	}
	public void GetOutObjectFromList(GameObject obj){
		listaObj.Remove(obj);
	}
	private void GenerateSpawn(GameObject _obj,float ptoFijoSalida,float r1,float r2,bool fijoY,float rot){
		if(fijoY){
			//up down, varia x 
			Vector2 spawnfY;
			spawnfY.x=Random.Range(r1,r2);
			spawnfY.y=ptoFijoSalida;
			GameObject auxObjFY=Instantiate(_obj,spawnfY,transform.rotation);
			auxObjFY.transform.Rotate(new Vector3(0,0,rot));
			listaObj.Add(auxObjFY);
		
		}else{
		//right left fijo x , varia y
			Vector2 spawnFX;
			spawnFX.x=ptoFijoSalida;
			spawnFX.y=Random.Range(r1,r2);
			GameObject auxObjFX=Instantiate(_obj,spawnFX,transform.rotation);
			auxObjFX.transform.Rotate(new Vector3(0,0,rot));
			listaObj.Add(auxObjFX);
		}
			
	}
	private GameObject GetObjetRandom(){
		int r=GetRandomSpawns(1,4);
		switch (r){
		case 1:
			return objA;
//			break;
		case 2:
			return objB;
//			break;
		case 3:
			return objC;
//			break;
		}

		return objA;
	}
	public List<GameObject> getListaNaves{
		get{
			return listaObj;
		}
		set{
			listaObj=value;
		}

	}
	
}
