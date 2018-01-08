
using UnityEngine;

public class PositionMouse : MonoBehaviour {
	private Camera camera;
	void Awake(){
		camera=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	public Vector2 Calc(){
		//	print("CLICKmOUSE");
		Vector2 aux;
		aux=Input.mousePosition;
		aux=camera.ScreenToWorldPoint(aux);
		//print("posicion mouse "+aux);
		return aux;

	}
}
