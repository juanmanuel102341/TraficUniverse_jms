using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainLastNode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

	public GameObject Obtain(){
		GameObject []aLast=GameObject.FindGameObjectsWithTag("lastNode");
		for(int i=0;i<aLast.Length;i++){
			float d=Distance(aLast[i]);
			print("obj "+i);
			print("distnace "+d);
			if(d<1){
				return aLast[i];
			}
		}
		return null;

	}
	private float Distance(GameObject obj){
		return Vector2.Distance(transform.position,obj.GetComponent<Transform>().position);
	}
}
