
using UnityEngine;

public class Direction : MonoBehaviour {

	private Path path;
	private Bounds bounds;
	private int index=0;
	private bool changeVector=false;
	private Vector2 currentPath;
	private Vector2 posObj;
	void Awake () {
		path=GetComponent<Path>();
		bounds=GetComponent<Bounds>();
	}
	

	void Update () {
		
		//State();
	}
	private void Apply(){
		//aplica el vector up buscado

		//print("transform up direction "+transform.up);
	}
	private void Initial(){

	}
	private void State(){
//
//		posObj.x=transform.position.x;
//		posObj.y=transform.position.y;
//
//	//	print("cant vectores "+path.getPathVectors.Count);
//		if(index<path.getPathVectors.Count-1&&path.getPathVectors.Count>0){
//		//	if(index<path.getPathVectors.Count)
//			//si hay vectores entras
//			print("entrando con path");
//			if (DistanceBetween(currentPath)||index==0){
//				//otro path
//				print("change path!!!!!!!!!!!!!!!!!");
//			
//				Data();
//				}
//
//
//		}else{
//			transform.up=path.getLastVector;
//			print("entrando sin path "+path.getLastVector);
//		}
//
//	
//		if(path.getMouseDown){
//			//index=0;
//		}
	}
	private void Data(){
		
//			print("dataa");
		Vector2 aux;
		posObj.x=transform.position.x;
		posObj.y=transform.position.y;
		currentPath=path.getPathVectors[index];	
//		print("current path "+currentPath);
		aux=ResVector(currentPath);
//		print("res vec "+aux);
		transform.up=aux;
	

	}

	private Vector2 ResVector(Vector2 _path){
		Vector2 aux;
	
//		print("vec path "+_path);
		aux= _path-posObj;
//		print("final vector "+aux);
		return aux;
	}
	private bool DistanceBetween(Vector2 currentPath){
		float d=Vector2.Distance(currentPath,posObj);
	//	print("pos obj "+posObj);
	//	print("current path "+currentPath);
	//	print("distance "+d);
		if(d<=0.01f){
		//es importante q se menor 0.01 y n 0 porque nunca llega a este ultimo y el codigo n funciona	
		
			index++;
			print("cambio index");

			return true;

		}
		return false;
	}


//	private Vector2 CurrentPath(){
//	//	Vector2 auxPath;
//	
//		if(index!=0){
//			
//				if(index<path.getPathVectors.Count){
//					
//				index++;
//					print("CAMBIO DE PATH +"+index);
//				}else{
//					print("paths ultimo limite");
//			
//
//			return ResVector(path.getPathVectors[index]);
//			}
//			//todavia n llega al final
//			return ResVector(path.getPathVectors[index]);
//
//
//		}else{
//			
//			return ResVector(path.getPathVectors[index]);
//		}
//	}

	public int setIndexDirection{
		set{
			index=value;
		}
	}
}

