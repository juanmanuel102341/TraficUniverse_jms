
using UnityEngine;

public class RotateAround : MonoBehaviour {
	public Transform transfObj; 
	public Vector2 rangeVelocity;
	private float velocity;
	private int dir;
	// Use this for initialization
	void Start () {
		velocity=RandomMe(rangeVelocity.x,rangeVelocity.y);
//		print("vel rotacion "+velocity);
		dir=RandomDirection();
		//dir=1;
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transfObj.position,Vector3.forward,velocity*Time.deltaTime*dir);	
	}
	private float RandomMe(float v1,float v2){
		return Random.Range(v1,v2);
	}
	private int RandomDirection(){
		int n=Random.Range(0,2);
		if(n==0){
			n=1;
		}else{
			n=-1;
		}
	//	print("my direction " +n);
		return n;
	}
	public int myDirection{
		set{
			dir=value;
		}
		get{
			return dir;
		}
	}
}
