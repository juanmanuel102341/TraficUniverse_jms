
using UnityEngine;

public class InputMouse : MonoBehaviour {
	private AnimationPath animationPath;
	private MoveHowToPlay moveHowTplay ;
	public GameObject pointer;
	public GameObject mouse;
	private Vector2 posTargetMouse;
	public MovePointer movePointer;
	public delegate void ActiveState();
	public event ActiveState activeState;
	private GameObject myId;
	void Awake () {
		animationPath=GetComponent<AnimationPath>();
		moveHowTplay=GetComponent<MoveHowToPlay>();
		animationPath.enabled=false;
		moveHowTplay.enabled=false;
	posTargetMouse=transform.GetChild(1).position;
		myId=transform.GetChild(0).gameObject;
//		print("my child id"+myId.gameObject.name);
		print("my transform "+transform.GetChild(1).gameObject.name);
	}
	void OnTriggerEnter2D(Collider2D col) {
		
//		print("empieza parte nodal");
	//	pointer.GetComponent<ManageComponents>().Deactive();//desactivo movvimiento, collider y canal alfa del mouse
		//animationPath.enabled=true;
		//moveHowTplay.enabled=true;

		if(!mouse.activeSelf){
		mouse.SetActive(true);

			mouse.GetComponent<Mouse>().setMyStartTime();
	//	movePointer.setMyTarget=posTargetMouse.position;
		}else{
			print("trigue sstate volvi a entrar");
		//	movePointer.setMyTarget=movePointer.getMyInitialTarget;//volve a tu objetivo
			activeState();
		}
		
	}
	public void ActiveId(){
		myId.SetActive(true);
	}
	public Vector2 getMyPosPointer{
		get{
			return posTargetMouse;
		}
	}

}
