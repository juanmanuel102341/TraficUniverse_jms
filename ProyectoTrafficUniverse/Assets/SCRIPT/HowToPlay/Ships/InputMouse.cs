
using UnityEngine;

public class InputMouse : MonoBehaviour {

	public Animation_Path currentAnimationPath;

	void Awake () {
				//animation_path=GameObject.FindGameObjectWithTag("groupNodes").GetComponent<Animation_Path>();
	
	}
	void OnTriggerEnter2D(Collider2D col) {
		print("empieza parte nodal");
		//pointer.GetComponent<ManageComponents>().Deactive();//desactivo movvimiento, collider y canal alfa del mouses
		currentAnimationPath.getActive=true;

	}

}
