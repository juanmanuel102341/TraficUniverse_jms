using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_How_to_play : MonoBehaviour {

	public Animation_Path animation_Path;
	public float velocity;
	void Awake () {
	//	animation_Path=GameObject.FindGameObjectWithTag("groupNodes").GetComponent<Animation_Path>();
	}
	
	// Update is called once per frame
	void Update () {
		if(animation_Path.getFinish){
			transform.position=Vector2.MoveTowards(transform.position,animation_Path.getCurrentVector,velocity*Time.deltaTime);
			print("actual "+animation_Path.getCurrentVector);
		}
	}
	public void Delete(){
		animation_Path.DeleteNodes();
		Destroy(this.gameObject);
	}
}
