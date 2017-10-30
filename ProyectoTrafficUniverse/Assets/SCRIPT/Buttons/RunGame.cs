
using UnityEngine;
using UnityEngine.SceneManagement;
public class RunGame : MonoBehaviour {
	private int num=0;
	//private DataLevel obj;
	public GameObject objNext;
	public delegate void NextLevelApply();
	public event NextLevelApply ApplyNext;
	//public DataLevel data;
	void Awake(){
		num++;
		print(SceneManager.sceneCount);
	//	print(SceneManager.sceneCountInBuildSettings);

	}
		public void LoadEscene(){
//		print("scene "+SceneManager.)
		if(SceneManager.sceneCount!=1)
		{print("next ");
			ApplyNext();
		}

			objNext.SetActive(false);
		//DataLevel.numLevel++;

		SceneManager.LoadScene(SceneManager.sceneCount);
		//DataLevel.numLevel++;
		//		SceneManager.LoadScene(DataLevel.numLevel);
		//		DataLevel.numLevel++;
	}
}
