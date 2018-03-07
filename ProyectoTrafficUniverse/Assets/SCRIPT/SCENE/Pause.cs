
using UnityEngine;

public class Pause : MonoBehaviour {
	public GameObject pause;
	//public Reset reset;
	//public Replay replay;
	public delegate void EventPause();
	public event EventPause PauseOn;
	public event EventPause pauseOff;
	private GameManager gm;
	public EventResume eventResume;
	void Awake(){
		gm=GetComponent<GameManager>();
		//eventResume=GameObject.FindGameObjectWithTag("pause").GetComponent<Transform>().GetChild(1).GetComponent<EventResume>();
		print("event resume "+eventResume);

	}
	void Start () {
		eventResume.onResume+=ResumeGame;
	//	replay.activateReplay+=OnReplay;

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.K)){
			print("tecla reset gane");
			GameManager.aterrizajes=GameManager.targetGame;
			gm.Conditions();
		
		}
		if(Input.GetKeyDown(KeyCode.L)){
			GameManager.lifesGame=0;
			gm.Conditions();
		}
		if(Input.GetKeyDown(KeyCode.Escape)){

			print("pasu game");

			if(!pause.activeSelf){
			Time.timeScale=0.0f;
			pause.SetActive(true);
				if(MyParams.soundActive){
				pauseOff();//para sonido
				}
			}else{
			print("despause");
			pause.SetActive(false);
			Time.timeScale=1.0f;
				if(MyParams.soundActive){
				PauseOn();
				}

			}
		}
	}
	public void ResumeGame(){
		Time.timeScale=1.0f;
		if(pause.activeSelf){
		pause.SetActive(false);
		}
		if(MyParams.soundActive){
			PauseOn();
		}
	}



}
