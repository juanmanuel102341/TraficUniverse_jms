
using UnityEngine;

public class AngleMove {
	public AngleMove(){
		
	}

	public Vector2 VectorUp(Vector2 vecNode, Vector2 vecPlayer){

		Vector2 mod=vecNode-vecPlayer;

		return mod;
	}

}
