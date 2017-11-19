
using UnityEngine;

public class SoundBack : MonoBehaviour {

	private AudioSource myAudio;
	void Awake () {
		myAudio=GetComponent<AudioSource>();
		myAudio.playOnAwake=true;
		}
	

}
