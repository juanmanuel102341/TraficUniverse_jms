using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour {
	
	public Scene myScene;
	//private string scenePath;
	//public string  path;
	public int sceneBuild;
	// Use this for initialization
	//public LevelManagment lm;
	void Start () {
		
	}
	
	public void LoadedLevelIndex(){	//print("puto nombre "+scenePath);
	//	SceneManager.LoadSceneAsync(sceneBuild);
		//SceneManager.LoadScene(sceneBuild);
		//n=7;
		//print("OBJ "+gameObject.name);
		//lm.SetCurrentLevel(gameObject.name);
		SceneManager.LoadScene(sceneBuild);
	}




}


