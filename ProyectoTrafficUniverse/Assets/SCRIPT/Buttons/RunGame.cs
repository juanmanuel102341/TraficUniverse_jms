
using UnityEngine;
using UnityEngine.SceneManagement;
public class RunGame : MonoBehaviour {

	//private DataLevel obj;
	//public GameObject objNext;
//	public delegate void NextLevelApply();
//	public event NextLevelApply ApplyNext;
	private int builIndex=0;
	private  
	void Awake(){
		Scene scene=SceneManager.GetActiveScene();

		print("name scene "+scene.name);
		
		builIndex=SceneUtility.GetBuildIndexByScenePath(scene.name);
		print("build index "+builIndex);
		builIndex++;

	}
		public void LoadEscene(){
//		print("scene "+SceneManager.)

		//	objNext.SetActive(false);
		//DataLevel.numLevel++;

		SceneManager.LoadScene(builIndex);
		//DataLevel.numLevel++;
		//		SceneManager.LoadScene(DataLevel.numLevel);
		//		DataLevel.numLevel++;
	}
}
