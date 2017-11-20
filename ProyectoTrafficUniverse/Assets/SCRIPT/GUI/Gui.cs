using UnityEngine;
using UnityEngine.UI;
public class Gui : MonoBehaviour {
	

	public GameObject [] lifes=new GameObject[3];
	private int initialLife;
	void Awake () {
		

		for(int i=0;i<3;i++){
			SwichLifesOff(i);//las apago asi estan a tono con la data del game manager, claro no puede tener mas d 3 vidas
		}

	}
	void Start(){
		
		GameManager.OnGuiOut+=SwichLifesOff;
		GameManager.OnResetLife+=SwichLifesOn;
		print("game lifes "+GameManager.lifesGame);
		for(int i=0;i<GameManager.lifesGame;i++)
			SwichLifesOn(i);


	}

	private void SwichLifesOn(int n){

		switch(n){

		case 1:
			lifes[0].SetActive(true);
			break;
		case 2:
			lifes[1].SetActive(true);
			break;
		case 3:
			lifes[2].SetActive(true);
			break;
		}

	}
	private void SwichLifesOff(int n){
		print("saco vida");
		switch(n){

		case 1:
			lifes[0].SetActive(false);
			break;
		case 2:
			lifes[1].SetActive(false);
			break;
		case 3:
			lifes[2].SetActive(false);
			break;
		}

	}


}
