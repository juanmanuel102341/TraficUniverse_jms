
using UnityEngine;

public class MyEvent : MonoBehaviour {

	private string id;
	public delegate void Finish(string _id);
	public event Finish finish;
	void Awake () {
		id=tag;

	}
	void OnTriggerEnter2D(Collider2D col) {
		print("triguer rojo");
		finish(id);
	}

}
