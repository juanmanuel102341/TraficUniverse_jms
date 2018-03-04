using UnityEngine;
using UnityEngine.UI;
public class Gui : MonoBehaviour {
	

	public GameObject [] lifes=new GameObject[3];
	void Awake () {
		
		for(int i=0;i<lifes.Length;i++){
			lifes[i].SetActive(false);
		}
		//DontDestroyOnLoad(gameObject);
	}
	void Start(){
		
		//SwichLifesOff();
		SwichLifesOn();


	}
	public void Events(GameObject obj){
		Detect detect=obj.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Detect>();//hijo del hijo
		detect.OnContactPlane+=SwichLifesOff;
	}

	public void SwichLifesOn(){
		for(int i=0;i<GameManager.lifesGame;i++){
			lifes[i].SetActive(true);
		}	
	}
	public void SwichLifesOff(){
	//	print("saco vida");
		switch(GameManager.lifesGame){

		case 1:
			if(lifes[0].activeSelf)
			lifes[0].SetActive(false);
			break;
		case 2:
			if(lifes[1].activeSelf)
			lifes[1].SetActive(false);
			break;
		case 3:
			print("1er contacto "+GameManager.lifesGame);
			if(lifes[2].activeSelf)
			lifes[2].SetActive(false);
			break;
		}

	
		GameManager.lifesGame--;
		GameManager.aviones=0;
		print("despues contacti"+GameManager.lifesGame);
	}


}
