
using UnityEngine;

public class AngleConstrain  {
	Path myReferencePath;
	private float myMagnitudPath;
	private float myConstrainAngle;
	private int count=0;
	private bool activeConstrain=false;
	private bool deactiveConstrain=false;
	private Vector2 myVectorConstrain;
	private Vector2 myCurrentVectorConstrain;
	private float myAngle;
	private Vector2 myVectorPotencial;
	private Vector2 myVectorNode;
	public AngleConstrain(Path path, float magnitudPath, float constrainAngle){
		myReferencePath=path;
		myMagnitudPath=magnitudPath;
		myConstrainAngle=constrainAngle;
		Debug.Log("constrain "+myConstrainAngle);
	}
//	public float GettinAngleConstrain(Vector2 nodePot){
////		Debug.Log("nodo 1 "+myReferencePath.listNodes[count]);
////		Debug.Log("nodo 2 "+myReferencePath.listNodes[count+1]);
//		//Debug.Log("nodo pot "+myReferencePath.listNodes[count+2]);
//		Vector2 vecNode1=myReferencePath.listNodes[count];
//		Vector2 vecNode2=myReferencePath.listNodes[count+1];
//		//Vector2 vecNodePot=myReferencePath.listNodes[count+2];
//
//		Vector2 vectorNode;
//		float angle;
//		myVectorNode=vecNode2-vecNode1;
//		myVectorPotencial=nodePot-vecNode2;
//		angle=Vector2.Angle(vectorNode,myVectorPotencial);
////		Debug.Log("vector node"+vectorNode );
////		Debug.Log("vector pot"+myVectorPotencial);
////		Debug.Log("final angle "+angle); 
//
//		return angle;
//	}
	private Vector2 CalcVector(Vector2 n1, Vector2 n2){
		return n2-n1;
	}
//	private float CalcAngle(){
//		return 
//	}
//	public Vector2 InitializeCalcConstrain(Vector2 nodePotencial){
//	//	Debug.Log("my ref "+ myReferencePath.countNodes);
//		Vector2 auxPot=nodePotencial;
//		if(myReferencePath.countNodes>=2){
//
//			myVectorNode=CalcVector(myReferencePath.listNodes[count],myReferencePath.listNodes[count+1]);
//
//			myVectorPotencial=CalcVector(myReferencePath.listNodes[count+1],auxPot);
//
//			float angle=Vector2.Angle(myVectorNode,myVectorPotencial);
//
//			if(angle>myConstrainAngle){
//				activeConstrain=true;
//				myCurrentVectorConstrain=MyPosConstrain(auxPot,myReferencePath.listNodes[count+1],angle);
//			}
//
//			Debug.Log("angulo"+angle);
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
//	}
//
//	private bool TakeOutConstrain(float _angle){
//		if(_angle<myConstrainAngle){
//			return true;
//		}
//		return false;
//	}
//	public int setCounting{
//		set{
//			count=value;
//		}
//		get{
//			return count;
//		}
//	}
//	public bool activeConstrain{
//		set{
//			activeConstrain=value;
//		}
//		get{
//			return activeConstrain;
//		}
//	}
//	public Vector2 vectorConstrain{
//		set{
//			myVectorConstrain=value;
//		}
//		get{
//			return myVectorConstrain;
//		}
//	}
//	private Vector2 MyPosConstrain(Vector2 posPot, Vector2 posAfter,float angle){
//		Vector2 aux;
//		float difAngle=angle-myConstrainAngle;//saco el angulo
//		int direccion=1;
//		aux.y=posPot.y;//igual y que el nodo potencial
//		aux.x=posAfter.x;//igual x q elnodo precedente
//		if(posAfter.y<posPot.y){
//			direccion=-1;//establezco direccion segun la posicion relativa del nodo anterior y potencial
//		}else{
//			direccion=1;
//		}
//		float subx=myMagnitudPath*Mathf.Sin(difAngle);//saco componeente x a tarves del angulo su seno y el modulo 
//		aux.x+=subx*direccion;//se lo sumoo/resto segun la direccion 
//		return aux;
//	}

}
