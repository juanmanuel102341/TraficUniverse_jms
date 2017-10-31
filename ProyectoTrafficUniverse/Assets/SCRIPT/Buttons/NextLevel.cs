﻿//using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class NextLevel : MonoBehaviour {
	public delegate void ActivateReset();
	public event ActivateReset activateReset;
	private int indexValue=0;
	void Awake(){
		Scene scene=SceneManager.GetActiveScene();

		print("name scene "+scene.name);

		indexValue=SceneUtility.GetBuildIndexByScenePath(scene.name);
		indexValue++;
		print("build index "+indexValue);
		if(indexValue>=SceneManager.sceneCountInBuildSettings){
			indexValue=0;
			print("reset all");
		}
	}
	public void ApplingNext(){
		activateReset();
		SceneManager.LoadScene(indexValue);

	}

}
