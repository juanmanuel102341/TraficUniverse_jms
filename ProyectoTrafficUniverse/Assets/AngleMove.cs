
using UnityEngine;

public class AngleMove {
	private float distance;

	public AngleMove(){
		
	}
	public float AngleBetween(Vector2 vecNode, Vector2 vecPlayer,Vector2 tup){
		
		Vector2 mod=vecNode-vecPlayer;
		float r;
		r=Vector2.Angle(mod,tup);
		Debug.Log("angle "+r);
		if(vecNode.x>vecPlayer.x&&vecNode.y>vecPlayer.y){
		//	Debug.Log("cambio singo");
			r=-r;
		}
//		Debug.Log("res "+r);
		return r;
	}
	public float AnglePerUnit(Vector2 myPos, Vector2 PathPos,float myAngle){
		float distance=Vector2.Distance(myPos,PathPos);
		float angle=myAngle/distance;//razon de angulo por distancia para dividir o normalizar el total del angulo q tiene efectuar segun la distancia
		Debug.Log("distance "+distance);
		Debug.Log("angulo div distancia "+angle);

		return angle; 
	}

}
