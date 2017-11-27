
using UnityEngine;

public class SoundBack : MonoBehaviour {

	private AudioSource myAudio;

	void Awake () {
		myAudio=GetComponent<AudioSource>();
		myAudio.playOnAwake=true;
		}
	void Start(){
		Pause.pauseOff+=StopMe;
		Pause.PauseOn+=PlayMe;
		EventResume.onResume+=PlayMe;
	
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
