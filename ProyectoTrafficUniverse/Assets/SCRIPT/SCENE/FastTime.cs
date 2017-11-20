
using UnityEngine;

public class FastTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnIncrement(){
		print("incrementando tiempo");
		if(Time.timeScale!=2.5f)
		Time.timeScale=2.5f;
	}
	public void OnNormal(){
		print("time normal");
		if(Time.timeScale!=1.0f)
		Time.timeScale=1.0f;
	}
}
