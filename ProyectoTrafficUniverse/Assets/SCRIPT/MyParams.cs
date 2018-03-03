
using UnityEngine;

public class MyParams : MonoBehaviour {

	public static bool soundActive;
	public static bool initialSoundCycle=false;
	public SoundMenu soundMenu;

	void Awake(){
		if(!initialSoundCycle){
			soundActive=true;
		}

		if(!soundActive){
			soundMenu.Stop();
		}
	}
	void Start () {
		//DontDestroyOnLoad(gameObject);
		print("initial sound cycle my param"+initialSoundCycle);
		print("MyPath param "+soundActive);

	}

}
