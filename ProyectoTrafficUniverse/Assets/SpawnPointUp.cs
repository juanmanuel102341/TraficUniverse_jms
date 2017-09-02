
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnPointUp : MonoBehaviour {

	public GameObject obj;
	public float limiteInferior;
	public float limiteSuperior;
	public float frecuenciaSpawn; 
	private float time;
	private List<GameObject>listaObjA=new List<GameObject>();
	private float widthObj;
	private float heihtObj;
	private Vector2 myPos;
	//private Transform transformObj;
	void Awake () {
		myPos.x=transform.position.x;
		myPos.y=transform.position.y;
		//widthObj=GetComponent<SpriteRenderer>().bounds.max.x
	//	transformObj=GetComponent<Transform>();
	}
	

	void Update () {
		time+=Time.deltaTime;
		if(time>frecuenciaSpawn){
			float auxX=Random.Range(limiteInferior,limiteSuperior);
			listaObjA.Add(Instantiate(obj,new Vector2(auxX,transform.position.y),transform.rotation));
			time=0;
		}
	}
	public Vector2 getPositionSpawn{
		get{
			return myPos;
		}
	}
}
