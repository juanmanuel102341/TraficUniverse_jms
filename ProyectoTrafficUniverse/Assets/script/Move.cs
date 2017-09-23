
using UnityEngine;

public class Move : MonoBehaviour {

	public float velocity;
	private MovePath movePath;
	private MoveWhithoutPath moveWhithoutPath;
	private MoveFirst moveFirst;
	private Rigidbody2D rb;
	private PathController path;



	void Awake () {
		moveFirst=GetComponent<MoveFirst>();
		movePath=GetComponent<MovePath>();
		moveWhithoutPath=GetComponent<MoveWhithoutPath>();
	
		rb=GetComponent<Rigidbody2D>();
		path=GetComponent<PathController>();
		MonoBehaviour[] obj=new MonoBehaviour[2];
		obj[0]=movePath;
		obj[1]=moveWhithoutPath;
		Deactive(obj);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void Deactive(MonoBehaviour[] objeto){
		for(int i=0;i<objeto.Length;i++){
		objeto[i].enabled=false;
		
		}
	}
	public float getVelocity{
		get{
			return velocity;
		}
	}
	public Rigidbody2D getRigidBody2D{
		get{
			return rb;
		}
	}
	public PathController getPath{
		get{
			return path;
		}
	}

}
