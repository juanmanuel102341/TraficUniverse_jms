using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DetectSoundState : MonoBehaviour {
	public Sprite imageOff;

	public SoundBase soundBase;
	private Sprite spriteOn;
	private Image image;
	private bool onState=false;
	public DetectSoundState other;

	void Awake () {
		image=GetComponent<Image>();
		spriteOn=GetComponent<Button>().spriteState.pressedSprite;

		if(gameObject.name=="On"){
			onState=true;
		}
		print("sprite on "+spriteOn);
	}
	
	public void Click(){
		print("click "+gameObject.name);
		soundBase.ReceiptState(gameObject.name);
		SetSpriteOn();
		if(other.getOnState){
			other.SetSpriteOff();//si el otro esta prendido lo apago
		}
	
	}
	private void SetSpriteOn(){
		image.sprite=spriteOn;
		onState=true;
	}
	private void SetSpriteOff(){
		image.sprite=imageOff;
		onState=false;
	}
	public bool getOnState{
		get{
			return onState;
		}
	}
}
