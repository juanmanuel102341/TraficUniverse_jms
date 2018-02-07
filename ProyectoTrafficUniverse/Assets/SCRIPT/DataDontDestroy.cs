
using UnityEngine;

public class DataDontDestroy : MonoBehaviour {
	public static int myLife;
	public static int initialVidas;
	public static int currentLevelPass=1;
	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
	}

}
