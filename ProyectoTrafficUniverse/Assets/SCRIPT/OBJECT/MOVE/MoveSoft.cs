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



	public int total;
	private int count=0;
	private float quantity=0;
	private float totalXQuantity=0;
	private float t;
	private bool active_lerp=false;

	void Awake () {
		pathInputs=GetComponent<PathInputs>();
		angle=new AngleMove();
		//timer=new Timer(timeAnim,this);
		playerPos=transform.position;

	}
	void Start(){
		nodeState=new NodeState(pathInputs.path,this);
	}
	
	// Update is called once per frame
	void Update () {
		onUpdate();

		//Debug.Log("euler "+transform.localEulerAngles.z);
		Move2();

		RotateMe();
	//	print("euler "+transform.eulerAngles.z);
	//	print("up  "+transform.up);
		playerPos=transform.position;

	
	}
		public Vector2 getPlayerPos{
			get{
					return playerPos;		
				}
			}

	private void Move2(){
		if(pathInputs.path.listNodes.Count>0){
			setAngle();	
			transform.position=Vector2.MoveTowards(transform.position,pathInputs.path.listNodes[0],velocity*Time.deltaTime);
		//	Debug.Log("entrando tp");

		}else{
			if(active_lerp)
			{
				float temp=totalXQuantity;
				Lerp();
				
			}

			transform.Translate(Vector2.up*velocity*Time.deltaTime);
		}
		}
	public bool ApplyAngleRotation(){
		if(nodeState.getFinal){
		//	print("apply");
			return true;
		}
		return false;
	}


	private void setAngle(){
		if(nodeState.getFinal){
			Debug.Log("apply angle 2");
	//	transform.up=angle.AngleBetween2(pathInputs.path.listNodes[0],transform.position);

			float temp=totalXQuantity;
			targetVector=angle.AngleBetween2(pathInputs.path.listNodes[0],transform.position);
			totalXQuantity=targetVector.x-transform.up.x;

			if(active_lerp){
				
				quantity=temp;
				print("entrando lerp "+quantity);
			}else{
				quantity=totalXQuantity/total;
			}
			t=0;

			Debug.Log("quantity "+quantity);
			Debug.Log("total "+totalXQuantity);
			//	vecPerUnit=targetVector.x/total;
		//	Debug.Log("target "+targetVector);
		//	Debug.Log("vec per unit "+vecPerUnit);
			activeRotation=true;
			nodeState.getFinal=false;
		//	timer.StartTime=true;
		//	p1=transform.position;
		//	count=0;

	         	}
		}
	private void RotateMe(){
		if(activeRotation)
		{	
						
			transform.up=new Vector2(Lerp(),targetVector.y);


		}

	}
		private float Lerp(){


		float aux=Mathf.Lerp(quantity,totalXQuantity,t);
					t+=Time.deltaTime;
				
					Debug.Log("lerpeo "+aux);
		if(t>totalXQuantity){
			Debug.Log("lerpeo completo!!!!!");
			active_lerp=true;
		}
		return aux;
		}
	}
