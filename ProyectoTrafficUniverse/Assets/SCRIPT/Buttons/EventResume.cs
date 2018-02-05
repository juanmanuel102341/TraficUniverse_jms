
using UnityEngine;

public class EventResume : MonoBehaviour {

	public delegate void OnResumeMe();
	public event OnResumeMe onResume;
	public void OnResume(){
		Time.timeScale=1.0f;


		onResume();
	}

}
