
using UnityEngine;
using System.Collections.Generic;
public class Rotate : MonoBehaviour {
	private float angularVelocity;
	public float []lerpAngular=new float[2];
	void Awake(){
		angularVelocity=Random.Range(lerpAngular[0],lerpAngular[1]);
//		print("angular vel "+angularVelocity);
	}
	void Update () {
		transform.Rotate(Vector3.forward*Time.deltaTime*angularVelocity);
		}
}
