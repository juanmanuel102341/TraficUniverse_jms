
using UnityEngine;

public class ManageComponents : MonoBehaviour {
	private BoxCollider2D box;
	private SpriteRenderer spr;
	private MovePointer movePointer;

	void Awake () {

		box=GetComponent<BoxCollider2D>();
		spr=GetComponent<SpriteRenderer>();
		movePointer=GetComponent<MovePointer>();
	}
	public void Active(){
		box.enabled=true;
		spr.enabled=true;
		movePointer.enabled=true;
	}
	public void Deactive(){
		box.enabled=false;
		spr.enabled=false;
		movePointer.enabled=false;
	}

}
