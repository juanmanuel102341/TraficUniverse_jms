using UnityEngine;
public class GameManager : MonoBehaviour {
	public static int aterrizajes=0;
	public int vidas;
	public static int aviones=0;
	public int targetPlanes;
	public GameObject guiLoose;
	public GameObject guiWin;
	public GameObject[] aPlanets=new GameObject[3];
	private SpawnManager spawnManager;
	private int initialVidas;
	public GameObject guiGame;
	public GameObject buttonWin;
	public GameObject buttonLoose;
	void Awake () {
		initialVidas=vidas;
		guiGame.transform.FindChild("Vidas").transform.FindChild("NumVidas").GetComponent<Gui>().setVidas=vidas;//actualizo vidas;
		guiGame.transform.FindChild("Target").transform.FindChild("NumTarget").GetComponent<SetTarget>().setTarget=targetPlanes;//seteo aviones q tiene q aterrizar
		spawnManager=GetComponent<SpawnManager>();
	}
	void Start(){
		Replay.activateReplay+=OnReplay;	
	}
	
	void Update () {
		if(aviones==2){
			print("puf aviones muertos");
			vidas--;
			guiGame.transform.FindChild("Vidas").transform.FindChild("NumVidas").GetComponent<Gui>().setVidas=vidas;//actualizo vidas
			aviones=0;
		}
		Conditions();
	}
	private void Conditions(){
		if(vidas<=0){
			print("loose");

			Reset();
			buttonLoose.SetActive(true);
			guiLoose.SetActive(true);
		
		}else if(aterrizajes>=targetPlanes){
			print("victory");
			Reset();
			buttonWin.SetActive(true);
			guiWin.SetActive(true);
		}
	}
	private void Reset(){
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
	private void OnReplay(){
		print("replay new");
		if(buttonLoose.activeSelf){
			print("button loose desacctiva");
			buttonLoose.SetActive(false);
			guiLoose.SetActive(false);
		}else{
		print("button win deactive");
			buttonWin.SetActive(false);
			guiWin.SetActive(false);
		}
		for(int i=0;i<aPlanets.Length;i++){
			aPlanets[i].SetActive(true);//prendo planeta
		}
		spawnManager.enabled=true;;//prendo generacion de naves
		aterrizajes=0;//reseteo aterrizajes para no volver a ganar
		vidas=initialVidas;
		guiGame.transform.FindChild("Vidas").transform.FindChild("NumVidas").GetComponent<Gui>().setVidas=vidas;//reseteo vida mediante propiedad
		guiGame.SetActive(true);//prendo gui del juego
	}
		
}
