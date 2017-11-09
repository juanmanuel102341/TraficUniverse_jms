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

	public Time time;
	public int total;
	private int count=0;
	private float quantity=0;
	private float totalXQuantity=0;
	private float t;
	private bool active_lerp=false;
	private int direccion=1;
	Vector2 p1;
	Vector2 p2;

	void Awake () {
		pathInputs=GetComponent<PathInputs>();
		angle=new AngleMove();
		//timer=new Timer(time,this);
		playerPos=transform.position;
		bounds=GetComponent<Bounds>();
	}
	void Start(){
		nodeState=new NodeState(pathInputs.path,this);
	
	}
	
	// Update is called once per frame
	void Update () {
		onUpdate();
		//Debug.Log("euler "+transform.localEulerAngles.z);
		Move2();

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
		if(!bounds.limiteActive){
		if(pathInputs.path.listNodes.Count>0){
				RotateMe();
				setAngle();	
			
		transform.position=Vector2.MoveTowards(transform.position,pathInputs.path.listNodes[0],velocity*Time.deltaTime);
		//	Debug.Log("entrando tp");

		}else{
				transform.Translate(Vector2.up*velocity*Time.deltaTime,Space.Self);
//			if(bounds.limiteActive){
//				velocity=0;
//			}
		}
		}else{
			Debug.Log("borrando paths ");
			pathInputs.DeletesAllPaths();
			transform.up=transform.up*-1;
			bounds.limiteActive=false;

		}
		//	MyBounds();
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
			p1=transform.position;
			Debug.Log("apply angle 2");
	//	transform.up=angle.AngleBetween2(pathInputs.path.listNodes[0],transform.position);

			float temp=totalXQuantity;
			targetVector=angle.AngleBetween2(pathInputs.path.listNodes[0],transform.position);
			totalXQuantity=targetVector.x-transform.up.x;

			if(active_lerp){
				
				quantity=totalXQuantity/total;
				print("entrando lerp "+quantity);
			}else{
				quantity=totalXQuantity/total;
			}
			t=0;
			quantity+=temp;
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
				
//					Debug.Log("lerpeo "+aux);
		if(t>totalXQuantity){
//			Debug.Log("lerpeo completo!!!!!");
			active_lerp=true;
		}
		return aux;
		}
//	private void MyBounds(){
//		if(bounds.limiteActive){
//			pathInputs.Delete();
//			transform.up=transform.up*-1;
//			bounds.limiteActive=false;
//		}
//	}
}
