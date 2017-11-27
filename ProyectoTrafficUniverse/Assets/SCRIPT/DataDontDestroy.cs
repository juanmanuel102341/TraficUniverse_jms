
using UnityEngine;

public class DataDontDestroy : MonoBehaviour {
	public static int myLife;
	public static int initialVidas;
	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
	}

}
