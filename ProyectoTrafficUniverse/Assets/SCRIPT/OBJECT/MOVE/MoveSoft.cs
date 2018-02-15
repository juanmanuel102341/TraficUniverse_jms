﻿using System.Collections;
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
	private SpriteRenderer spr;
	float timeLerp=10.0f;
	private MyPath myPpath;
	private int dir=1;
	private Vector2 myVector;
	private bool initial=true;
	private Vector2 lastNode;

	private bool first=false;
	private float propx;
	private float propy;
	void Awake () {
		pathInputs=GetComponent<PathInputs>();

		spr=GetComponent<SpriteRenderer>();
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
		pathInputs.path.onMyClickUp+=onClickUp;
	}
	void Update () {
		
		Move2();
		playerPos=transform.position;

	}

		private void Move2(){
		print("prop x "+propx);
		print("prop y "+propy);
		if(!bounds.limiteActive){
			
			if(myPpath.getListVectors.Count>0){
				initial=false;
			//	setAngle();	
			//	RotateMe();
				transform.position=Vector2.MoveTowards(transform.position,myPpath.getListVectors[0],velocity*Time.deltaTime);
		//	Debug.Log("entrando tp");

				onUpdate();//pregunta si llego al node
				if(myPpath.getListVectors.Count==1&&!first){

				
					first=true;
				}
			}else{
				if(!nodeState.getFinal){
					nodeState.getFinal=true;
				}

				initializeLerp=false;

				if(!initial){
					myVector.x=1*propx;
					myVector.y=1*propy;
//					print("myvector "+myVector);
				}

				//myVector=Vector2.up;//quiero q vayan para arriba cuando no tienen mas nodes
				transform.Translate(myVector*dir*velocity*Time.deltaTime,Space.Self);//no tocar space.self!!!!!!!!!!!
		}
		}else{
			//Debug.Log("borrando paths ");
			if(myPpath.getListVectors.Count>0)
			myPpath.DeleteAllNodes();

			transform.up=transform.up*-1;
			bounds.limiteActive=false;

		}
	}


	public Vector2 getPlayerPos{
		get{
			return playerPos;		
		}
	}
	public Vector2 setMyVector{
		set{
			myVector=value;	
		}
		get{
			return myVector;
		}
	}


	public void setMyEvent(){
		pathInputs.path.onMyClickUp+=onClickUp;
	}
	public void onClickUp(float px,float py){
		print("entrando en mi evento");
		print("click x "+px);
		print("click y "+py);
		propx=px;
		propy=py;
	}
		
}
