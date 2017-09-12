
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static int aterrizajes=0;
	public static  int vidas=3;
	public static int aviones=0;
	public GameObject guiLoose;
	public GameObject guiWin;
	public int targetPlanes;
	private int initialVidas;

	void Awake () {
		initialVidas=vidas;
	}
	

	void Update () {
		if(aviones==2){
			vidas--;
			aviones=0;
		}
		Conditions();
	}
	private void Conditions(){
		if(vidas<=0){
			print("loose");
		}
		if(aterrizajes>=targetPlanes){
			print("victory");
		}
	}
}
