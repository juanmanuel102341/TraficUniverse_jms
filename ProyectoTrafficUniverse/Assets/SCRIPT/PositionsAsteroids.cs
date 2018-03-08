using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsAsteroids : MonoBehaviour {
//guarde posiciones iniciales y se posicionen cuando sean requeridas en las mismas

	private List<GameObject>asteroids=new List<GameObject>();
	private List<Vector2>listPosInitial=new List<Vector2>();
	void Awake () {
		for(int i=0;i<transform.childCount;i++){
			asteroids.Add(transform.GetChild(i).gameObject);
//			print(transform.GetChild(i).gameObject.name+" tranform child asteroide "+asteroids[i].transform.position);
			listPosInitial.Add(asteroids[i].transform.position);
		}	
//		print("cant d asteroides "+asteroids.Count);
	}
	
	public void SetOffSprite(){

		for(int i=0;i<asteroids.Count;i++){
			asteroids[i].SetActive(false);
		}
	}
	public void SetOnSprite(){
		for(int i=0;i<asteroids.Count;i++){

			asteroids[i].transform.position=new Vector2(listPosInitial[i].x,listPosInitial[i].y);
			asteroids[i].SetActive(true);
		}
	}
}
