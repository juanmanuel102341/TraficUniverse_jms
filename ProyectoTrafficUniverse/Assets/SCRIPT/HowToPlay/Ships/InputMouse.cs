
using UnityEngine;

public class InputMouse : MonoBehaviour {
	private AnimationPath animationPath;
	private MoveHowToPlay moveHowTplay ;
	public GameObject pointer;
	void Awake () {
		animationPath=GetComponent<AnimationPath>();
		moveHowTplay=GetComponent<MoveHowToPlay>();
		animationPath.enabled=false;
		moveHowTplay.enabled=false;
	}
	void OnTriggerEnter2D(Collider2D col) {
		print("empieza parte nodal");
		pointer.GetComponent<ManageComponents>().Deactive();//desactivo movvimiento, collider y canal alfa del mouses
		animationPath.enabled=true;
		moveHowTplay.enabled=true;
	}

}
