using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	private Rigidbody2D rb;
	private Path path;
	public float velocity;
	private Vector2 currentPath;
	private int index=0;
	private bool empty2=true;
	private Vector2 vecLast;
	private Bounds bounds;
	private Vector2 vecEmpty;
	private Vector2 vecPath;
	private Vector2 vecDirection;
	private bool calcLast=false;
	private bool boolEmpty=false;
	private bool boolPath=false;
	private bool ejeX=false;
	private int direc=1;
	void Awake () {
				path=GetComponent<Path>();
		rb=GetComponent<Rigidbody2D>();	
		bounds=GetComponent<Bounds>();

		if(transform.position.x<=bounds.lWidth_izq||transform.position.x>=bounds.lWidth_der){
			ejeX=true;
			if(transform.position.x>=bounds.lWidth_der){
				direc=1;
			}else{
				direc=-1;
			}
		//	print("entrando eje x "+ejeX);
		}else{
			ejeX=false;
			if(transform.position.y>=bounds.lHeight_down){
				direc=-1;
			}else{
				direc=-1;		
			}

		
		//	print("entrando otro eje x"+ejeX);
		}

	}
	

	void Update () {
		
		if(path.getPathVectors.Count>0&&index<path.getPathVectors.Count){

			print ("entrando desde move ");
			//first=false;
			//path.getEmpty=false;
			//mb.enabled=false;
			calcLast=false;

			if(empty2){
			empty2=false;
				//print(" setteo empty "+empty2);
			
			}

			if(!bounds.limiteActive){
			currentPath=path.getPathVectors[index];
			vecDirection=GettingDirection(MyPos());


			transform.position=Vector2.MoveTowards(MyPos(),currentPath,velocity*Time.deltaTime);
			transform.up=vecDirection;
			//print("transform up path"+transform.up);	
			Finish();
			}else{
			//	print("limite activo "+bounds.idLimite);
				path.RemovePaths();
				calcLast=true;
				vecLast=bounds.ChangeVector();
			}
		}else if(!empty2){
		//	print("entrando path sin path");
			if(calcLast==false){
				vecLast=path.getLastVector;				
				calcLast=true;
			}

			if(bounds.limiteActive){
			//	print("bound active "+bounds.idLimite);
				vecLast=bounds.ChangeVector();
				//vecLast*=-1;
			}
			//transform.up=path.getLastVector;
			rb.transform.Translate(vecLast*velocity*Time.deltaTime);
			//print("transform up last "+path.getLastVector);
			//print("bound "+bounds.limiteActive);

		}else if(empty2){
		//	print("eje x "+ejeX);
			if(boolEmpty==false){
				
				if(ejeX){
				//	print("vec right");
					vecEmpty=transform.right*direc;
				}else{
				//	print("vec up ");
					vecEmpty=transform.up;
				}
				boolEmpty=true;
			}

			if(bounds.limiteActive){
				print("bound acttive "+bounds.idLimite);
				vecEmpty=bounds.ChangeVector();
			}
			print("empty up "+vecEmpty);
			rb.transform.Translate(vecEmpty*velocity*Time.deltaTime,Space.Self);//no se porq tengo q restar por -1, ya q sn lo hago "me va para las coordenadas contrarias

		}
				

	}

	private Vector2 MyPos(){
	Vector2 aux;
	aux.x=transform.position.x;
	aux.y=transform.position.y;
	return aux;
	}
	private void Finish(){
		if(Vector2.Distance(MyPos(),currentPath)<=0.0f){
		//	print("cambio desde move");
			index++;
			boolPath=false;
		}

	}
	public int setIndex_m{
		set{
			index=value;
		}
	}
	private Vector2 GettingDirection(Vector2 pos){
		Vector2 aux;
//			print("vector path");
		aux=currentPath-pos;

		return aux;
	}
	public Vector2 setVecInitial{
		set{
			
			vecEmpty=value;
			//print("vec emp "+vecEmpty);
		}
	}
	public bool setBoolEje{
		set{
			ejeX=value;	
		}
	}
	


}
