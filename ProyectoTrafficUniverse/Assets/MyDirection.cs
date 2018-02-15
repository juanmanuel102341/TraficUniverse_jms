
using UnityEngine;

public class MyDirection : MonoBehaviour {
	public Transform transformParent;

	void Start () {
		print("compnente padre "+transform.GetComponentInParent<Transform>().gameObject.GetComponentInParent<Transform>().gameObject);
	
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position=new Vector2(transform.position.x,transformParent.position.y);	
	}
}
