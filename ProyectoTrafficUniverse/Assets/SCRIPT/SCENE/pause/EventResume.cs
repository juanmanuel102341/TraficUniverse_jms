
using UnityEngine;

public class EventResume : MonoBehaviour {


	public void OnResume(){
		Time.timeScale=1.0f;
		GameObject.FindGameObjectWithTag("pause").SetActive(false);

	}

}
