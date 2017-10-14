
using UnityEngine;

public class InputMouse : MonoBehaviour {
	public GameObject nodeMovement;
	public GameObject pointer;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D col) {
		print("empieza parte nodal");
		Destroy(pointer);
		nodeMovement.SetActive(true);
	}

}
