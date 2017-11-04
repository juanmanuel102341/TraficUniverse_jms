using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSoft : MonoBehaviour {
	private AngleMove angle;
	private PathInputs pathInputs;
	private bool active=false;
//	private Timer timer;
	public float angularVelocity;
//	public delegate void OnUpdate();
//	public event OnUpdate onUpdate;
	float anglePath=0;
	private Vector2 currentPath;
	private float anglePerUnit;
	void Awake () {
		pathInputs=GetComponent<PathInputs>();
		angle=new AngleMove();
		//timer=new Timer(timeAnim,this);
	}
	
	// Update is called once per frame
	void Update () {
		//onUpdate();
		if(pathInputs.path.listNodes.Count>0&&!active){
			currentPath=pathInputs.path.listNodes[0];
			anglePath=angle.AngleBetween(currentPath,transform.position,transform.up);
			//print("angle between "+a);
//			timer.StartTime=true;
			active=true;
			anglePerUnit=angle.AnglePerUnit(transform.position,currentPath,anglePath);
		}	
		if(active){
			float distanceAbs=Mathf.Abs(angle.AngleBetween(currentPath,transform.position,transform.up));
			print("ditance abs"+distanceAbs);
			if(distanceAbs>0.5f){
				transform.Rotate(new Vector3(0,0,anglePerUnit*Time.deltaTime*angularVelocity),Space.Self);
			}else{
				active=false;
			}
		}
	
	}


}
