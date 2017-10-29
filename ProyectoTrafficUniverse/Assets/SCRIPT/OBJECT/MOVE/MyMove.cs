using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMove : MonoBehaviour {
	protected Vector2 vecDirection;
	private PathInputs pathInputs;
	public float velocity;
	private Bounds bounds;
	void Awake () {
		pathInputs=GetComponent<PathInputs>();
		bounds=GetComponent<Bounds>();
	}
	
	// Update is called once per frame
	void Update () {
		pathInputs.path.moveShip.playerPos2=transform.position;
		pathInputs.path.moveShip.limit_active=bounds.limiteActive;
		GettingMyVectorDirection();
		transform.Translate(transform.up*velocity*Time.deltaTime,Space.World);
//		print("final node move "+pathInputs.path.moveShip.finalNode);
		if(pathInputs.path.moveShip.finalNode){
//			print("nodo ultimo borrarlos ");
			pathInputs.Delete();
			pathInputs.path.moveShip.finalNode=false;
		}
	}
	private void GettingMyVectorDirection(){
		if(pathInputs.path.moveShip.active||pathInputs.path.moveShip.limit_active){
			Vector2 auxP;

			transform.up=pathInputs.path.moveShip.myVector;
//			print("transfor my move "+transform.up);
//			print("vec calc "+ pathInputs.path.moveShip.myVector);
		pathInputs.path.moveShip.active=false;
		}
	}


}
