using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	public static int aterrizajes=0;
	public static int targetGame;
	private bool gameOver=false;
	public int lifes;
	public static int aviones=0;
	public int targetPlanes;
	public GameObject guiLoose;
	public GameObject guiWin;

	//public static int idNumber=0;
	void Awake () {
		Scene scene=SceneManager.GetActiveScene();
		int numScene=SceneUtility.GetBuildIndexByScenePath(scene.name);
//		print("escena numero "+numScene);
		if(numScene==2){

			DataDontDestroy.initialVidas=lifes;
		
			DataDontDestroy.myLife=lifes;
//			print("escena inicial vidas "+DataDontDestroy.myLife);
		}else{
	//		lifes=DataDontDestroy.myLife;
	//		print("esccena no inicial vidas "+DataDontDestroy.myLife);

		}
	
	//
		targetGame=targetPlanes;

	//	guiGame.transform.FindChild("Target").transform.FindChild("NumTarget").GetComponent<SetTarget>().setTarget=targetPlanes;//seteo aviones q tiene q aterrizar
	
		
	}
	public void Events(GameObject obj){
		Detect detect=obj.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Detect>();//hijo del hijo
	//	print("evento gameObject manager");
		detect.OnContactPlane+=Conditions;
		detect.OnContactTarget+=Conditions;
	}
	public void Conditions(){
		if(DataDontDestroy.myLife<=0){
			print("PERDI ");
		guiLoose.SetActive(true);
	//	guiLoose.GetComponent<Reset>().Off();//apago cosas del juego
		//	gameOver=true;
		}else if(aterrizajes>=targetPlanes){
			print("victory");
		guiWin.SetActive(true);
		//guiWin.GetComponent<Reset>().Off();//apago cosas
	

		}

	}






		
}
