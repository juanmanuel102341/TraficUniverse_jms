using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
	//genera un path

	private List<Vector2> listPaths=new List<Vector2>();
	private List<GameObject>listSpritePoint=new List<GameObject>();
	private Move move;
	public GameObject obj;
	private Transform tf;


	public float anchoScreenMundo;
	public float altoScreenMundo;
	public float lix;
	public float liy;
	public float distanceNode;//distancia entre los nodos del path

	private Vector2 vecBase;//vector tomado como base d calculo para cuando no haya paths


	//private Vector2[] vectorBase=new Vector2[2];

	Transform n;
	void Awake () {
		tf=GetComponent<Transform>();
		move=GetComponent<Move>();
		lix=Mathf.Abs(lix);//pto minimo en x data del mundo
		liy=Mathf.Abs(liy);//pto minimo en y data del mundo
		anchoScreenMundo+=lix;//llevo a 0 x , para poder comparar correctamente con el sistema d coordenadas d la screen
		altoScreenMundo+=liy;//levo a 0 el eje y 
		//n=GetComponent<Transform>();
	}
		

	void Update () {

//		print("click screen"+Input.mousePosition);
		//print("mundo  "+Input.mousePosition.x*anchoScreenMundo/Screen.width );
		if(Input.GetMouseButtonDown(0)){
			print("click mouse");
			if(listSpritePoint.Count>0){
				print("borrando paths y nodos");
				DeletePointSprites();
				listPaths.Clear();
				move.SetIndex=0;//seteo indice de la lista previa para q "recorra"la nueva path
			}
		}
		if(Input.GetMouseButtonUp(0)){
			print("click mouse fuera ");
			vecBase=CalcVector();

		}

		if(Input.GetMouseButton(0)){
			//click usuario


			Vector2 posw;
			posw.x=TransformScreenToWorldX(Input.mousePosition.x)-lix;
			posw.y=TransformScreenToWorldY(Input.mousePosition.y)-liy;
			print("cantidad d puntos "+listSpritePoint.Count);
			print("cantidad d paths "+listPaths.Count);
			if(listPaths.Count==0){
				//si n hay ninungun punto
				listPaths.Add(posw);
				GameObject objAux=Instantiate(obj,posw,transform.rotation);
				listSpritePoint.Add(objAux);
				print("entrando 1er nodo "+posw);
			
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
		
		}
	
		//print("click x"+Input.mousePosition);
	}

	private float CalcDistancePoint(Vector2 v1, Vector2 v2){
		return Vector2.Distance(v1,v2);
	}
	private void Dibujo(){
		for(int i=0;i<listPaths.Count;i++){
			//print("click transformado "+listPaths[i].x);
			Instantiate(obj,(listPaths[i]),transform.rotation);
			//print(i +")x "+listPaths[i].x);
		}

	}
	private void DeletePointSprites(){
		for(int i =0;i<listSpritePoint.Count;i++){
			Destroy(listSpritePoint[i]);
		}
		listSpritePoint.Clear();
	}

	void OnMouseDown()
	{
			
		//Instantiate(obj,transform.position,transform.rotation)

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

	public List<Vector2> getPath{
		get{
			return listPaths;
		}
	}
	private Vector2[] CalcLastPaths(){
		//calculo los ultimos 2 elementos del path para tener la data correspondiente cuando el objeto no tenga mas paths
		Vector2 [] aux=new Vector2[2];
		if(listPaths.Count>2){
			aux[0].x=listPaths[listPaths.Count-2].x;//copio el ante_ultimo elemento x del path 
			aux[0].y=listPaths[listPaths.Count-2].y;//copio el ante_ultimo elemento y del path

			aux[1].x=listPaths[listPaths.Count-1].x;//copio el ultimo elemento x del path
			aux[1].y=listPaths[listPaths.Count-1].y;//copio el ultimo elemento y del path

		}else{
			print("warning path muy chico!!!!!!!!!!!!111");

		}
	
		return aux;
	}
	private int CalcDireccionY(float y1, float y2 ){
		if(y2<y1){
			print("y abajo");
			return -1;
		}else{
			return 1;
		}
	}
	private int CalcDireccionX(float x1, float x2 ){
		if(x2<x1){
			print("y abajo");
			return -1;
		}else{
			return 1;
		}
	}
	private Vector2 CalcVector(){
		
		Vector2 [] aux=CalcLastPaths();//obtengo los ultimos 2 paths
		Vector2 vec;
		float n;

		float distancia=Vector2.Distance(aux[0],aux[1]);//calculo distanvcia en teoria tendria q ser constante 

		n=aux[1].x-aux[0].x;//diferencia entre el ultimo y anteultimo en x
		n=Mathf.Abs(n);
		n=n/distancia;
		vec.x=n*CalcDireccionX(aux[0].x,aux[1].x);//multiplico proporcion x por la direccion x

		n=0;//reseteo n
		n=aux[1].y-aux[0].y;//diferencia entre el ultimo y anteultimo en y
		n=Mathf.Abs(n);
		n=n/distancia;
		vec.y=n*CalcDireccionY(aux[0].y,aux[1].y);
		print("vector "+vec);
		return vec;
	}

	public Vector2 getLastVector{
		get{
			return vecBase; 
		}
	}


}
