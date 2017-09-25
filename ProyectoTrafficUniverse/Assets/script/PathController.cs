using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour {
	//genera un path

	private List<Vector2> listPaths=new List<Vector2>();
	private List<GameObject>listSpritePoint=new List<GameObject>();
	private MovePath move;
	public GameObject obj;

	public float anchoScreenMundo;
	public float altoScreenMundo;
	public float lix;
	public float liy;
	public float distanceNode;//distancia entre los nodos del path

	private Vector2 vecBase;//vector tomado como base d calculo para cuando no haya paths

	private bool clickActiveObject=false;//booleano q recibe click del usuario
	private bool activePath=false;//booleano q activa el path, diferente al active object
	//private Vector2[] vectorBase=new Vector2[2];
	//private Rigidbody2D rb;
	private SpriteRenderer spr;
	private int contadorClicks=0;
	private int contadorClicks2=0;
	private Color colorInitial;




	void Awake () {

		move=GetComponent<MovePath>();
		lix=Mathf.Abs(lix);//pto minimo en x data del mundo
		liy=Mathf.Abs(liy);//pto minimo en y data del mundo
		anchoScreenMundo+=lix;//llevo a 0 x , para poder comparar correctamente con el sistema d coordenadas d la screen
		altoScreenMundo+=liy;//levo a 0 el eje y 
		spr=GetComponent<SpriteRenderer>();
		colorInitial=spr.color;
	
	}
		
	void OnMouseDown(){
		

		DeleteNodos_sprites();

		if(!clickActiveObject){
		print("click active object");
		clickActiveObject=true;
		spr.color=Color.green;
		}
		if(contadorClicks>=1){
			activePath=true;
		}else{
			print("objeto activo");
			//CalcEndPathVector();
		}
		contadorClicks+=1;
//		if(!PathTouchingBounds2(GetInputMouse())&&clickActiveObject){
		print("click objeto "+contadorClicks);

	}
	void OnMouseUp(){
		if(activePath){
		ResetCicle();
		}
	}
	void Update () {
//		print(" objeto activo "+clickActiveObject);
		//print(" path activo "+activePath);
		//ClickFueraDelObjeto();
//		print("click screen"+Input.mousePosition);
		//print("mundo  "+Input.mousePosition.x*anchoScreenMundo/Screen.width );
		if(clickActiveObject&&activePath){
			
			//	DeleteNodos_sprites();
		DibujoPath();
		//EventoMouseUp();
		}
	//print("click x"+Input.mousePosition);
//		print("lista paths "+listPaths.Count);
	}
	private void DibujoPath(){
		
			//			print("click usuario");

			Vector2 posw=GetInputMouse();
			//PathTouchingBounds(posw);//verifico si toca al objeto el click
			if(!PathTouchingObject(posw)){
				print("click fuera objeto");

				//				print("cantidad d puntos "+listSpritePoint.Count);
				//print("cantidad d paths "+listPaths.Count);
				//************** click del mouse n toca al path****************
				if(listPaths.Count==0){
					//si n hay ninungun punto
					listPaths.Add(posw);
					GameObject objAux=Instantiate(obj,posw,transform.rotation);
					listSpritePoint.Add(objAux);
					//print("entrando 1er nodo "+posw);
				
				}else{
					//si hay mas d uno, y si la distancia es menor a distanceNode
					if(CalcDistancePoint(listPaths[listPaths.Count-1],posw)>distanceNode){
						listPaths.Add(posw);
						GameObject objAux=Instantiate(obj,posw,transform.rotation);
						listSpritePoint.Add(objAux);//guardo el sprite del punto

						//print("nodo adentro "+posw);
					}else{
						//print("nodo demasiado cerca");
					}

				}
			}else{
				//click del mouse toca al spfrite, importante sino me tira error, no puede ir a su mismo lugar
				print("warning path encima del sprite");

			}
		}



	private void EventoMouseUp(){
		if(Input.GetMouseButtonUp(0)){
			//	print("click mouse fuera ");

			if(listPaths.Count>=2){
				print("entrando path last 2");
				vecBase=CalcLastVector();
			}
			ResetCicle();
		}

	}

	private void ClickFueraDelObjeto(){
		if(clickActiveObject){
			if(Input.GetMouseButtonDown(0)){
				//	print("click mismo objeto");
				contadorClicks2+=1;//contador para chequear y ver"si se hizo click en el objeto q estas moviendo
			}
			if(contadorClicks!=contadorClicks2){
				//si hizo click en otro objeto, resetiate
				//	print("click otro objeto");
				//reseteo valores
			//	ResetCicle();
				//mouseDown=false;
			}else{

			}
		}
	}
	private bool PathTouchingObject(Vector2 _inputMouse){
		//bounds.max.x =maxima extension en x del borde del sprite
		//bounds.min.y=seria el alto del objeto (no el 0,0 por favor!!)
		//extents es la mitad tanto d x como d y

		//para q al hacer click el path no aparezca dentro del objeto al q se queire aplicar el path

		if(_inputMouse.y<spr.bounds.max.y&&_inputMouse.y>spr.bounds.min.y&&_inputMouse.x>spr.bounds.center.x-spr.bounds.extents.x&&_inputMouse.x<spr.bounds.max.x){
			//print("tocando 22222");
			return true;
		}
		return false;
	}
	private float CalcDistancePoint(Vector2 v1, Vector2 v2){
		return Vector2.Distance(v1,v2);
	}
	private void DeleteNodos_sprites(){
		//	print("click mouse");
			//			move.setBoolIdle=false;
			if(listSpritePoint.Count>0){
				//	print("borrando paths y nodos");
				DeletePointSprites();
				listPaths.Clear();

			}
		move.setIndex_m=0;
	}

	private void ResetCicle(){

//		transform.up=vecBase;
//		print("last vector "+vecBase);
		contadorClicks=0;//reseteo contador para q el usuario tenga q volver hacer click en el objeto si quiere moverlo 
		contadorClicks2=0;
		clickActiveObject=false;//resete boolean d objeto
		activePath=false;//reseteo boleano del path 
		spr.color=colorInitial;
	}

	private Vector2 GetInputMouse(){
	Vector2 posw;
	posw.x=TransformScreenToWorldX(Input.mousePosition.x)-lix;
	posw.y=TransformScreenToWorldY(Input.mousePosition.y)-liy;
	return posw;
	
	}
					
	private void DeletePointSprites(){
		//destruyo paths y la parte del sprite del mismo al hacer click nuevamente
		for(int i =0;i<listSpritePoint.Count;i++){
			Destroy(listSpritePoint[i]);
		}
		listSpritePoint.Clear();
	}


	float TransformScreenToWorldX(float inputSx){
		float n=(inputSx*anchoScreenMundo);
			n=n/Screen.width;
//		print("x mundo "+n);
		return n;
	}
	float TransformScreenToWorldY(float inputSy){
		float n=(inputSy*altoScreenMundo)/Screen.height;
	//	print("y mundo "+n);
		return n;
	}

	public List<Vector2> getPathVectors{
		get{
			return listPaths;
		}
		set{
			listPaths=value;
		}
	}
	public List<GameObject> getListSprite{
		get{
			return listSpritePoint;
		}
		set{
			listSpritePoint=value;
		}
	}


	public Vector2 getLastVector{
		get{
			return vecBase; 
		}
	}
		
	public void RemovePaths(){
		for(int i=0;i<listSpritePoint.Count;i++){
			//Vector2 auxPaths=listPaths[i];//accedo a los elementos de la lista d transforms
			GameObject auxObj=listSpritePoint[i];//accedo a los elementos de la lista d objetos visuales(mismo tamano)

			Destroy(auxObj);

		}
//		print("listPaths "+listPaths.Count);
//		print(" listSpritePoint "+listSpritePoint.Count);
		listPaths.RemoveRange(0,listPaths.Count);
		listSpritePoint.RemoveRange(0,listSpritePoint.Count);
//		print("listPaths des"+listPaths.Count);
//		print(" listSpritePoint des"+listSpritePoint.Count);
	}



	private Vector2 CalcLastVector(){
		Vector2 lastPath=listPaths[listPaths.Count-1];
		Vector2 last2=listPaths[listPaths.Count-2];
		Vector2 aux;
		aux=lastPath-last2;
		//aux.x=Mathf.Abs(aux.x);
		//aux.y=Mathf.Abs(aux.y);
		print("last vector "+aux);
		return aux;
	}

}
