﻿
using UnityEngine;

public class Nodo  {

	public Vector2 posicion;

	void Awake () {
		
	}


	public void SetPosition(Vector2 pos){
		posicion.x=pos.x;
		posicion.y=pos.y;
	}
}
