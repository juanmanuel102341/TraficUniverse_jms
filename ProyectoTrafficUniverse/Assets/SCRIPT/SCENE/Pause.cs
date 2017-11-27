
using UnityEngine;

public class Pause : MonoBehaviour {
	public GameObject pause;
	public Reset reset;
	public Replay replay;
	public delegate void EventPause();
	public static event EventPause PauseOn;
	public static event EventPause pauseOff;
	private GameManager gm;
	void Awake(){
		gm=GetComponent<GameManager>();
	}
	void Start () {
		EventResume.onResume+=ResumeGame;
		replay.activateReplay+=OnReplay;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.K)){
			print("tecla reset gane");
			GameManager.aterrizajes=GameManager.targetGame;
			gm.Conditions();
		}
		if(Input.GetKeyDown(KeyCode.Escape)){

			print("pasu game");

			if(!pause.activeSelf){
			Time.timeScale=0.0f;
			pause.SetActive(true);
			pauseOff();//para sonido
			}else{
			print("despause");
			pause.SetActive(false);
			Time.timeScale=1.0f;
				PauseOn();

			}
		}
	}
	private void ResumeGame(){
		Time.timeScale=1.0f;
		pause.SetActive(false);
		PauseOn();
	}
	private void OnReplay(){
	
		reset.enabled=true;
		reset.Off();
		reset.On();
		Time.timeScale=1.0f;
		//PauseOn();//ya lo hace reset
	}


}
