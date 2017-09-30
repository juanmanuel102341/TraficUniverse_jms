
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Move:MonoBehaviour {
	protected Rigidbody2D rb;
	public float velocity;
	MoveFirst moveFirst;
	MovePath movePath;
	MoveWhithoutPath moveWhithoutPath;
	private PathInputs pathInputs;
	private Bounds bounds;

	private Vector2 finalVec;
	private int direction=1;
	void Awake () {
		rb=GetComponent<Rigidbody2D>();
		//print("rb move "+rb);
		bounds=GetComponent<Bounds>();
		pathInputs=GetComponent<PathInputs>();
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

		if(pathInputs.path.listNodes.Count>0){
			//path activo
			//****************momento path*****************************
			if(!movePath.enabled){
				movePath.enabled=true;
			}
			if(moveWhithoutPath.enabled){
				//si volves de movewhithout path, osea si generaste un path anteriormente y ya los recorrsite
				moveWhithoutPath.setBooleanDirection=false;
				moveWhithoutPath.enabled=false;
			}

			//Move_Path();
			//transform.position=Vector2.MoveTowards(posObj,pathInputs.path.listNodos[index].posicion,velocity*Time.deltaTime);
		}else if (movePath.enabled||moveWhithoutPath.enabled){
			//vas a entrar si venis d move path, antes no ya q en el momemnto inicial movePath y moveWhithout path son falsos

			//******************despues de quedarme sin nodos**********************************
			print("final vector");
					if(!movePath.enabled){
					movePath.enabled=false;
					}
					if(moveWhithoutPath.enabled==false){
						moveWhithoutPath.enabled=true;
					}
					
			}else{
			//******************momento inicial sin nodos**************************
					//			print("idle");
					Move_Idle();
					}
		}
	private void Move_Idle(){
		Direction();
		transform.Translate(moveFirst.MoveIdle()*direction* velocity*Time.deltaTime);

	}

	public Vector2 getFinalVec{
		get{
			return finalVec;
		}
		set{
			finalVec=value;
		}
	}
	public PathInputs getPathInputs{
		get{
			return pathInputs;
		}
	}
	public void Direction(){
		if(bounds.limiteActive){
			print("limite idle");
			bounds.limiteActive=false;
			transform.up=-transform.up;//cambio vector por el sentido contrario
		}

	
	}
}
