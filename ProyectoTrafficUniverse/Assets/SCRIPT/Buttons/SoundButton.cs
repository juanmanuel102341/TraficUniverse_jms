
using UnityEngine;

public class SoundButton : MonoBehaviour {

	private AudioSource audioButton;
	void Awake () {
		audioButton=GetComponent<AudioSource>();
		audioButton.playOnAwake=false;
	}


	public void PlayButtonSound(){
		audioButton.Play();	
	}

}
