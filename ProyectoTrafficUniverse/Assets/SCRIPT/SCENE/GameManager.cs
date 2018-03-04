﻿using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	public static int aterrizajes=0;
	public static int targetGame;
	public static int lifesGame;
	public static int initialLifes;
	public static int currentLevel;
	private bool gameOver=false;
	public int lifes;
	public static int aviones=0;
	public int targetPlanes;
	public GameObject guiLoose;
	public GameObject guiWin;
	private string sceneName;
	//public static int idNumber=0;
	public delegate void FinalState();
	public event FinalState onFinalWin;
	public event FinalState onFinalLoose;

	void Awake () {
		//Scene scene=SceneManager.GetActiveScene();
		//sceneName=scene.name;

	//	int numScene=SceneUtility.GetBuildIndexByScenePath(sceneName);
//		print("escena numero "+numScene);
//		if(numScene==3){
//			DataDontDestroy.initialVidas=lifes;
//			DataDontDestroy.myLife=lifes;
//			print("escena inicial vidas "+DataDontDestroy.myLife);
		//		}

		print("current difficulty "+MyParams.currentDifficulty);
		switch(MyParams.currentDifficulty){
		case "easy":
			print("setiando easy");
			lifes=3;
			targetPlanes=10;
			break;

		case "normal":
			print("setiando normal");
			lifes=2;
			targetPlanes=15;
			break;
		case "hard":
			print("setiando hard");
			lifes=1;
			targetPlanes=20;
			break;

		}


		//DataDontDestroy.initialVidas=lifes;//si pasa de level actualizo a la vida original
		//DataDontDestroy.myLife=lifes;
		lifesGame=lifes;
		initialLifes=lifes;
		//print("vidas desde gm "+DataDontDestroy.initialVidas);
		targetGame=targetPlanes;
		print("initial sound game manager "+MyParams.initialCycle);
	//	guiGame.transform.FindChild("Target").transform.FindChild("NumTarget").GetComponent<SetTarget>().setTarget=targetPlanes;//seteo aviones q tiene q aterrizar
	
		
	}
	public void Events(GameObject obj){
		Detect detect=obj.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Detect>();//hijo del hijo
	//	print("evento gameObject manager");
		detect.OnContactPlane+=Conditions;
		detect.OnContactTarget+=Conditions;
	}
	public void Conditions(){
		if(GameManager.lifesGame<=0){
			print("PERDI ");
		guiLoose.SetActive(true);
		guiLoose.GetComponent<Reset>().Off();//apagamos y reseteo valores de escena
			if(MyParams.soundActive){
			onFinalLoose();
			}
	//	guiLoose.GetComponent<Reset>().Off();//apago cosas del juego
		//	gameOver=true;
		}else if(aterrizajes>=targetPlanes){
			print("victory");
			guiWin.SetActive(true);
			guiWin.GetComponent<Reset>().Off();//apagamos y reseteo valores de escena
			print("level limpio");
			if(MyParams.soundActive){
			onFinalWin();
			}
			currentLevel++;
			PlayerPrefs.SetInt("current_level",currentLevel);
			print("level pass "+currentLevel);
			PlayerPrefs.SetInt("charge",1);
		//guiWin.GetComponent<Reset>().Off();//apago cosas
	

		}

	}






		
}
