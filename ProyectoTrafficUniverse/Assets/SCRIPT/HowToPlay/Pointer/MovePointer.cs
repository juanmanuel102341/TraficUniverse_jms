
using UnityEngine;

public class MovePointer : MonoBehaviour {
	public Transform target;
	public float velocity;
	public AnimationPath animationPath;
	private Vector2 destiny;
	void Start(){
		
		destiny=target.position;
		SetEventAnimation(animationPath);
	}
	void Update () {
//		print("entrando ");
		transform.position=Vector2.MoveTowards(transform.position,destiny,velocity*Time.deltaTime);
	}
	private void onMyFinishNode(Vector2 _target){
	//	print("taget "+_target);
		destiny=_target;
		velocity=8;
	}
	public void SetDestiny(Vector2 _destiny){
		destiny=_destiny;
	}

	public void SetEventAnimation(AnimationPath anim){
		anim.onFinishNode+=onMyFinishNode;
	}
}

