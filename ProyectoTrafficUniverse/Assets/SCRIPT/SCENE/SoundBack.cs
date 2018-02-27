﻿
using UnityEngine;

public class SoundBack : MonoBehaviour {
	
	public AudioClip loose;
	public AudioClip win;
	public AudioSource inGameSound;
	public AudioSource finalStateSound;
	private float timeLast;
	public Pause pause;
	public EventResume eventResume;
	private GameManager gameManager;
	void Awake () {
		inGameSound=GetComponent<AudioSource>();
		inGameSound.Play();
		gameManager=GameObject.FindGameObjectWithTag("gameManager_tag").GetComponent<GameManager>();
		inGameSound.volume=0.25f;
		inGameSound.loop=true;
		finalStateSound.loop=true;
		finalStateSound.playOnAwake=false;
		finalStateSound.volume=0.25f;
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
		if(inGameSound!=null){
			//timeLast=inGameSound.time;
			print("ttiempo musica "+timeLast);
			inGameSound.Stop();
		}
	}
	public void PlayMe(){
		if(inGameSound!=null){
		//	inGameSound.PlayScheduled(timeLast);
			inGameSound.Play();
			//print("play musica "+timeLast  );
		}
	}

	private void onLoose(){
		StopMe();
		finalStateSound.clip=loose;	
		finalStateSound.Play();

	}
	private void onWin(){
		StopMe();
		finalStateSound.clip=win;
		finalStateSound.Play();
	
	}
	public void onInGameSound(){
		finalStateSound.Stop();
		inGameSound.Play();
	}
}
