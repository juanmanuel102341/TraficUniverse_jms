
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnManager : MonoBehaviour {
	public static int aterrizajes=0;
	public static  int vidas=3;
	public static int aviones=0;
	public float frecuencia;

	public float limitLeft;
	public float limitRight;
	public float limitDown;
	public float limitUp;
	public GameObject obj;
	private float time;
	private List<GameObject>listaObj=new List<GameObject>();
	void Awake () {
		time=frecuencia;
	}
	
	// Update is called once per frame
	void Update () {
		time+=Time.deltaTime;	
		if(aviones==2){
			vidas--;
			aviones=0;
		}

		if(time>frecuencia){
			int n=GetRandomSpawns();

			switch(n){
			case 1://**left
				GenerateSpawn(limitLeft,limitDown,limitUp,270,false);//genero un spawn a la izquierda,entre un random de y de los extremos y una rotacion especfica
				break;
			case 2:
				//down
				GenerateSpawn(limitDown,limitLeft,limitRight,0,true);//generp un spawn en el nivel inferior q varia en x de los extremos,rotacion 0 "va para arriba"
				break;
			case 3:
				//**right
				GenerateSpawn(limitRight,limitDown,limitUp,90,false);
				break;
			case 4:
				//up
				GenerateSpawn(limitUp,limitLeft,limitRight,180,true);
				break;
				}
			time=0;
		}
	}
	private int  GetRandomSpawns(){
		return Random.Range(1,4);  
	}

	public List<GameObject> getValuesList{
		get{
			return listaObj;
		}
	}
	public void GetOutObjectFromList(GameObject obj){
		listaObj.Remove(obj);
	}
	private void GenerateSpawn(float ptoFijoSalida,float r1,float r2,float rotacion,bool fijoY){
		if(fijoY){
			//up down, varia x 
			Vector2 spawnfY;
			spawnfY.x=Random.Range(r1,r2);
			spawnfY.y=ptoFijoSalida;
			GameObject auxObjFY=Instantiate(obj,spawnfY,transform.rotation);
			auxObjFY.transform.Rotate(new Vector3(0,0,rotacion));
			listaObj.Add(auxObjFY);
		
		}else{
		//right left fijo x , varia y
			Vector2 spawnFX;
			spawnFX.x=ptoFijoSalida;
			spawnFX.y=Random.Range(r1,r2);
			GameObject auxObjFX=Instantiate(obj,spawnFX,transform.rotation);
			auxObjFX.transform.Rotate(new Vector3(0,0,rotacion));
			listaObj.Add(auxObjFX);
		}

		
	}

}
