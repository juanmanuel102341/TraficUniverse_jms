using UnityEngine;
public class GameManager : MonoBehaviour {
	public static int aterrizajes=0;
	public static int lifesGame=0;
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
	public delegate void SetGuiLife(int numVidaOut);
	public delegate void SetResetLife();
	public static event SetGuiLife OnGuiOut;
	public static event SetResetLife OnResetLife;

	public delegate void SetTargetGui();
	public static event SetTargetGui ResetTargetGui;
	void Awake () {
		aAsteroides=GameObject.FindGameObjectsWithTag("asteroide");
	
		initialVidas=lifes;

		lifesGame=lifes;
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
			OnGuiOut(lifes);
			lifes--;
//			guiGame.transform.FindChild("Vidas").transform.FindChild("NumVidas").GetComponent<Gui>().setVidas=lifes;//actualizo vidas
			aviones=0;
		}
		Conditions();
	}
	private void Conditions(){
		if(lifes<=0){
			print("loose");

			Reset();

			guiLoose.SetActive(true);
			replay=guiLoose.transform.GetChild(2).GetComponent<Replay>();
			replay.activateReplay+=OnReplay;	
			Debug.Log("replay "+replay.tag);

		}else if(aterrizajes>=targetPlanes){
			print("victory");
			Reset();
		
			guiWin.SetActive(true);
		
		
		}
		if(Input.GetKeyDown(KeyCode.K)){
			aterrizajes=targetPlanes;
		}

	}
	private void Reset(){
		print("reset game ");

		if(aAsteroides!=null){
			print("borrando asteroides "+aAsteroides.Length );
			for(int i=0;i<aAsteroides.Length;i++){
				aAsteroides[i].SetActive(false);
			}
			print("borrando asteroides despues"+aAsteroides.Length );
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

	}
	private void OnReplay(string id){

		print("my id gm "+id);
		if(id=="pauseReplay"){
			//****************************pause*************************
			print("replay pause gm");
			Reset();
			GameObject.FindGameObjectWithTag("pause").SetActive(false);
			Time.timeScale=1;
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
		print("win loose gm");
		if(guiLoose.activeSelf){
			print("button loose desacctiva");
			guiLoose.SetActive(false);

		}else{
			print("button win deactive");
			guiWin.SetActive(false);
		}
	}
	private void ResetValuesScene(){
		spawnManager.enabled=true;//prendo generacion de naves

		aterrizajes=0;//reseteo aterrizajes para no volver a ganar
		ResetTargetGui();
		lifes=initialVidas;
		OnResetLife();
		//	guiGame.transform.FindChild("Vidas").transform.FindChild("NumVidas").GetComponent<Gui>().setVidas=lifes;//reseteo vida mediante propiedad
		guiGame.SetActive(true);//prendo gui del juego
//		EventsGame();
	//	OnDestroy();

	}

		
}
