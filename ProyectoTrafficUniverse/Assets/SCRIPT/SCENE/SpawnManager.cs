using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnManager : MonoBehaviour {
	public float frecuencia;
	public GameObject[] objs;
	private float time;
	private List<GameObject>listaObj=new List<GameObject>();
	private ScreenValues screenData;
	void Awake () {
//		print("obj a "+objA);
//		print("obj b "+objB);
//		print("obj c "+objC);
		time=frecuencia;
		}
	void Start(){
		screenData=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenValues>();
	}
	void Update () {
		time+=Time.deltaTime;	
		if(time>frecuencia){
			float widthObj;
			float heightObj;

			GameObject obj;

			int n=Random.Range(0,4);//random entre los 4 costados dela screen
			switch(n){
			case 0://**left
				print("red spawn");
				obj=GetObjetRandom(0,objs.Length);
				widthObj=obj.GetComponent<SpriteRenderer>().bounds.extents.x;//ancho del objeto dividido 2
				heightObj=obj.GetComponent<SpriteRenderer>().bounds.extents.y;//alto div2
				obj.GetComponent<Bounds>().setWidth=widthObj;//seteo del width del obj para calculo de bounds
				obj.GetComponent<Bounds>().setHeight=heightObj;
				GenerateSpawn(obj,-screenData.getWidthScene+widthObj,-screenData.getHeightScene+widthObj,screenData.getHeightScene-heightObj,false,270);
				break;
			case 1:
				//down
				obj=GetObjetRandom(0,objs.Length);
				widthObj=obj.GetComponent<SpriteRenderer>().bounds.extents.x;//ancho del objeto dividido 2
				heightObj=obj.GetComponent<SpriteRenderer>().bounds.extents.y;//alto div2
				obj.GetComponent<Bounds>().setWidth=widthObj;//seteo del width del obj para calculo de bounds
				obj.GetComponent<Bounds>().setHeight=heightObj;
				GenerateSpawn(obj,-screenData.getHeightScene+heightObj,-screenData.getWidthScene+widthObj,screenData.getWidthScene-widthObj,true,0);
				break;
			case 2:
				//**right
				obj=GetObjetRandom(0,objs.Length);
				widthObj=obj.GetComponent<SpriteRenderer>().bounds.extents.x;//ancho del objeto dividido 2
				heightObj=obj.GetComponent<SpriteRenderer>().bounds.extents.y;//alto div2
				obj.GetComponent<Bounds>().setWidth=widthObj;//seteo del width del obj para calculo de bounds
				obj.GetComponent<Bounds>().setHeight=heightObj;
				GenerateSpawn(obj,screenData.getWidthScene-widthObj,-screenData.getHeightScene+heightObj,screenData.getHeightScene-heightObj,false,90);
				break;
			case 3:
				//up
				obj=GetObjetRandom(0,objs.Length);
				widthObj=obj.GetComponent<SpriteRenderer>().bounds.extents.x;//ancho del objeto dividido 2
				heightObj=obj.GetComponent<SpriteRenderer>().bounds.extents.y;//alto div2
				obj.GetComponent<Bounds>().setWidth=widthObj;//seteo del width del obj para calculo de bounds
				obj.GetComponent<Bounds>().setHeight=heightObj;
				GenerateSpawn(obj,screenData.getHeightScene-heightObj,-screenData.getWidthScene+widthObj,screenData.getWidthScene-widthObj,true,180);
				break;
				}
			time=0;
		}
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
	private GameObject GetObjetRandom(int v1,int v2){
		int r=Random.Range(v1,v2);
		//r=3;
		switch (r){
		case 0:
			return objs[r];

		case 1:
			return  objs[r];

		case 2:
			return objs[r];

		}

		return  objs[r];
	}
	public List<GameObject> getListPlanes{
		get{
			return listaObj;
		}
		set{
			listaObj=value;
		}

	}
	
}
