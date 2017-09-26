
using UnityEngine;

public class MoveWhithoutPath : MonoBehaviour {

	private Vector2 vector;

	private Move move;
	private Rigidbody2D rb;
	void Awake () {

		move=GetComponent<Move>();
		rb=GetComponent<Rigidbody2D>();
	}
	

	void Update () {
		
		rb.transform.Translate(move.getFinalVec*move.velocity*Time.deltaTime);
		}


}
