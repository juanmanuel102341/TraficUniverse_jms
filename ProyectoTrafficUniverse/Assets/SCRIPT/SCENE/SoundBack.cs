
using UnityEngine;

public class SoundBack : MonoBehaviour {
	
	public AudioClip loose;
	public AudioClip win;
	private AudioSource myAudio;
	public AudioSource final;

	public Pause pause;
	public EventResume eventResume;
	private GameManager gameManager;
	void Awake () {
		myAudio=GetComponent<AudioSource>();
		myAudio.Play();
		gameManager=GameObject.FindGameObjectWithTag("gameManager_tag").GetComponent<GameManager>();
		myAudio.volume=0.25f;
		myAudio.loop=true;
		final.loop=true;
		final.playOnAwake=false;
		final.volume=0.25f;
		//	myAudio.priority=200;

//		print("pause "+pause);
	
//		print("event resume "+eventResume);
	}
	void Start(){
		pause.pauseOff+=StopMe;
		pause.PauseOn+=PlayMe;
		eventResume.onResume+=PlayMe;
		gameManager.onFinalLoose+=onLoose;
		gameManager.onFinalWin+=onWin;
	}
	public void StopMe(){
		if(myAudio!=null)
		myAudio.Stop();
	}
	public void PlayMe(){
		if(myAudio!=null)
		myAudio.Play();
	}

	private void onLoose(){
		final.clip=loose;	
		final.Play();
	}
	private void onWin(){
		final.clip=win;
		final.Play();
	
	}
}
