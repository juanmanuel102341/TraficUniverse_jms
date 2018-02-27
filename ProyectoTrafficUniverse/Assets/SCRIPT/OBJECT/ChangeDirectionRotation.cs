
using UnityEngine;

public class ChangeDirectionRotation : MonoBehaviour {
	private RotateAround rotate;

	void Awake(){
		rotate=GetComponent<RotateAround>();

	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag=="asteroide"){
			print("contacto asteroide asteroide");
		//	pint("dir previa "+)
			rotate.myDirection*=-1;
		}
	}

}
