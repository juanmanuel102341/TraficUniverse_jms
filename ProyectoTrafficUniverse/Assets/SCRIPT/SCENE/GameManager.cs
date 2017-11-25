using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	public static int aterrizajes=0;
	public static int lifesGame=0;
	public static int targetGame;
	public int lifes;
	public static int aviones=0;
	public int targetPlanes;
	public GameObject guiLoose;
	public GameObject guiWin;
	private int initialVidas;
	void Awake () {
		Scene scene=SceneManager.GetActiveScene();
		int numScene=SceneUtility.GetBuildIndexByScenePath(scene.name);
		print("escena numero "+numScene);
		if(numScene==2){

			initialVidas=lifes;
			lifesGame=initialVidas;
		}else{
			
		}
	
	//	guiLife.SwichLifesOn(lifes);
		targetGame=targetPlanes;

	//	guiGame.transform.FindChild("Target").transform.FindChild("NumTarget").GetComponent<SetTarget>().setTarget=targetPlanes;//seteo aviones q tiene q aterrizar
	
		
	}
	public void Events(GameObject obj){
		Detect detect=obj.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Detect>();//hijo del hijo
		print("evento gameObject manager");
		detect.OnContactPlane+=Conditions;
	}
	void Start(){
		
	}


	private void Conditions(){
		if(lifesGame<=0){
		guiLoose.SetActive(true);

		}else if(aterrizajes>=targetPlanes){
//			print("victory");
		guiWin.SetActive(true);

	

		}

		if(Input.GetKeyDown(KeyCode.K)){
			aterrizajes=targetPlanes;
		}


	}





		
}
