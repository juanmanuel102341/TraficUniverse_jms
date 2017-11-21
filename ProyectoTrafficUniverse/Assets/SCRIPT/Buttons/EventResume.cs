
using UnityEngine;

public class EventResume : MonoBehaviour {

	public delegate void OnResumeMe();
	public static event OnResumeMe onResume;
	public void OnResume(){
		Time.timeScale=1.0f;

		GameObject.FindGameObjectWithTag("pause").SetActive(false);
		onResume();
	}

}
