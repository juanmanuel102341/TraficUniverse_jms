
using UnityEngine;

public class Mouse1 : MonoBehaviour {
	public Transform target;
	public float velocity;
	void Update () {
//		print("entrando ");
		transform.position=Vector2.MoveTowards(transform.position,target.position,velocity*Time.deltaTime);
	}
}
