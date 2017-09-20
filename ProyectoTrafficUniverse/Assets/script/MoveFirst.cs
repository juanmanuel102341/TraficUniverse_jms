
using UnityEngine;

public class MoveFirst : MonoBehaviour {
	private Move move;

	void Awake () {
		move=GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () {
		move.getRigidBody2D.transform.Translate(Vector2.up*move.getVelocity*Time.deltaTime);
	}
}
