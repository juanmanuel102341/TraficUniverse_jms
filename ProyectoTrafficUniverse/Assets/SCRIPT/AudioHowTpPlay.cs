using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHowTpPlay : MonoBehaviour {
	private AudioSource myAudio;
	// Use this for initialization
	void Awake () {

		if(MyParams.soundActive){
		myAudio=GetComponent<AudioSource>();
			myAudio.Play();
			myAudio.loop=true;
			myAudio.volume=0.8f;
		
		}
	}

}
