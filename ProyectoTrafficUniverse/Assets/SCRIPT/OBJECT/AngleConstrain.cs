
using UnityEngine;

public class AngleConstrain  {
	MyPath myReferencePath;

	private float myConstrainAngle;

	private float myAngle;
	private Vector2 myVectorPotencial;
	private Vector2 myVectorNode;
	public AngleConstrain(MyPath path, float constrainAngle){
		myReferencePath=path;

		myConstrainAngle=constrainAngle;

		//Debug.Log("constrain "+myConstrainAngle);
	}

	private Vector2 CalcVector(Vector2 n1, Vector2 n2){
		return n2-n1;
	}

	public bool InitializeCalcConstrain(Vector2 nodePotencial){
	//	Debug.Log("my ref "+ myReferencePath.countNodes);
		//Vector2 auxPot=nodePotencial;
		Vector2 myVectorConstrain=nodePotencial;
		if(myReferencePath.getListVectors.Count>=2){
			myVectorNode=CalcVector(myReferencePath.getListVectors[myReferencePath.getListVectors.Count-2],myReferencePath.getListVectors[myReferencePath.getListVectors.Count-1]);
			myVectorPotencial=CalcVector(myReferencePath.getListVectors[myReferencePath.getListVectors.Count-1],nodePotencial);

			float ang=Vector2.Angle(myVectorPotencial,myVectorNode);
			//Debug.Log("angulo "+ang);
			if(ang>myConstrainAngle){
				return true;		
			}else{
				
				return false;
			}


		}

		return false;
	}






}
