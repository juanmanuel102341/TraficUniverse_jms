
using UnityEngine;

public class MovePointer : MonoBehaviour {
	public Transform transInitialTarget;
	public float velocity;
	private Vector2 myTarget;
	private Vector2 initialTarget;
	public AnimationPath [] animations;
	private AnimationPath currentAnimationPath;
	public Transform [] transfInitials;
	private int index=0;
	private int indexI=0;
	void Awake(){
		myTarget=transInitialTarget.position;
		initialTarget=myTarget;
		currentAnimationPath=animations[0];
		index=0;
		indexI=0;
		initialTarget=transfInitials[indexI].position;
	}
	void Start(){
		Events();
	}
	void Events(){
		currentAnimationPath.finishNode+=OnFinishNode;
	}
	void Update () {
//		print("entrando ");
		transform.position=Vector2.MoveTowards(transform.position,myTarget,velocity*Time.deltaTime);
	}
	public Vector2 setMyTarget{
		set{
			myTarget=value;	
		}
	}
	public void setMyAnimationPath(){
	index++;
		print("cambiando animacion");
	currentAnimationPath=animations[index];
	Events();
		
	}
	public Vector2 getMyInitialTarget{
	
		get{
			return initialTarget; 
		}
	
	}
	private void OnFinishNode(Vector2 _node){
		myTarget=_node;
	} 
//	public void setMyInitialTarget(){
//		
//		initialTarget=transfInitials[indexI].position;
//	}

		
}
