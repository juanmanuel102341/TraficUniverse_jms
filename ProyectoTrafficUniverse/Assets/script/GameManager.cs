
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameManager : MonoBehaviour {
	public static int aterrizajes=0;
	public static  int vidas=3;
	public static int aviones=0;
	public float frecuencia;
	public GameObject spawnPointLeft;
	public GameObject spawnPointRight;
	public GameObject spawnPointDown;
	//public Bounds bounds;
	public float limitLeft;
	public float limitRight;
	public float limitDown;
	public float limitUp;

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
			//n=1;
			switch(n){
			case 1://**left
				float auxY=Random.Range(limitDown,limitUp);
				SpawnPointUp auxComp=spawnPointLeft.GetComponent<SpawnPointUp>();

				listaObj.Add(Instantiate(auxComp.obj,new Vector2(auxComp.transform.position.x,auxY),auxComp.transform.rotation));
				//auxComp.obj.GetComponent<SetRotation>().setBool=true;
				//auxComp.obj.GetComponent<SetRotation>().setRot=270;

				break;
			case 2:
				//**down
				float auxX=Random.Range(limitLeft,limitRight);
				SpawnPointUp auxComp2=spawnPointDown.GetComponent<SpawnPointUp>();
				listaObj.Add(Instantiate(auxComp2.obj,new Vector2(auxX,auxComp2.transform.position.y),auxComp2.transform.rotation));
				break;
			case 3:
				//**right

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

}
