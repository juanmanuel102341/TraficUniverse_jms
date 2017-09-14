using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
	//genera un path

	private List<Vector2> listPaths=new List<Vector2>();
	private List<GameObject>listSpritePoint=new List<GameObject>();
	private Move move;
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
	private bool mouseUp=false;
	private bool mouseDown=false;
	void Awake () {

		move=GetComponent<Move>();
		lix=Mathf.Abs(lix);//pto minimo en x data del mundo
		liy=Mathf.Abs(liy);//pto minimo en y data del mundo
		anchoScreenMundo+=lix;//llevo a 0 x , para poder comparar correctamente con el sistema d coordenadas d la screen
		altoScreenMundo+=liy;//levo a 0 el eje y 
		//n=GetComponent<Transform>();
		vecBase.x=0.0f;
		vecBase.y=1.0f;
	//	rb=GetComponent<Rigidbody2D>();
		spr=GetComponent<SpriteRenderer>();
		colorInitial=spr.color;
		mouseUp=false;
		mouseDown=false;
		//activePath=true;
		//clickActiveObject=true;
	}
		
	void OnMouseDown(){
		
		print("click objeto "+contadorClicks);
		DeleteNodos_sprites();
		if(!clickActiveObject){
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

	}
	void Update () {
		if(clickActiveObject){
			if(Input.GetMouseButtonDown(0)){
				print("click mismo objeto");
				contadorClicks2+=1;//contador para chequear y ver"si se hizo click en el objeto q estas moviendo
			}
			if(contadorClicks!=contadorClicks2){
				//si hizo click en otro objeto, resetiate
				print("click otro objeto");
				//reseteo valores
				ResetCicle();
				mouseDown=false;
			}else{
				
			}
		}
//		print("click screen"+Input.mousePosition);
		//print("mundo  "+Input.mousePosition.x*anchoScreenMundo/Screen.width );
		if(clickActiveObject&&activePath){
	//	DeleteNodos_sprites();
		DibujoPath();
		EventoMouseUp();
		}
	//print("click x"+Input.mousePosition);
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
				move.SetIndex=0;//seteo indice de la lista previa para q "recorra"la nueva path
			}
	}
	private void EventoMouseUp(){
		if(Input.GetMouseButtonUp(0)){
			//	print("click mouse fuera ");
			ResetCicle();
		}
		mouseUp=true;
	}
	private void ResetCicle(){

		transform.up=vecBase;
		print("last vector "+vecBase);
		contadorClicks=0;//reseteo contador para q el usuario tenga q volver hacer click en el objeto si quiere moverlo 
		contadorClicks2=0;
		clickActiveObject=false;//resete boolean d objeto
		activePath=false;//reseteo boleano del path 
		spr.color=colorInitial;
	}
	private void DibujoPath(){
		if(Input.GetMouseButton(0)){
			print("click usuario");
				
					Vector2 posw=GetInputMouse();
		
				//PathTouchingBounds(posw);//verifico si toca al objeto el click
				if(!PathTouchingObject(posw)){

				if(mouseDown==false){
					mouseDown=true;
				}
				//print("cantidad d puntos "+listSpritePoint.Count);
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

	private int CalcDireccionY(float y1, float y2 ){
		if(y2<y1){
		//	print("y abajo");
			return -1;
		}else{
			return 1;
		}
	}
	private int CalcDireccionX(float x1, float x2 ){
		if(x2<x1){
			//print("y abajo");
			return -1;
		}else{
			return 1;
		}
	}

	public Vector2 getLastVector{
		get{
			return vecBase; 
		}
	}
		private bool PathTouchingObject(Vector2 _inputMouse){
		//bounds.max.x =maxima extension en x del borde del sprite
		//bounds.min.y=seria el alto del objeto (no el 0,0 por favor!!)
		//extents es la mitad tanto d x como d y

		//para q al hacer click el path no aparezca dentro del objeto al q se queire aplicar el path

		if(_inputMouse.y<spr.bounds.max.y&&_inputMouse.y>spr.bounds.min.y&&_inputMouse.x>spr.bounds.center.x-spr.bounds.extents.x&&_inputMouse.x<spr.bounds.max.x){
			print("tocando 22222");
			return true;
		}
		return false;
	}
	public void RemovePaths(){
		for(int i=0;i<listSpritePoint.Count;i++){
			//Vector2 auxPaths=listPaths[i];//accedo a los elementos de la lista d transforms
			GameObject auxObj=listSpritePoint[i];//accedo a los elementos de la lista d objetos visuales(mismo tamano)

			Destroy(auxObj);

		}
		print("listPaths "+listPaths.Count);
		print(" listSpritePoint "+listSpritePoint.Count);
		listPaths.RemoveRange(0,listPaths.Count);
		listSpritePoint.RemoveRange(0,listSpritePoint.Count);
		print("listPaths des"+listPaths.Count);
		print(" listSpritePoint des"+listSpritePoint.Count);
	}
	public bool getMouseUp{
		get{
			return mouseUp;
		}
		set{
			mouseUp=value;
		}

	}
	public bool getMouseDown{
		get{
			return mouseDown;
		}
		set{
			mouseDown=value;
		}

	}


}
