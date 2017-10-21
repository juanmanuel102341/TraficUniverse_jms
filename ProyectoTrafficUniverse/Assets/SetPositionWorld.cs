
using UnityEngine;

public class SetPositionWorld : MonoBehaviour {

//	private float myFloat=0; 
	private Transform t;
	private float posInitial;
	public Transform[] aTransforms;
	private int myEulerZ;
	void Awake () {
		//down left right uo



	}
	void Start(){
		

	}
	public void Apply(int euler){
		//AlertColision alertColision=GameObject.FindGameObjectWithTag("colisionArea").GetComponent<AlertColision>();
		print("euler");
		Transform aux=SettingMyPos(euler);

	

		transform.localPosition=aux.localPosition;

		posInitial=euler;
		print("myfloat "+posInitial);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.localEulerAngles=new Vector3(0,0,myFloat);
		transform.up=new Vector2(0,posInitial);
			
	}
	private Transform SettingMyPos(int angle){
		switch(angle)
		{
			case 0:
			print("down "+aTransforms[0].position);
			return aTransforms[0];


		case 90:
			print("rightt "+aTransforms[2].position);
			return aTransforms[2];


		case 180:
			print("up "+aTransforms[3].position);
			return aTransforms[3];


		case 270:
			print("left "+aTransforms[1].position);
			return aTransforms[1];

			default:
			
			print("warning posicion alert attention wrong");
			return transform;
		}

	}
	public int setEuler{
		set{
			myEulerZ=value;
		}

	}
}
