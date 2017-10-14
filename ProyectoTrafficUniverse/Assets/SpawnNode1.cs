
using UnityEngine;

public class SpawnNode1 : MonoBehaviour {
	public GameObject node;
	private float time;
	public float frame;
	public float gap;
	private Vector2 vec;
	public float total;
	private float g=0;
	// Use this for initialization
	private int cont=0;
	private bool active=false;

	float px=0;
	float py=0;
	Vector2 res;
	float acumX=0;
	float acumY=0;
	Vector2 d;
	public Transform target;


	Vector2 vecBase;
	Vector2 vecTarget;
	Vector2 param;
	float r;
	float alfaX=0;
	float alfaY=0;
	void Start () {
	//vec=this.transform.position;
		vec.x=1;
		vec.y=1;
	//	print("vec "+vec);
		px=PropX();

		py=PropY();
		print("px "+px);
		print("py "+py);
		d.x=transform.position.x;
		d.y=transform.position.y;

		vecBase=transform.position;
		vecTarget=target.position;
		param=vecTarget-vecBase;
		alfaX=PropX();
		alfaY=PropY();
	}
	

	void OnTriggerEnter2D(Collider2D col) {
		print("entrando nodo dibujo");

		active=true;

	}
	void Update(){
		
		if(active){
			time+=Time.deltaTime;
			print("time "+time);
			NodeCreation();
		}
	}
	void NodeCreation(){
		if(time>frame){
			print("nodo");

			param.x*=alfaX;
			param.y*=alfaY;
			//GameObject obj=Instantiate(node,d,transform.rotation);
			Instantiate(node,param,transform.rotation);

			//obj.transform.position=new Vector2(transform.position.x+acumX,transform.position.y+acumY);
			//acumX+=gap*px;
			//acumY+=gap*py;
			alfaX+=alfaX;
			alfaY+=alfaY;
			time=0;


			//	g+=0.15f;
		}
	}
	private float Distance(Vector2 pos1,Vector2 pos2){
		return Vector2.Distance(pos1,pos2);
	}
	private float PropX(){

		return transform.position.x/Distance(transform.position,target.position);
	}
	private float PropY(){
		return transform.position.y/Distance(transform.position,target.position);
	}
}
