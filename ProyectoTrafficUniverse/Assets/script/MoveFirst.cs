
using UnityEngine;

public class MoveFirst :Move {
	private int direccion=1;

	void Awake () {


	}
	
	public Vector2 MoveIdle(){
		Vector2 vec=Vector2.up*direccion;
		return vec;
	}



}
