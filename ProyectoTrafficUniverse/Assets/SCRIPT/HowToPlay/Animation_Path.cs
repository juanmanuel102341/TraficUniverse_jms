using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Path : MonoBehaviour {
	private bool activate=false;
	private bool finish=false;
	private List<GameObject> objs=new List<GameObject>();
	private Vector2 currentVector;
	private float time=0;
	public float frameRate;
	private int index=0;
	private int n;
	private MovePointer movePointer;
	void Awake () {
		n=transform.childCount;
		movePointer=GameObject.FindGameObjectWithTag("pointer").GetComponent<MovePointer>();
	//	print("cantidad de objetos "+n);
		for(int i=0;i<n;i++){
			objs.Add(transform.GetChild(i).gameObject);
			//print("obj"+transform.GetChild(0).gameObject.transform.GetChild(i).gameObject);
		}
	//	print("obj 1ro "+objs[0].name);
	//	print("obj 1ro "+objs[0].transform.position);
		//activate=true;
	}
	
	// Update is called once per frame
	void Update () {
		if(activate){
			time+=Time.deltaTime;
			if(time>frameRate){
				//print("entrando ");
				objs[index].SetActive(true);
				currentVector=objs[index].transform.position;
				movePointer.SetDestiny(currentVector);
				time=0;
				index++;
//				print("currentVector "+currentVector);
				if(index>=n){
//					print("fin de animacion");
					activate=false;
					finish=true;
				}
			}
		}
	}

	public bool getActive{
		get{
			return activate;
		}
		set{
			activate=value;
		}
	}
	public Vector2 getCurrentVector{
		get{
			return currentVector;

		}
	}
	public bool getFinish{
		get{
			return finish;
		}
	}
	public void DeleteNodes(){
		for(int i=0;i<objs.Count;i++){
			GameObject aux=objs[i];
			Destroy(aux);
		}
		objs.RemoveRange(0,objs.Count);
		Destroy(this.gameObject);
	}

}


