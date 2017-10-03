﻿using UnityEngine;
public class MoveWhithoutPath : MonoBehaviour {
	private Vector2 vector;
	private Move move;
	private int direccion=1;
	private bool active=false;
	private Bounds bounds;
	void Awake () {
		move=GetComponent<Move>();
		bounds=GetComponent<Bounds>();
	}
	void Update () {
		if(!active){
			transform.up=move.getFinalVec;
			active=true;
		}
		Direction();
		transform.Translate(Vector3.up*move.velocity*Time.deltaTime*direccion);
	}
	private void Direction(){
		if(bounds.limiteActive){
			transform.up=-transform.up;
		}
	}
	public bool setBooleanDirection{
		set{
			active=value;//boolean q seteo en move para una proxima vez
		}
	}

}