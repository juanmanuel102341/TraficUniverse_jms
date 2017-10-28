
using UnityEngine;
using UnityEngine.SceneManagement;
public class RunGame : MonoBehaviour {
	private int num=0;
	//private DataLevel obj;
	public GameObject objNext;
	public delegate void NextLevelApply();
	public event NextLevelApply ApplyNext;
	void Awake(){
		num++;
		print(SceneManager.sceneCount);
	//	print(SceneManager.sceneCountInBuildSettings);

	}
		public void LoadEscene(){
		ApplyNext();
		objNext.SetActive(false);
		DataLevel.numLevel++;

		SceneManager.LoadScene(DataLevel.numLevel);
		//DataLevel.numLevel++;
		//		SceneManager.LoadScene(DataLevel.numLevel);
		//		DataLevel.numLevel++;
	}
}
