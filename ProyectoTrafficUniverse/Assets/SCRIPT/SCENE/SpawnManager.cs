using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnManager : MonoBehaviour {
	private float frecuencia;
	public float []rangeTime=new float[2];
	public GameObject[] objs;
	public int totalEnemysLimit;//cuantos enemigos peuden haber en total al mismo tiempo, para n enloquecer al usuario y regular mejor la dinamica de la dificultad, a su veez tb q n se me desmadre a nivel performance
	public int[] rangeQuantity=new int[2];
 	private float time;
	private List<GameObject>listaObj=new List<GameObject>();
	private ScreenValues screenData;
	private bool resetTime=false;//booleano q utilizo para cuando llega al limite d naves y n tenga q 
	private DetectsId detectsIdEvent;
	void Awake () {
		detectsIdEvent=GetComponent<DetectsId>();
		time=frecuencia;
	//	frecuencia=TimeLerp(rangeTime[0],rangeTime[1]);
		frecuencia=2;//tiro frecuencia yo para q el usuario n tenga q esperar tanto
		print("freuenncia "+frecuencia);
		}
	void Start(){
		screenData=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenValues>();
	}
	void Update () {
		if(!SpawnLimitActive()){
		time+=Time.deltaTime;	
		}
		if(time>frecuencia&&!SpawnLimitActive()){
			int total=QuantityEnemys(rangeQuantity[0],rangeQuantity[1]);
			//total=2;
			int aux=0;
			print("total "+total);
			for(int i=0;i<total;i++){
				if(!SpawnLimitActive()){
					//condicion para q nme agregue otra nave si paso el limite
					float widthObj;
					float heightObj;
					GameObject obj;
					int n=Random.Range(0,4);//random entre los 4 costados dela screen
					if(i>=1){
						print("anterior "+aux);
						print("actual "+n);
						if(aux==n){
							print("iguales cambiando costado");
							if(n!=3){
								n++;
								print("sumo uno");
							}else{
								n--;
								print("resto 1");
							}
						}
					}else{
						aux=n;			
					}
			

					//n=3;
				
					switch(n){
				
					case 0://**left
		//				print("red spawn");
						obj=GetObjetRandom(0,objs.Length);
						widthObj=obj.GetComponent<Transform>().localScale.x/2;//ancho del objeto dividido 2
						heightObj=obj.GetComponent<Transform>().localScale.y/2;//alto div2
						
						obj.GetComponent<Bounds>().setWidth=widthObj;
						obj.GetComponent<Bounds>().setHeight=heightObj;
						GenerateSpawn(obj,-screenData.getWidthScene+widthObj,-screenData.getHeightScene+widthObj,screenData.getHeightScene-heightObj,false,270);
						break;
					case 1:
						//down
					obj=GetObjetRandom(0,objs.Length);
						widthObj=obj.GetComponent<Transform>().localScale.x/2;//ancho del objeto dividido 2
						heightObj=obj.GetComponent<Transform>().localScale.y/2;//alto div2
						obj.GetComponent<Bounds>().setWidth=widthObj;//seteo del width del obj para calculo de bounds
						obj.GetComponent<Bounds>().setHeight=heightObj;
						GenerateSpawn(obj,-screenData.getHeightScene+heightObj,-screenData.getWidthScene+widthObj,screenData.getWidthScene-widthObj,true,0);

						break;
					case 2:
						//**right
						obj=GetObjetRandom(0,objs.Length);
						widthObj=obj.GetComponent<Transform>().localScale.x/2;//ancho del objeto dividido 2
						heightObj=obj.GetComponent<Transform>().localScale.y/2;//alto div2
						obj.GetComponent<Bounds>().setWidth=widthObj;//seteo del width del obj para calculo de bounds
						obj.GetComponent<Bounds>().setHeight=heightObj;
						GenerateSpawn(obj,screenData.getWidthScene-widthObj,-screenData.getHeightScene+heightObj,screenData.getHeightScene-heightObj,false,90);
						break;
					case 3:
						//up
					obj=GetObjetRandom(0,objs.Length);
						widthObj=obj.GetComponent<Transform>().localScale.x/2;//ancho del objeto dividido 2
						heightObj=obj.GetComponent<Transform>().localScale.y/2;//alto div2
						obj.GetComponent<Bounds>().setWidth=widthObj;//seteo del width del obj para calculo de bounds
						obj.GetComponent<Bounds>().setHeight=heightObj;
						GenerateSpawn(obj,screenData.getHeightScene-heightObj,-screenData.getWidthScene+widthObj,screenData.getWidthScene-widthObj,true,180);
						break;
						}
			
			
				if(i+1==total){
						//print("limite naves 1 cond");
						ResetValues();
					}
				}else{
				//	print("limite naves 2 cond");
					ResetValues();
				}
			}

		}
	}
	private void ResetValues(){
		//print("ultima tanda");
		time=0;
		frecuencia=TimeLerp(rangeTime[0],rangeTime[1]);
//		print("nueva frecuancia "+frecuencia);
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
			auxObjFY.transform.Rotate(0,0,rot);
			detectsIdEvent.EventStart(auxObjFY);
			listaObj.Add(auxObjFY);
		
		}else{
		//right left fijo x , varia y
			Vector2 spawnFX;
			spawnFX.x=ptoFijoSalida;
			spawnFX.y=Random.Range(r1,r2);
			GameObject auxObjFX=Instantiate(_obj,spawnFX,transform.rotation);
			auxObjFX.transform.Rotate(0,0,rot);
			detectsIdEvent.EventStart(auxObjFX);
			listaObj.Add(auxObjFX);
		}
			
	}
	private GameObject GetObjetRandom(int v1,int v2){
		int r=Random.Range(v1,v2);
		//r=2;
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
	private float TimeLerp(float v1,float v2){
		return Random.Range(v1,v2);
	}
	private int QuantityEnemys(int v1, int v2){
		return Random.Range(v1,v2);
	}
	private bool SpawnLimitActive(){
	
		if(listaObj.Count>=totalEnemysLimit){
//			print("limite spawn activo");
			return true;
		}
		return false;
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
