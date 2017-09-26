
using UnityEngine;

public class MoveWhithoutPath : MonoBehaviour {

	private Vector2 vector;

	private Move move;
	private Rigidbody2D rb;
	void Awake () {

		move=GetComponent<Move>();
		rb=GetComponent<Rigidbody2D>();
		//transform.up=calcDirection();
	}
	

	void Update () {
		


		rb.transform.Translate(move.getFinalVec*move.velocity*Time.deltaTime);

	}
	private Vector2 calcDirection(){
		Vector2 auxPosP;
		Vector2 target;
		Vector2 r;
		auxPosP.x=transform.position.x;
		auxPosP.y=transform.position.y;
		target=move.getFinalVec;
		r=target-auxPosP;
		return r;
	}


}
