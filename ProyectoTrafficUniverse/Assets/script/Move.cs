
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Move:MonoBehaviour {
	protected Rigidbody2D rb;
	public float velocity;
	MoveFirst moveFirst;

	MovePath movePath;
	MoveWhithoutPath moveWhithoutPath;
	public PathInputs pathInputs;

	private bool activePath=false;//para activar el path cuando posteriormente no  lo haya
	private Vector2 finalVec;

	void Awake () {
		rb=GetComponent<Rigidbody2D>();
		//print("rb move "+rb);
	
		moveFirst=new MoveFirst();
		movePath=GetComponent<MovePath>();
		moveWhithoutPath=GetComponent<MoveWhithoutPath>();
		movePath.enabled=false;
		moveWhithoutPath.enabled=false;
	//	moveWhithoutPath=new MoveWhithoutPath();
		//falta aplicar move path bn generar metodo dentro y canalizarlos via update
	}
	void Start(){


	}
	

	void Update () {

		if(pathInputs.path.listNodos.Count>0){
			//path activo


			if(!movePath.enabled){
				movePath.enabled=true;
			}
			if(moveWhithoutPath.enabled){
				moveWhithoutPath.enabled=false;
			}

			//Move_Path();
			//transform.position=Vector2.MoveTowards(posObj,pathInputs.path.listNodos[index].posicion,velocity*Time.deltaTime);
		}else if (movePath.enabled||moveWhithoutPath.enabled){
			//vas a entrar si venis d move path, antes no ya q en el momemnto inicial movePath y moveWhithout path son falsos
					print("final vector");
					if(!movePath.enabled){
					movePath.enabled=false;
					}
					if(moveWhithoutPath.enabled==false){
						moveWhithoutPath.enabled=true;
					}

		}else{
			print("idle");
			Move_Idle();
		}
	//	movePath.Update();

	}
	private void Move_Idle(){
		rb.transform.Translate(moveFirst.MoveIdle()*velocity*Time.deltaTime);
	}

	public Vector2 getFinalVec{
		get{
			return finalVec;
		}
		set{
			finalVec=value;
		}
	}
}
