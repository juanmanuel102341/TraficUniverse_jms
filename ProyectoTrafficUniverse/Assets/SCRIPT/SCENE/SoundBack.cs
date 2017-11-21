
using UnityEngine;

public class SoundBack : MonoBehaviour {

	private AudioSource myAudio;
	void Awake () {
		myAudio=GetComponent<AudioSource>();
		myAudio.playOnAwake=true;
		}
	void Start(){
		Pause.onPauseActive+=StopMe;
		Pause.offPause+=PlayMe;
		EventResume.onResume+=PlayMe;
		GameManager.onRestartOnPause+=PlayMe;
		GameManager.OffFinalEscene+=StopMe;
	}
	public void StopMe(){
		if(myAudio!=null)
		myAudio.Stop();
	}
	public void PlayMe(){
		if(myAudio!=null)
		myAudio.Play();
	}

	

}
