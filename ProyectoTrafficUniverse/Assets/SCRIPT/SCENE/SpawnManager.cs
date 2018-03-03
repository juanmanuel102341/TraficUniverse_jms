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
	public SoundManager soundManager;
	public GuiTarget guiTarget;
	public Gui guiLifes;
	private GameManager gameManager;



	void Awake () {
		detectsIdEvent=GetComponent<DetectsId>();
		time=frecuencia;
	//	frecuencia=TimeLerp(rangeTime[0],rangeTime[1]);
		frecuencia=2;//tiro frecuencia yo para q el usuario n tenga q esperar tanto
//		print("freuenncia "+frecuencia);
		gameManager=GetComponent<GameManager>();
	



	
	}
	void Start(){
		screenData=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenValues>();
	}
	void Update () {
		if(!SpawnLimitActive()){
		time+=Time.deltaTime;	
		}
		if(time>frecuencia&&!SpawnLimitActive()){
			int total=1;
				//QuantityEnemys(rangeQuantity[0],rangeQuantity[1]);
		
			//total=2;
			int aux=0;
//			print("total "+total);
			for(int i=0;i<total;i++){
				if(!SpawnLimitActive()){
					//condicion para q nme agregue otra nave si paso el limite
					float widthObj;
					float heightObj;
					GameObject obj;
					int n=Random.Range(0,4);//random entre los 4 costados dela screen
						
						//print("anterior "+aux);
						//print("actual "+n);
						if(aux==n){
						//	print("iguales cambiando costado");
							if(n!=3){
								n++;
						//		print("sumo uno");
							}else{
							n--;
							//		print("resto 1");
							}
						}else{
							aux=n;	
						}
					//n=2;
				switch(n){
					case 0://**left
						print( "spawn izquierda");
						obj=GetObjetRandom(0,objs.Length);
						widthObj=obj.GetComponent<Transform>().localScale.x/2;//ancho del objeto dividido 2
						heightObj=obj.GetComponent<Transform>().localScale.y/2;//alto div2
						obj.GetComponent<Bounds>().setWidth=widthObj;
						obj.GetComponent<Bounds>().setHeight=heightObj;

						GenerateSpawn(obj,-screenData.getWidthScene+widthObj,-screenData.getHeightScene+widthObj,screenData.getHeightScene-heightObj,false,90,Vector2.right);
						break;
					case 1:
						//down
					obj=GetObjetRandom(0,objs.Length);
						widthObj=obj.GetComponent<Transform>().localScale.x/2;//ancho del objeto dividido 2
						heightObj=obj.GetComponent<Transform>().localScale.y/2;//alto div2
						obj.GetComponent<Bounds>().setWidth=widthObj+10;//seteo del width del obj para calculo de bounds
						obj.GetComponent<Bounds>().setHeight=heightObj;

						GenerateSpawn(obj,-screenData.getHeightScene+heightObj,-screenData.getWidthScene+widthObj,screenData.getWidthScene-widthObj,true,0,Vector2.up);

						break;
					case 2:
						//**right
						obj=GetObjetRandom(0,objs.Length);
						widthObj=obj.GetComponent<Transform>().localScale.x/2;//ancho del objeto dividido 2
						heightObj=obj.GetComponent<Transform>().localScale.y/2;//alto div2
						obj.GetComponent<Bounds>().setWidth=widthObj;//seteo del width del obj para calculo de bounds
						obj.GetComponent<Bounds>().setHeight=heightObj;
						GenerateSpawn(obj,screenData.getWidthScene-widthObj,-screenData.getHeightScene+heightObj,screenData.getHeightScene-heightObj,false,90,Vector2.left);
						break;
					case 3:
						//up
					obj=GetObjetRandom(0,objs.Length);
						widthObj=obj.GetComponent<Transform>().localScale.x/2;//ancho del objeto dividido 2
						heightObj=obj.GetComponent<Transform>().localScale.y/2;//alto div2
						obj.GetComponent<Bounds>().setWidth=widthObj;//seteo del width del obj para calculo de bounds
						obj.GetComponent<Bounds>().setHeight=heightObj;
						GenerateSpawn(obj,screenData.getHeightScene-heightObj,-screenData.getWidthScene+widthObj,screenData.getWidthScene-widthObj,true,180,Vector2.down);
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

	private void GenerateSpawn(GameObject _obj,float ptoFijoSalida,float r1,float r2,bool fijoY,float rot,Vector2 myVectorOut){
		if(fijoY){
			//up down, varia x 
			Vector2 spawnfY;
			float restrictionX=r1+screenData.getConstrainGui.x;
			string esq="up";
			if(myVectorOut==Vector2.up){
				//down x minimo no me importa
				//print("entrando restriccion");
				restrictionX=r1;//no aplica para ese costado la restriccion x eso pongo el ancho de escena
				esq="down";
			}
		
//			print(" screem width "+screenData.getWidthScene);
//			print("r1 "+r1);
//			print("r2 "+r2);
//			print("screenData.getConstrainGui.x" +screenData.getConstrainGui.x);
		
			spawnfY.x=Random.Range(restrictionX+5,r2-screenData.getConstrainGui.x);
			//spawnfY.x=restrictionX+5;
			//spawnfY.x=r2-screenData.getConstrainGui.x;
			spawnfY.y=ptoFijoSalida;
			//print("spanw "+spawnfY);
			GameObject auxObjFY=Instantiate(_obj,spawnfY,transform.rotation);
			//auxObjFY.transform.Rotate(0,0,rot);
			auxObjFY.GetComponent<MyAnimations>().setAngleBetween=rot;
			auxObjFY.GetComponent<MoveSoft>().setMyVector=myVectorOut;
			detectsIdEvent.EventStart(auxObjFY);
			if(MyParams.soundActive){
			soundManager.Events(auxObjFY);
			}
			auxObjFY.GetComponent<IdInicial>().SetMySprite(esq);
			guiTarget.EventsMe(auxObjFY);
			guiLifes.Events(auxObjFY);
			gameManager.Events(auxObjFY);

			listaObj.Add(auxObjFY);
		
		}else{
		//right left fijo x , varia y
			Vector2 spawnFX;
			string esq="right";
			spawnFX.x=ptoFijoSalida;
			float restrictionY=r1+screenData.getConstrainGui.y;
			if(myVectorOut==Vector2.right){
				//esquina izquierda 
				restrictionY=r1;
				esq="left";
		//		print("entrando restriccion fijox");
			}

			spawnFX.y=Random.Range(r2-screenData.getConstrainGui.y,restrictionY+5);
			//spawnFX.y=restrictionY+5;
			//spawnFX.y=r2-screenData.getConstrainGui.y;
		//	print("spawn fijo x "+spawnFX );
			GameObject auxObjFX=Instantiate(_obj,spawnFX,transform.rotation);
			auxObjFX.GetComponent<MyAnimations>().setAngleBetween=rot;
			auxObjFX.GetComponent<MoveSoft>().setMyVector=myVectorOut;

			if(myVectorOut==Vector2.left){
				auxObjFX.GetComponent<SpriteRenderer>().flipX=true;
			}
			//auxObjFX.transform.Rotate(0,0,rot);
			detectsIdEvent.EventStart(auxObjFX);
			if(MyParams.soundActive){
			soundManager.Events(auxObjFX);
			}
			auxObjFX.GetComponent<IdInicial>().SetMySprite(esq);
			guiTarget.EventsMe(auxObjFX);
			guiLifes.Events(auxObjFX);
			gameManager.Events(auxObjFX);
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
