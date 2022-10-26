
using UnityEngine;

public class MovePointer : MonoBehaviour {
	public Transform target;
	public float velocity;
	private Vector2 destiny;
	void Start(){
		
		destiny=target.position;
}
	void Update () {
//		print("entrando ");
		transform.position=Vector2.MoveTowards(transform.position,destiny,velocity*Time.deltaTime);
	}
	public void SetDestiny(Vector2 _destiny){
		destiny=_destiny;
	}

}

