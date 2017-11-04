
using UnityEngine;

public class Timer {
	private float time;
	private float target;
	private bool finish=false;
	private bool start=false;
	public Timer(float timeLimit,  MoveSoft sc){
		finish=false;
		start=false;
//		sc.onUpdate+=MyUpdate;
		target=timeLimit;
	}

	public void MyUpdate () {
	//	Debug.Log("time act");
		if(!finish&&start){
		time+=Time.deltaTime;		
		calc();
	//	Debug.Log("time "+time);
		}

	}
	private void calc(){
		if(time>target){
			finish=true;
			start=false;
			time=0.0f;
	//		Debug.Log("finish time");
		}
	}
	public bool finishTime{
		get{
			return finish;
		}
		set{
			finish=value;
		}
	}
	public bool StartTime{
		set{
			start=value;

		}
	}
		
}
