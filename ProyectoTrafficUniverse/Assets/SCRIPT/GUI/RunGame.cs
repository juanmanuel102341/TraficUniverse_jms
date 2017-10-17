
using UnityEngine;
using UnityEngine.SceneManagement;
public class RunGame : MonoBehaviour {
	private int num=0;
	//private DataLevel obj;
	public GameObject objNext;

	void Awake(){
		num++;
	
		//obj=GameObject.FindGameObjectWithTag("next").GetComponent<DataLevel>();
	
		//print(UnityEngine.SceneManagement.SceneManager.SetActiveScene);
		//print(UnityEngine.SceneManagement.SceneManager.sceneCount);
		print(SceneManager.sceneCount);
	//	print(SceneManager.sceneCountInBuildSettings);

	}
		public void LoadEscene(){
		objNext.SetActive(false);

		SceneManager.LoadScene(DataLevel.numLevel);
		DataLevel.numLevel++;
		//		SceneManager.LoadScene(DataLevel.numLevel);
		//		DataLevel.numLevel++;
	}
}
