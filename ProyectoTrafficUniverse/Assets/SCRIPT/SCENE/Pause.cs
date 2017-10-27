
using UnityEngine;

public class Pause : MonoBehaviour {
	public GameObject pause;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){

			print("pasu game");
			if(!pause.activeSelf){
			Time.timeScale=0.0f;
			pause.SetActive(true);
			}else{
			print("despause");
			pause.SetActive(false);
			Time.timeScale=1.0f;
			
			}
		}
	
	}
}
