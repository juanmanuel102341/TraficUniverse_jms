
using UnityEngine;

public class FastTime : MonoBehaviour {
	public delegate void SpeedUp();
	public event SpeedUp speedUp;
	public event SpeedUp speedNormal;
	// Use this for initialization
	void Awake () {
		Time.timeScale=1.0f;
	}
	
	public void OnIncrement(){
		if(Time.timeScale!=0){
	//si no apreto pausa
			if(MyParams.soundActive){
			speedUp();
			}
			print("incrementando tiempo");
			if(Time.timeScale!=2.5f){
			Time.timeScale=2.5f;
//				
			}
		
		}
	}
	public void OnNormal(){
		if(Time.timeScale!=0){
		print("time normal");
			if(MyParams.soundActive){
			speedNormal();
			}
			if(Time.timeScale!=1.0f){
			Time.timeScale=1.0f;

			}
			

		}
	}
	public void OnResetMe(){
		Time.timeScale=1.0f;
	}
}
