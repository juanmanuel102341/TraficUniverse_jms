
using UnityEngine;

public class AngleConstrain  {
	Path myReferencePath;
	private float myMagnitudPath;
	private float myConstrainAngle;
	private int count=0;
	private bool activeConstrain=false;
	private bool deactiveConstrain=false;

	private Vector2 myCurrentVectorConstrain;
	private float myAmplitudeAngle;
	private float myAngle;
	private Vector2 myVectorPotencial;
	private Vector2 myVectorNode;
	//public delegate bool MyConstrainActive();
	//public event MyConstrainActive ActiveConstrain;
	public AngleConstrain(Path path, float magnitudPath, float constrainAngle,float _myAmplitudAngle){
		myReferencePath=path;
		myMagnitudPath=magnitudPath;
		myConstrainAngle=constrainAngle;
		myAmplitudeAngle=_myAmplitudAngle;
		Debug.Log("constrain "+myConstrainAngle);
	}

	private Vector2 CalcVector(Vector2 n1, Vector2 n2){
		return n2-n1;
	}

	public bool InitializeCalcConstrain(Vector2 nodePotencial){
	//	Debug.Log("my ref "+ myReferencePath.countNodes);
		//Vector2 auxPot=nodePotencial;
		Vector2 myVectorConstrain=nodePotencial;
		if(myReferencePath.countNodes>=2){
			myVectorNode=CalcVector(myReferencePath.listNodes[count],myReferencePath.listNodes[count+1]);
			myVectorPotencial=CalcVector(myReferencePath.listNodes[count+1],nodePotencial);

			float ang=Vector2.Angle(myVectorPotencial,myVectorNode);
			if(ang>myConstrainAngle){
				return true;		
			}else{
				count++;
				return false;
			}


		}

		return false;
	}

	public int setCounting{
		set{
			count=value;
		}
		get{
			return count;
		}
	}




}
