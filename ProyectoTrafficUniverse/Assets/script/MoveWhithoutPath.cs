
using UnityEngine;

public class MoveWhithoutPath : MonoBehaviour {

	private Vector2 vector;

	private Move moveBase;
	void Awake () {

		moveBase=GetComponent<Move>();
	}
	

	void Update () {
		moveBase.getRigidBody2D.transform.Translate(vector*moveBase.getVelocity*Time.deltaTime);
	
	}
	public Vector2 setFinalVector{
		set{
			vector=value; 
		}
	}

}
