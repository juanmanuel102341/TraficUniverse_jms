using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateActive : MonoBehaviour {

	public hightLightSprite [] states;
	private SoundMenu soundMenu;
	void Awake(){
		soundMenu=GameObject.Find("Canvas").GetComponent<SoundMenu>();
		print("sound menu "+soundMenu);
	}

	void Start () {
		if(gameObject.name=="Dificulty"&&!MyParams.initialCycle){
			//primera vez default normal
			states[1].SetSpriteOn();
		}else if(gameObject.name=="Dificulty"&&MyParams.initialCycle){
			switch(MyParams.currentDifficulty){
			case "easy":
				states[0].SetSpriteOn();
				break;
			case "normal":
				states[1].SetSpriteOn();
				break;	
			case "hard":
				states[2].SetSpriteOn();
				break;
			}
		}else if(gameObject.name=="Sound"&&!MyParams.initialCycle){
			//primera vez sonido default
			states[0].SetSpriteOn();
		}else if(gameObject.name=="Sound"&&MyParams.initialCycle){
			if(MyParams.soundActive){
				states[0].SetSpriteOn();
			}else{
				states[1].SetSpriteOn();
			}

		}

		for(int i=0;i<states.Length;i++){
			states[i].onActiveState+=infoOnActivaSate;
			//print("setiando eventos");
		}
	}

	private void infoOnActivaSate(string state){
		switch(gameObject.name){

		case "Dificulty":
		print("setiando dificulty");
						switch(state){
						case "Easy":
							print("setiando easy");
							MyParams.currentDifficulty="easy";
							break;
						case "Normal": 
							print("setiando normal");
							MyParams.currentDifficulty="normal";
							break;
						case"Hard":
							print("setiando hard");
							MyParams.currentDifficulty="hard";
							break;
						 default:
							print("warning! state sin asignar!!!");
							break;
								}
						break;

		case "Sound":
		print("setiando sound");
							switch(state){
							case "On":
								print("setiando on");
						soundMenu.Play();
					MyParams.soundActive=true;
								break;
							case"Off":
								print("setiando off");
						soundMenu.Stop();
					MyParams.soundActive=false;
						break;
							default:
								print("warning! state sin asignar");
								break;
							}
			break;
		}

	}

}
