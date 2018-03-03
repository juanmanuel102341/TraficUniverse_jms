
using UnityEngine;

public class SoundButton : MonoBehaviour {

	private AudioSource audioButton;
	private bool cancel=false;
	void Awake () {
		audioButton=GetComponent<AudioSource>();
		audioButton.playOnAwake=false;
	}


	public void PlayButtonSound(){
		if(MyParams.soundActive){
		audioButton.Play();	
		print("sonido efecto activo");
		}
		print("boton bloqueado efecto sonido");
	}
	public bool setCancel{
		set{
			cancel=value;
		}
	}

}
