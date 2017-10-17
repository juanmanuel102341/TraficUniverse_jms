using UnityEngine;

public class DataLevel : MonoBehaviour {

	public static int numLevel=0;
	void Awake () {
		GameObject.DontDestroyOnLoad(this.gameObject);
		numLevel++;
	}

}
