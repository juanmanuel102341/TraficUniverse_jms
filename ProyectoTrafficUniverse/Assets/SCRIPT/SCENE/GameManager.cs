using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	public static int aterrizajes=0;
//	public static int lifesGame=0;
	public static int targetGame;
	public int lifes;
	public static int aviones=0;
	public int targetPlanes;
	public GameObject guiLoose;
	public GameObject guiWin;
	public GameObject[] aPlanets;
	private SpawnManager spawnManager;
	private int initialVidas;
	public GameObject guiGame;
	public NextLevel nextLevel;
	public Replay replay;
	private GameObject [] aAsteroides;
	public static bool myClickId=false;
	private Gui guiLife;
	public delegate void SetTargetGui();
	public static event SetTargetGui ResetTargetGui;
	public delegate void RestartOnPause();
	public static event RestartOnPause onRestartOnPause;
	public static event RestartOnPause OffFinalEscene;
	private Pause pause;
	public GameObject fastTime;

	void Awake () {
		pause=GetComponent<Pause>();
		guiLife=guiGame.GetComponent<Transform>().GetChild(1).gameObject.GetComponent<Gui>();
		print("nombre objeto vida "+guiLife.gameObject.tag);
		aAsteroides=GameObject.FindGameObjectsWithTag("asteroide");
		Scene scene=SceneManager.GetActiveScene();
		int numScene=SceneUtility.GetBuildIndexByScenePath(scene.name);
		print("escena numero "+numScene);
		if(numScene==2){
			
		initialVidas=lifes;
			Gui.myLife=lifes;
			print("setiand vida initial "+lifes);
	//		guiLife.SwichLifesOn(lifes);
		}else{
			
			lifes=Gui.myLife;
			initialVidas=Gui.myLife;
			ResettingLifes();
			aterrizajes=0;
		}
	//	guiLife.SwichLifesOn(lifes);
		if(!guiLife.gameObject.activeSelf){
			guiLife.gameObject.SetActive(true);
		}
	//	guiLife.SwichLifesOn(lifes);
		targetGame=targetPlanes;

	//	guiGame.transform.FindChild("Target").transform.FindChild("NumTarget").GetComponent<SetTarget>().setTarget=targetPlanes;//seteo aviones q tiene q aterrizar
		spawnManager=GetComponent<SpawnManager>();
		
	}
	void Start(){
		EventsGame();
	}
//	void OnDestroy(){
//		replay.activateReplay-=OnReplay;
//	
//	}
		

	void EventsGame(){	

		replay.activateReplay+=OnReplay;	
		nextLevel.activateReset+=SettingOffGuiFinal;
	
		nextLevel.activateReset+=ResetValuesScene;
	}
	
	void Update () {
		if(aviones==2){
			print("puf aviones muertos");
			guiLife.SwichLifesOff(lifes);
			lifes--;
			Gui.myLife--;
//			guiGame.transform.FindChild("Vidas").transform.FindChild("NumVidas").GetComponent<Gui>().setVidas=lifes;//actualizo vidas
			aviones=0;
		}
		Conditions();
	}

	private void Conditions(){
		if(lifes<=0){
		//	print("loose");
			OffFinalEscene();//apago musica principal
			Reset();

			guiLoose.SetActive(true);

			replay=guiLoose.transform.GetChild(2).GetComponent<Replay>();
			replay.activateReplay+=OnReplay;	
			print("replay "+replay.gameObject.name);
		//	Debug.Log("replay "+replay.tag);

		}else if(aterrizajes>=targetPlanes){
//			print("victory");
			OffFinalEscene();//apago musica principal
			Reset();

			guiWin.SetActive(true);
			replay=guiWin.transform.GetChild(2).GetComponent<Replay>();
			replay.activateReplay+=OnReplay;	
			print("replay "+replay.gameObject.name);
		//para q no me tire error porque el replay del principio hace referencia al replay de pausa

		}
		if(Input.GetKeyDown(KeyCode.K)){
			aterrizajes=targetPlanes;
		}

	}
	private void Reset(){
	//	print("reset game ");

		if(aAsteroides!=null){
//			print("borrando asteroides "+aAsteroides.Length );
			for(int i=0;i<aAsteroides.Length;i++){
				aAsteroides[i].SetActive(false);
			}
			//print("borrando asteroides despues"+aAsteroides.Length );
		}
		for(int i=0;i<spawnManager.getListPlanes.Count;i++){
			GameObject aux=spawnManager.getListPlanes[i];
			spawnManager.GetOutObjectFromList(aux);
			aux.GetComponent<Delete>().DeleteMe();//destruyo nave y nodos
		
		}
		guiGame.SetActive(false);//apago gui
		for(int i=0;i<aPlanets.Length;i++){
			aPlanets[i].SetActive(false);//apago planeta	
		}

		spawnManager.enabled=false;;//apago generacion de naves
		fastTime.SetActive(false);//apago timer del juego

	}
	private void OnReplay(string id){

		//print("my id gm "+id);
		if(id=="pauseReplay"){
			//****************************pause*************************
			print("replay pause gm");
			onRestartOnPause();
			Reset();
			GameObject.FindGameObjectWithTag("pause").SetActive(false);
			Time.timeScale=1;
			//para q vuelva la musica
		}else{//**************************momento win/loose********************
			SettingOffGuiFinal();
		}

		for(int i=0;i<aPlanets.Length;i++){
			aPlanets[i].SetActive(true);//prendo planeta
		}
		for(int i=0;i<aAsteroides.Length;i++){
			aAsteroides[i].SetActive(true);//prendo asteroides
		}

		ResetValuesScene();
	}
	private void SettingOffGuiFinal(){
	//	print("win loose gm");
		if(guiLoose.activeSelf){
		//	print("button loose desacctiva");
			guiLoose.SetActive(false);

		}else{
		//	print("button win deactive");
			guiWin.SetActive(false);
		}
	}
	private void ResetValuesScene(){
		spawnManager.enabled=true;//prendo generacion de naves

		aterrizajes=0;//reseteo aterrizajes para no volver a ganar
		ResetTargetGui();
		lifes=initialVidas;
		guiLife.SwichLifesOn(initialVidas);
		onRestartOnPause();//para q vuelva  sonar musica
		//OnResetLife();
		//	guiGame.transform.FindChild("Vidas").transform.FindChild("NumVidas").GetComponent<Gui>().setVidas=lifes;//reseteo vida mediante propiedad
		guiGame.SetActive(true);//prendo gui del juego
		fastTime.SetActive(true);
//		fastTime.GetComponent<FastTime>().OnResetMe();
//		EventsGame();
	//	OnDestroy();

	}
	private void ResettingLifes(){
		print("vida de antes "+initialVidas);
		int n=3-lifes;//cuanto le tengo q sacar d vidas
		int aux=3;
		for(int i=0;i<n;i++){
			print("index life "+i);
			guiLife.SwichLifesOff(aux);
			aux--;
		}	
	}

		
}
