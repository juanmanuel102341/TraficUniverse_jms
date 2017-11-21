using UnityEngine;
using UnityEngine.UI;
public class Gui : MonoBehaviour {
	
	public static int myLife;
	public GameObject [] lifes=new GameObject[3];
	void Awake () {
		

		//DontDestroyOnLoad(gameObject);
	}
//	void Start(){
//		
//
//		print("game lifes "+GameManager.lifesGame);
//
//	}

	public void SwichLifesOn(int n){
		for(int i=0;i<n;i++){
			lifes[i].SetActive(true);
		}	
	}
	public void SwichLifesOff(int n){
	//	print("saco vida");
		switch(n){

		case 1:
			if(lifes[0].activeSelf)
			lifes[0].SetActive(false);
			break;
		case 2:
			if(lifes[1].activeSelf)
			lifes[1].SetActive(false);
			break;
		case 3:
			if(lifes[2].activeSelf)
			lifes[2].SetActive(false);
			break;
		}

	}


}
