using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBase : MonoBehaviour {

	public SoundMenu soundBack;
	public SoundButton soundButton;
	void Start () {
		
	}
	
	public void ReceiptState(string name){
		if(name=="On"){

			print("sonido prendido");
			soundBack.Play();
			//soundButton.setCancel=false;
			MyParams.soundActive=true;
		}else if(name=="Off"){
		print("sonido apagado");
			soundBack.Stop();
			//soundButton.setCancel=true;
			MyParams.soundActive=false;

		}else{
			print("danger state no definido");

		
		}
	}
}
