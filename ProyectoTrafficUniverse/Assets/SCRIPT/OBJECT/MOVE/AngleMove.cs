
using UnityEngine;

public class AngleMove {
	public AngleMove(){
		
	}

	public Vector2 AngleBetween2(Vector2 vecNode, Vector2 vecPlayer){

		Vector2 mod=vecNode-vecPlayer;

		return mod;
	}

}
