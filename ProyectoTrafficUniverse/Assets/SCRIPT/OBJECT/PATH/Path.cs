using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path:PathInputs  {

	public List<Vector2>listNodes=new List<Vector2>();
	//public MoveShip moveShip;
	private float distanceNodes;
	public AngleConstrain angleConstrain;
	private int count;
	private int acum;
	private Vector2 pointFrontierUp;
	private Vector2 pointFrontierDown;
	public int countNodes=0;
	public bool first=false;
	public Path(){

	}
	public Path (float _distanceNodes){
		distanceNodes=_distanceNodes;
	//	moveShip=new MoveShip();
		angleConstrain=new AngleConstrain();
	
		count=0;
		acum=3;
	}
	public void Update(){
	//	moveShip.Update();
	
	}
	
	public bool SetNewNode(Vector2 input){
		if(listNodes.Count!=0){
			if(DistanceBetween(input)){
			//mas d uno
				countNodes++;
				Node node;
			
			node=new Node(input);
					
	//		moveShip.myListNodes.Add(node.posicion);		
			listNodes.Add(node.posicion);
			
			//	Debug.Log("entrando cantidad nodes "+listNodes.Count);
				if(listNodes.Count>=acum){
					
			//		Debug.Log("contador "+count);
					float n=angleConstrain.GettinAngleConstrain(listNodes[count],listNodes[count+1],listNodes[count+2]);						
					Vector2 aux=angleConstrain.GettinVectorConstrain(distanceNodes,45);
					aux+=listNodes[count+1];
			//		Debug.Log("point constrain 1"+aux);
					Vector2 aux2 =angleConstrain.GettinVectorConstrain(-distanceNodes,45);
					aux2+=listNodes[count+1];
			//		Debug.Log("point constrain 2"+aux2);
//					GameObject obj=GameObject.CreatePrimitive(PrimitiveType.Sphere);
//					Transform objTransform=obj.GetComponent<Transform>();
//					objTransform.position=aux;
//					objTransform.localScale=new Vector3(0.2f,0.2f,0.2f);
//					obj.GetComponent<MeshRenderer>().material.color=Color.green;
//					GameObject obj2=GameObject.CreatePrimitive(PrimitiveType.Sphere);
//					Transform tf=obj2.GetComponent<Transform>();
//					tf.position=aux2;
//					tf.localScale=new Vector3(0.2f,0.2f,0.2f);
//					obj2.GetComponent<MeshRenderer>().material.color=Color.red;
//				

					if(n>45){
//						GameObject obj3=GameObject.CreatePrimitive(PrimitiveType.Sphere);
//						Transform objTransform3=obj3.GetComponent<Transform>();
//						objTransform3.position=listNodes[count+2];
//						objTransform3.localScale=new Vector3(0.2f,0.2f,0.2f);
//						obj3.GetComponent<MeshRenderer>().material.color=Color.white;
						//	listNodes[count+2]=	
			//			Debug.Log("constrain activa!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11 "+n);
//						if(listNodes[count+2].y<aux2.y){
//							Debug.Log("pos a guardar "+aux2);
//							listNodes[count+2]=aux2;
//						}else{
//			//				Debug.Log("pos a guardar "+aux);
//							listNodes[count+2]=aux;
//						}	
					}

					count++;	
					acum++;


				}
				Debug.Log("click") ;
				//	moveShip.Update();
				//Debug.Log("creacion nodo "+node.posicion);
				return true;
			}else{
				//Debug.Log("nodo n cumple condicion ");
				return false;
			}
		}else{
			
			//igual a 0
			Node node;
			node=new Node(input);
			Debug.Log("click") ;
			listNodes.Add(node.posicion);
			countNodes++;
			first=true;
			//moveShip.myListNodes.Add(node.posicion);
		//	Debug.Log("cant nodes "+	moveShip.myListNodes.Count);
		//	moveShip.myVector=moveShip.CalcVectorUp();

		//	Debug.Log("first vector path"+moveShip.myVector);
			//moveShip.Update();
			//Debug.Log("promer node "+node.posicion);
			return true;
		}
	
	}


	private bool DistanceBetween(Vector2 _input){
		float d=Vector2.Distance(listNodes[listNodes.Count-1],_input);//distancia entre el nodo q hay y el input del mouse
		if(d>distanceNodes||d==0){
			//la igualo a 0 asi n se complica el codigo en how to play, ya q la cantidad d nodos lo establezco con otra condicion no por distancia entre elloss
			return true;
		}
		return false;
	}

	public void Delete(){
//		Debug.Log("borrando path");
		if(listNodes.Count>0){
		//	Debug.Log("borrando nodos "+listNodes.Count);
			listNodes.RemoveRange(0,listNodes.Count);
	
		}
//		MethodPapa();
	//	moveShip.DeleteMyList();
//		Debug.Log("nodos codigo "+listNodes.Count);
		acum=3;
		count=0;
		countNodes=0;

	}
	public void DeleteMyElementlist(){
		listNodes.Remove(listNodes[0]);
		countNodes--;
//		Debug.Log("borrando node "+listNodes.Count);
	}

}
