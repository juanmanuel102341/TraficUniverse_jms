
using UnityEngine;

public class MoveWhithoutPath : MonoBehaviour {

	private Vector2 vector;

	private Move move;
	private int direccion=1;
	//private Rigidbody2D rb;
	private bool active=false;
	void Awake () {

		move=GetComponent<Move>();
	//	rb=GetComponent<Rigidbody2D>();
		//transform.up=calcDirection();
	}
	

	void Update () {
		if(!active){
			transform.up=move.getFinalVec;
			active=true;
		}


		transform.Translate(Vector3.up*move.velocity*Time.deltaTime*direccion);

	}
	private Vector2 calcDirection(){
		Vector2 auxPosP;
		Vector2 target;
		Vector2 r;

		//Vector2 direccion=transform.position-;

		auxPosP.x=transform.position.x;
		auxPosP.y=transform.position.y;
		target=move.getFinalVec;
		r=target-auxPosP;
		Debug.Log("vector final !!!!!!!!!!!!!!!!!!!!!!!!! "+r);
		return r;
	}
	public bool setBooleanDirection{

		set{
			active=value;
		}
	}


}
