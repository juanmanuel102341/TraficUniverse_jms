using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimations : MonoBehaviour {
	

	private Animator animator;
	private MyPath ppath;
	private AngleMove angle;
	private Vector2 myTransformUp;
	private Vector2 transformUp;
	private bool initAnimator=true;
	private SpriteRenderer spr;
	private MoveSoft moveSoft;
	private float angleBetween;
	public GameObject id;
	public BoxCollider2D box;
	//con q angulo de salida saldria , depende de q costtado spawnee
	void Awake () {
		//print("vecctor up whorld " +vectorWorld);
		animator=GetComponent<Animator>();
		animator.enabled=true;
		ppath=GetComponent<PathInputs>().getMyPrinciplePath;
		angle=new AngleMove();
		transformUp=new Vector2(0,1);
		spr=GetComponent<SpriteRenderer>();
		moveSoft=GetComponent<MoveSoft>();
		//id=GameObject.FindGameObjectWithTag("id");
		print("id "+id);
	}
	void Update () {
		//Calc();
		//print("tup "+myTransformUp);
		//print("euler "+n);
		//print("angle "+a);

		//nitialAngle=90;
	//	print("angleBetween "+angleBetween);
		animator.SetFloat("intensityUp",angleBetween);
		if(ppath.getListVectors.Count>0){
			//animator.enabled=true;

		
			if (!ClickRight()){
				spr.flipX=true;
				id.transform.position=new Vector2(transform.position.x-0.5f,transform.position.y);
				box.transform.position=new Vector2(transform.position.x-0.35f,transform.position.y);

			}else{
				spr.flipX=false;
				print("flipiando");
				id.transform.position=new Vector2(transform.position.x+0.5f,transform.position.y);
				box.transform.position=new Vector2(transform.position.x+0.5f,transform.position.y);

			}
			myTransformUp=angle.VectorUp(ppath.getListVectors[0],transform.position);
			angleBetween=Vector2.Angle(myTransformUp,transformUp);
		
		//	print("angle2 "+angleBetween);
		}

	}
	private bool ClickRight(){
		if(ppath.getListVectors[0].x>transform.position.x){
			//print("faceUp ClickRight true");
			return true;
		}
//		print("faceUp ClickRight false");
		return false;
		}


	public float setAngleBetween{
		set{
			angleBetween=value;
		}
	}
}
