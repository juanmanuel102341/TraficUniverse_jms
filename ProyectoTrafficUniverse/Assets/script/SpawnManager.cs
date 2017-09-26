
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnManager : MonoBehaviour {
	
	public float frecuencia;

	public float limitLeft;
	public float limitRight;
	public float limitDown;
	public float limitUp;
	public GameObject objA;
	public GameObject objB;
	public GameObject objC;
	private float time;
	private Bounds bounds;
	private List<GameObject>listaObj=new List<GameObject>();
	//private float widthA;
	GameObject obj;
	void Awake () {
		time=frecuencia;
		bounds=objA.GetComponent<Bounds>();
	//	widthA=objA.GetComponent<SpriteRenderer>().bounds.extents;
	}
	
	// Update is called once per frame
	void Update () {
		time+=Time.deltaTime;	


		if(time>frecuencia){
			int n=GetRandomSpawns(1,4);

			switch(n){
			case 1://**left
				
				obj=GetObjetRandom();

				GenerateSpawn(obj,limitLeft,limitDown,limitUp,false,270);
				//float w=obj.GetComponent<SpriteRenderer>().bounds.extents.x;
				//w+=0.8f;
				//obj.GetComponent<Move>().setVecInitial=transform.right;
			//GenerateSpawn(obj,bounds.lWidth_izq,bounds.lHeight_down,bounds.lHeight_up,obj.transform.up,false);//genero un spawn a la izquierda,entre un random de y de los extremos y una rotacion especfica
			
				break;
			case 2:
				//down
				obj=GetObjetRandom();
				GenerateSpawn(obj,limitDown,limitLeft,limitRight,true,0);
				//GenerateSpawn(obj,bounds.lHeight_down,bounds.lWidth_izq,bounds.lWidth_der,obj.transform.up,true);//generp un spawn en el nivel inferior q varia en x de los extremos,rotacion 0 "va para arriba"
				break;
			case 3:
				//**right
				obj=GetObjetRandom();
				GenerateSpawn(obj,limitRight,limitDown,limitUp,false,90);
				//GenerateSpawn(obj,bounds.lWidth_der,bounds.lHeight_down,bounds.lHeight_up,obj.transform.right,false);
				break;
			case 4:
				//up
				obj=GetObjetRandom();
				GenerateSpawn(obj,limitUp,limitLeft,limitRight,true,180);
				//GenerateSpawn(obj,bounds.lHeight_up,bounds.lWidth_izq,bounds.lWidth_der,obj.transform.up,true);
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
			break;
		case 2:
			return objB;
			break;
		case 3:
			return objC;
			break;
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
