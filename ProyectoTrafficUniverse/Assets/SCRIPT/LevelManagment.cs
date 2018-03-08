using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManagment : MonoBehaviour {
	
	public GameObject[] aButtons;
	private List<string> ListScenes=new List<string>();
	private int levelPass;
	private AudioSource audioMenu;
	//private string currentLevel;

	void Awake () {
//PlayerPrefs.DeleteAll();
	//	print("lebg buttons "+aButtons.Length);
	//	print("first "+aButtons[0].name);
		audioMenu=GetComponent<AudioSource>();
		if(MyParams.soundActive){

		audioMenu.Play();
		audioMenu.loop=true;
		audioMenu.volume=0.75f;
		}else{
		audioMenu.Stop();

		}
		int n=PlayerPrefs.GetInt("charge");	
		if(n==0){
			print("primera vesz");
			//primera vez
			PlayerPrefs.DeleteAll();
		}
	//	print("charging "+charging);
		levelPass=PlayerPrefs.GetInt("current_level",1);
		GameManager.currentLevel=levelPass;
		//PlayerPrefs.SetInt("charge",1);
	//	levelPass=aButtons.Length;
	//	levelPass=1;
		print("level pass awake "+levelPass);

		MyParams.initialCycle=true;//para data del game manager
		print("setiando initial sound desde level manag "+MyParams.initialCycle);
	}


	void Start(){
	//	print("current level start "+levelPass);
		for(int i=0;i<levelPass;i++){
			aButtons[i].GetComponent<EnabledLevel>().ApplyLevel();
	}
			
	}





	}
	
	
	




