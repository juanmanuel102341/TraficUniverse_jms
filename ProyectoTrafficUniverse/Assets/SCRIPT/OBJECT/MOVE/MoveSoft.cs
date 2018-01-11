using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSoft : MonoBehaviour {
	private AngleMove angle;
	private PathInputs pathInputs;
	private bool activeRotation=false;
	//private Timer timer;

	public delegate void OnUpdate();
	public event OnUpdate onUpdate;
	private NodeState nodeState;
	private Vector2 playerPos;
	public float velocity;
	private int directionRot=1;
	private Vector2 targetVector;
	private Bounds bounds;
	private float acumX=0;
	public int totalLerp;
	private Vector2 vec;
	private Vector2 lerpMin;
	private Vector2 lerpMax;
	private bool initializeLerp=false;

	float timeLerp=0;
	private MyPath myPpath;

	void Awake () {
		pathInputs=GetComponent<PathInputs>();


		angle=new AngleMove();
		//timer=new Timer(time,this);
		playerPos=transform.position;
		bounds=GetComponent<Bounds>();
		targetVector=transform.up;
		lerpMax=transform.up;
	
	}
	void Start(){
		nodeState=new NodeState(this,pathInputs.getMyPrinciplePath);
		myPpath=pathInputs.getMyPrinciplePath;
	}
	void Update () {

		Move2();
		playerPos=transform.position;

	}

		private void Move2(){
		if(!bounds.limiteActive){
			if(myPpath.getListVectors.Count>0){
			//	setAngle();	
			//	RotateMe();
				transform.position=Vector2.MoveTowards(transform.position,myPpath.getListVectors[0],velocity*Time.deltaTime);
		//	Debug.Log("entrando tp");

				onUpdate();//pregunta si llego al node
			}else{
				initializeLerp=false;
				transform.Translate(Vector2.up*velocity*Time.deltaTime,Space.Self);//no tocar space.self!!!!!!!!!!!
		}
		}else{
			//Debug.Log("borrando paths ");
			if(myPpath.getListVectors.Count>0)
			myPpath.DeleteAllNodes();

			transform.up=transform.up*-1;
			bounds.limiteActive=false;

		}
	}
	//private void setAngle(){
//		if(nodeState.getFinal){
//			
//			lerpMin=lerpMax;
//			Vector2 aux;
//			aux=targetVector;
//			targetVector=angle.VectorUp(pathInputs.path.listNodes[0],transform.position);
//			lerpMax=targetVector;
//			timeLerp=0;
//		//	Debug.Log("lerpMin "+lerpMin);
//		//	Debug.Log("lerMax "+lerpMax);
//			float a=Vector2.Angle(aux,targetVector);
//			nodeState.getFinal=false;
//		
//	
//		}
//		}

	private void RotateMe(){

		//Debug.Log("target "+lerpMax);
		Vector2 n=Vector2.Lerp(lerpMin,lerpMax,timeLerp);
//		Debug.Log("lerp "+n);

		timeLerp+=Time.deltaTime*2;
		transform.up=new Vector2 (n.x,n.y);

		}

	public Vector2 getPlayerPos{
		get{
			return playerPos;		
		}
	}



		
}
