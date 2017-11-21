
using UnityEngine;

public class FastTime : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Time.timeScale=1.0f;
	}
	
	public void OnIncrement(){
		if(Time.timeScale!=0){
	//si no apreto pausa
			print("incrementando tiempo");
		if(Time.timeScale!=2.5f)
		Time.timeScale=2.5f;
		
		}
	}
	public void OnNormal(){
		if(Time.timeScale!=0){
		print("time normal");
		if(Time.timeScale!=1.0f)
		Time.timeScale=1.0f;

		}
	}
	public void OnResetMe(){
		Time.timeScale=1.0f;
	}
}
