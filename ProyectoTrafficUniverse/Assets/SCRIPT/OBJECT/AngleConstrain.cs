
using UnityEngine;

public class AngleConstrain  {
	public AngleConstrain(){
		
	}
	public float GettinAngleConstrain(Vector2 n1,Vector2 n2,Vector2 np){
		Debug.Log("nodo 1 "+n1);
		Debug.Log("nodo 2 "+n2);
		Debug.Log("nodo pot "+np);
		Vector2 vectorNode;
		Vector2 vectorPotencial;
		float angle;
		vectorNode=n2-n1;
		vectorPotencial=np-n2;
		angle=Vector2.Angle(vectorNode,vectorPotencial);
		Debug.Log("vector node"+vectorNode );
		Debug.Log("vector pot"+vectorPotencial);
		Debug.Log("final angle "+angle); 
		return angle;
	}
	public Vector2 GettinVectorConstrain(float magnitud, float constrain){
		Vector2 vec;
		vec.x=magnitud*Mathf.Cos(Mathf.Deg2Rad*constrain);
		vec.y=magnitud*Mathf.Sin(Mathf.Deg2Rad*constrain);
		return vec;
	}

}
