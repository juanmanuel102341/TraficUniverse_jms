using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path:PathInputs  {

	public List<Vector2>listNodes=new List<Vector2>();
	private AngleConstrain angleConstrain;
	private float my_distanceNodes;
	public int countNodes=0;
	public bool first=false;
	private PathGraphic pathGraphic;
	public Path(){

	}
	public Path (float _distanceNodes,PathGraphic _graficPath,float _myConstrain,float _amplitudAngle){
		my_distanceNodes=_distanceNodes;
		//Debug.Log("distance nodes "+my_distanceNodes);
		pathGraphic=_graficPath;
		angleConstrain=new AngleConstrain(this,my_distanceNodes,_myConstrain,_amplitudAngle);


	}

	
	public bool SetNewNode(Vector2 input){
		if(listNodes.Count!=0){
			if(DistanceBetween(input)){
			//mas d uno
		
				input=angleConstrain.InitializeCalcConstrain(input);


				Node node;

				node=new Node(input);
				listNodes.Add(node.posicion);
				countNodes++;
				if(pathGraphic!=null)
					pathGraphic.SpawnGraphicPath(node.posicion);
							
			//	print("click") ;
				return true;
			}else{
				//Debug.Log("nodo n cumple condicion ");
				return false;
			}
		}else{
			
			//igual a 0
			Node node;
			node=new Node(input);
			if(pathGraphic!=null)
			pathGraphic.SpawnGraphicPath(node.posicion);
			//Debug.Log("click") ;
			listNodes.Add(node.posicion);
			countNodes++;
			first=true;
			//angleConstrain.activeConstrain=false;
		//	for(int i=0;i<listNodes.Count;i++)
		//		print("lista "+listNodes[i]);
			return true;
		}
	
	}
	private bool DistanceBetween(Vector2 _input){
		float d=Vector2.Distance(listNodes[listNodes.Count-1],_input);//distancia entre el nodo q hay y el input del mouse
		if(d>my_distanceNodes||d==0){
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
		if(pathGraphic!=null)
		pathGraphic.Delete_ngraphics();
		countNodes=0;
	angleConstrain.setCounting=0;
	}
	public void DeleteMyElementlist(){
		listNodes.Remove(listNodes[0]);
		countNodes--;
	angleConstrain.setCounting--;

		pathGraphic.DeleteFirstElementGraphic();
//		Debug.Log("borrando node "+listNodes.Count);
	}

}
