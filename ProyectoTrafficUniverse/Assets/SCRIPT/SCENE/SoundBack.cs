
using UnityEngine;

public class SoundBack : MonoBehaviour {

	private AudioSource myAudio;
	public Pause pause;
	public EventResume eventResume;
	void Awake () {
		myAudio=GetComponent<AudioSource>();
		myAudio.playOnAwake=true;

//		print("pause "+pause);
	
//		print("event resume "+eventResume);
	}
	void Start(){
		pause.pauseOff+=StopMe;
		pause.PauseOn+=PlayMe;
		eventResume.onResume+=PlayMe;
	
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
