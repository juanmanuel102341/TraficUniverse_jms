
using UnityEngine;

public class MyParams : MonoBehaviour {

	public static bool soundActive;
	public static bool initialCycle=false;
	public static string currentDifficulty;
	public SoundMenu soundMenu;

	void Awake(){
		Screen.SetResolution(1024,768,true);
		if(!initialCycle){
			soundActive=true;
			currentDifficulty="normal";
		}

		if(!soundActive){
			soundMenu.Stop();
		}
	}
	void Start () {
		//DontDestroyOnLoad(gameObject);
		print("initial sound cycle my param"+initialCycle);
		print("MyPath param "+soundActive);

	}

}
