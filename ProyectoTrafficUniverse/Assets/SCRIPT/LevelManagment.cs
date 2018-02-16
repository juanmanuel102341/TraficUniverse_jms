using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManagment : MonoBehaviour {
	
	public GameObject[] aButtons;
	private List<string> ListScenes=new List<string>();
	private int levelPass;
	//private string currentLevel;

	void Awake () {
	//	PlayerPrefs.DeleteAll();
	//	print("lebg buttons "+aButtons.Length);
	//	print("first "+aButtons[0].name);

		int n=PlayerPrefs.GetInt("charge");	
		if(n==0){
			print("primera vesz");
			//primera vez
			PlayerPrefs.DeleteAll();
		}
	//	print("charging "+charging);
		levelPass=PlayerPrefs.GetInt("current_level",1);

		//PlayerPrefs.SetInt("charge",1);
		//levelPass=6;
	//	levelPass=1;
	//	print("level pass awake "+levelPass);


	}


	void Start(){
		print("current level start "+levelPass);
		for(int i=0;i<levelPass;i++){
			aButtons[i].GetComponent<EnabledLevel>().ApplyLevel();
	}

	
	}



	}
	
	
	




