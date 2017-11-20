
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void OnMenu(){
		SceneManager.LoadScene(0);

	}
}
