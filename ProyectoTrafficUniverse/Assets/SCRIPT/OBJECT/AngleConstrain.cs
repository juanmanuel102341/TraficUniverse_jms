
using UnityEngine;

public class AngleConstrain  {
	Path myReferencePath;
	private float myMagnitudPath;
	private float myConstrainAngle;
	private int count=0;
	private bool activeConstrain=false;
	private bool deactiveConstrain=false;

	private Vector2 myCurrentVectorConstrain;
	private float myAngle;
	private Vector2 myVectorPotencial;
	private Vector2 myVectorNode;
	//public delegate bool MyConstrainActive();
	//public event MyConstrainActive ActiveConstrain;
	public AngleConstrain(Path path, float magnitudPath, float constrainAngle){
		myReferencePath=path;
		myMagnitudPath=magnitudPath;
		myConstrainAngle=constrainAngle;
		Debug.Log("constrain "+myConstrainAngle);
	}

	private Vector2 CalcVector(Vector2 n1, Vector2 n2){
		return n2-n1;
	}

	public Vector2 InitializeCalcConstrain(Vector2 nodePotencial){
	//	Debug.Log("my ref "+ myReferencePath.countNodes);
		//Vector2 auxPot=nodePotencial;
		Vector2 myVectorConstrain=nodePotencial;
		if(myReferencePath.countNodes>=2){

			myVectorNode=CalcVector(myReferencePath.listNodes[count],myReferencePath.listNodes[count+1]);
		
			myVectorPotencial=CalcVector(myReferencePath.listNodes[count+1],nodePotencial);

			float angle=Vector2.Angle(myVectorNode,myVectorPotencial);
			//Debug.Log("n1 "+myReferencePath.listNodes[count]);
			//Debug.Log("n2 "+myReferencePath.listNodes[count+1]);
			//Debug.Log("angle "+angle);

		
				
			if(angle>myConstrainAngle){
				Debug.Log("constrain active!!!!!!!!!!!!1!!!!!!!!!!!!!!!!!! "+angle);
				Debug.Log("node "+nodePotencial);
				Vector2 auxZero=CalcVectorZero(myVectorNode,myReferencePath.listNodes[count+1]);

				GameObject obj2=GameObject.CreatePrimitive(PrimitiveType.Sphere);

				obj2.GetComponent<Transform>().position=new Vector3 (auxZero.x,auxZero.y,0);
				obj2.GetComponent<Transform>().localScale=new Vector3(0.2f,0.2f,0.2f);
				obj2.GetComponent<Transform>().GetComponent<MeshRenderer>().material.color=Color.red;

				Vector2 posUp=CalcVector90_sup(myReferencePath.listNodes[count+1],nodePotencial,auxZero);
				//Debug.Log("pos 90 grados sup "+pos);	
				GameObject obj3=GameObject.CreatePrimitive(PrimitiveType.Sphere);
				obj3.GetComponent<Transform>().position=new Vector3 (posUp.x,posUp.y,0);
				obj3.GetComponent<Transform>().localScale=new Vector3(0.2f,0.2f,0.2f);
				obj3.GetComponent<Transform>().GetComponent<MeshRenderer>().material.color=Color.green;
				Vector2 posDown=CalcVector90_inf(myReferencePath.listNodes[count+1],auxZero);
				//Debug.Log("pos 90 grados down "+posDown);
				GameObject obj4=GameObject.CreatePrimitive(PrimitiveType.Sphere);
				obj4.GetComponent<Transform>().position=new Vector3 (posDown.x,posDown.y,0);
				obj4.GetComponent<Transform>().localScale=new Vector3(0.2f,0.2f,0.2f);
				obj4.GetComponent<Transform>().GetComponent<MeshRenderer>().material.color=Color.blue;
			
				float disPosUp=Vector2.Distance(nodePotencial,posUp);
				Debug.Log("dispos up "+disPosUp);
				float disPosDown=Vector2.Distance(nodePotencial,posDown);
				Debug.Log("disp down "+disPosDown);
				if(disPosUp<disPosDown){
					myVectorConstrain=posUp;
				}else{
					myVectorConstrain=posDown;
				}
				count++;
				//activeConstrain=true;
				return myVectorConstrain;			
				}

			count++;
			return myVectorConstrain; 
			Debug.Log("angulo"+angle);
//			if(DetectConstrains(angle)){
//				activeConstrain=true;
//			
//
//				Debug.Log("angulo mayor !!!!!!!!!!!!!!!!!!!!1"+angle);
//				Debug.Log("nodo pot "+auxPot);
//				Debug.Log("pos "+vectorConstrain);
//				count++;
//				return vectorConstrain;
//			}else{
//				//nodePotencial=auxPot;
//				Debug.Log("nodo pot igual"+auxPot);
//				count++;
//				return auxPot;
//			}
//
//			}
//		return auxPot;
	
		}
		return myVectorConstrain;
	}

//	private bool TakeOutConstrain(float _angle){
//		if(_angle<myConstrainAngle){
//			return true;
//		}
//		return false;
//	}
	public int setCounting{
		set{
			count=value;
		}
		get{
			return count;
		}
	}
////	public bool activeConstrain{
////		set{
////			activeConstrain=value;
////		}
////		get{
////			return activeConstrain;
////		}
////	}
//	public Vector2 vectorConstrain{
//		set{
//			myVectorConstrain=value;
//		}
//		get{
//			return myVectorConstrain;
//		}
//	}
//	private Vector2 MyPosConstrain(Vector2 vecZero,float angle){
//		Vector2 aux;
//	//	float difAngle=angle-myConstrainAngle;//saco el angulo de diferencia
//		//float sub=0;
//
//	
////		Vector2 vec=vecZero*Vector2.d;
////	
////		if(posAfter.x>posPot.x){
////			Debug.Log("nodo pot menor )");
////			aux.x=posPot.x;
////			aux.y=posAfter.y;
////		//	direccion=1;//establezco direccion segun la posicion relativa del nodo anterior y potencial
////	//		sub=myMagnitudPath*Mathf.Sin(difAngle);
////	//		aux.y+=sub;
////		}else{
////			
////			//pos after esta adelante del nodo
////			aux.x=posAfter.x;
////			aux.y=posPot.y;
////			Debug.Log("nodo pot mayor ) "+aux.x);
////
////			//igual y que el nodo potencial
////		//	direccion=1;
////	//		sub=myMagnitudPath*Mathf.Cos(difAngle);
////	//		aux.x+=sub;
////		}
//		//saco componeente x a tarves del angulo su seno y el modulo 
////se lo sumoo/resto segun la direccion 
//	
////		return aux;
//	}
	private Vector2 CalcVector90_sup(Vector2 nodeAfter, Vector2 nodePot,Vector2 z){
		Vector2 aux;
		aux.x=z.x;
		aux.y=nodeAfter.y;


		return aux;
	}
	private Vector2 CalcVector90_inf(Vector2 nodeAfter,Vector2 z){
		Vector2 aux;
		aux.y=z.y;
		aux.x=nodeAfter.x;


		return aux;
	}
	private Vector2 CalcVectorZero(Vector2 vecNode,Vector2 _posAfter){
		Vector2 aux;
		aux=_posAfter;
		aux+=vecNode;
		Debug.Log("pos 0 grados "+aux);
		return aux;
	}

}
