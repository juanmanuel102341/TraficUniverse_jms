
using UnityEngine;

public class SoundMenu : MonoBehaviour {


	private AudioSource audioSource;

	void Awake () {
		audioSource=GetComponent<AudioSource>();
		audioSource.loop=true;
		Play();
	}
	
	public void Play(){
		audioSource.Play();
	}
	public void Stop(){
		audioSource.Stop();
	}

}
