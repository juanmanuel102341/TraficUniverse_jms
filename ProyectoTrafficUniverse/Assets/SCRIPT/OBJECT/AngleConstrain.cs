
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

	public Vector2 InitializeCalcConstrain(Vector2 nodePotencial){
	//	Debug.Log("my ref "+ myReferencePath.countNodes);
		//Vector2 auxPot=nodePotencial;
		Vector2 myVectorConstrain=nodePotencial;
		if(myReferencePath.countNodes>=2){
			Vector2 auxResUp;
			Vector2 auxResDown;
			Vector2 auxVecSegundo;
			Vector2 auxVecPrim;

			myVectorNode=CalcVector(myReferencePath.listNodes[count],myReferencePath.listNodes[count+1]);
			myVectorPotencial=CalcVector(myReferencePath.listNodes[count+1],nodePotencial);

			auxVecSegundo=myVectorPotencial+myReferencePath.listNodes[count+1];
			//	Debug.Log("vec segundo "+auxVecSegundo);
			auxVecPrim=myVectorNode+myReferencePath.listNodes[count];
			//	Debug.Log("vec prim "+auxVecPrim);

			float ang=Vector2.Angle(myVectorPotencial,myVectorNode);
			Debug.Log("node anterior "+myReferencePath.listNodes[count+1]);
			Debug.Log("node pot "+nodePotencial);
			Debug.Log("angulo"+ang);
			float modP=Vector2.Distance(myReferencePath.listNodes[count+1],nodePotencial);
			//	Debug.Log("modulo "+modP);

			auxResUp=myReferencePath.listNodes[count+1];
			auxResDown=myReferencePath.listNodes[count+1];
			if(auxVecSegundo.x<auxVecPrim.x){
				//	dir=-1;
				auxResUp.x-=modP*Mathf.Cos(myAmplitudeAngle*Mathf.Deg2Rad);
				auxResDown.x-=modP*Mathf.Cos(-myAmplitudeAngle*Mathf.Deg2Rad);
			}else{
				//	dir=1;
				auxResUp.x+=modP*Mathf.Cos(myAmplitudeAngle*Mathf.Deg2Rad);
				auxResDown.x+=modP*Mathf.Cos(-myAmplitudeAngle*Mathf.Deg2Rad);
			}
			if(auxVecSegundo.y<auxVecPrim.y){
				auxResUp.y-=modP*Mathf.Sin(myAmplitudeAngle*Mathf.Deg2Rad);
				auxResDown.y-=modP*Mathf.Sin(-myAmplitudeAngle*Mathf.Deg2Rad);

			}else{
				auxResUp.y+=modP*Mathf.Sin(myAmplitudeAngle*Mathf.Deg2Rad);
				auxResDown.y+=modP*Mathf.Sin(-myAmplitudeAngle*Mathf.Deg2Rad);
			}
			Debug.Log("aux up "+auxResUp);
			Debug.Log("aux dwon "+auxResDown);

//			GameObject obj2=GameObject.CreatePrimitive(PrimitiveType.Sphere);
//			obj2.GetComponent<Transform>().position=new Vector3 (auxResUp.x,auxResUp.y,0);
//			obj2.GetComponent<Transform>().localScale=new Vector3(0.2f,0.2f,0.2f);
//			obj2.GetComponent<Transform>().GetComponent<MeshRenderer>().material.color=Color.cyan;
//
//			GameObject obj3=GameObject.CreatePrimitive(PrimitiveType.Sphere);
//			obj3.GetComponent<Transform>().position=new Vector3 (auxResDown.x,auxResDown.y,0);
//			obj3.GetComponent<Transform>().localScale=new Vector3(0.2f,0.2f,0.2f);
//			obj3.GetComponent<Transform>().GetComponent<MeshRenderer>().material.color=Color.cyan;

			if(ang>myConstrainAngle){
				Debug.Log("constrain mayor !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"+ang);
			


				float disPosUp=Vector2.Distance(nodePotencial,auxResUp);
			//	Debug.Log("dispos up "+disPosUp);
				float disPosDown=Vector2.Distance(nodePotencial,auxResDown);
			//	Debug.Log("disp down "+disPosDown);
				if(disPosUp<disPosDown){
					Debug.Log("constrain up active "+auxResUp);
					myVectorConstrain=auxResUp;

				}else{
					Debug.Log("constrain down active "+auxResDown);
					myVectorConstrain=auxResDown;
			
				}
				count++;
				//activeConstrain=true;
				return myVectorConstrain;			
				}

			count++;
			return myVectorConstrain; 

		}
		return myVectorConstrain;
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
