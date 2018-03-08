using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {
	//se encarga de resetiar valores y dejarlos como en su nivel inicil

	public GameObject [] aPlanets;
	public PositionsAsteroids asteroids;
	public GameObject gui;
	public SpawnManager spawnManager;
	public DetectsId detetId;
	public Pause pause;
	public Replay replay;
	public GameObject guiFinal;
	public SoundBack soundBack;
	private GameManager gameManager;
	public GameObject backsGuiEscene;
	private Vector2 [] aposAsteroids;
	void Awake () {

		gameManager=spawnManager.transform.gameObject.GetComponent<GameManager>();
		print("game manaher "+gameManager);

	}
	void Start(){
		print("activando evento "+gameObject.name);
		//if(replay!=null)
		replay.activateReplay+=On;

	}
	public void Off(){
		Planes();
		Planets(false);
		asteroids.SetOffSprite();
		MyGui(false);
		Scripts(false);

	}
	public void On(){
		if(gameObject.tag=="pause"){
			Off();
			pause.ResumeGame();
		}
		Planets(true);
		asteroids.SetOnSprite();
		MyGui(true);
		Scripts(true);
		guiFinal.SetActive(false);
		if(MyParams.soundActive){
			print("sonido reeset");
		soundBack.onInGameSound(); 
		}
		Time.timeScale=1;//por si se apreta la rapidez del tiempo
	}
	
	void Planets(bool _active){
		for(int i=0;i<aPlanets.Length;i++){
			aPlanets[i].SetActive(_active);
		}
	}


	void MyGui(bool _active){

		GameManager.aterrizajes=0;
		if(GameManager.lifesGame<=0){
			//perdio asi q vuelve a tener las vidas del principio
			GameManager.lifesGame=GameManager.initialLifes;
			print("vidas desde reset "+GameManager.lifesGame);

		}
		backsGuiEscene.SetActive(_active);
		gui.transform.GetChild(0).gameObject.GetComponent<Gui>().SwichLifesOn();
		gui.transform.GetChild(1).gameObject.GetComponent<GuiTarget>().Reset();	
		gui.SetActive(_active);
	}

	void Scripts(bool _active){
		spawnManager.enabled=_active;
		detetId.enabled=_active;
		pause.enabled=_active;
	}
	void Planes(){
		print("cantidad d aviones antes "+spawnManager.getListPlanes.Count);
		int n=spawnManager.getListPlanes.Count;

		for(int i=0;i<n;i++){
			IdInicial auxInitial=null;
			GameObject aux=spawnManager.getListPlanes[i];
			auxInitial=aux.GetComponent<IdInicial>();
			if(auxInitial!=null){
				print("destruyendo sprite de id!!!!");
				auxInitial.DestroySprite();//destruyo sprite de id
			}
			aux.GetComponent<Delete>().DeleteMe();//destruyo nave y nodes
		}

	
		spawnManager.getListPlanes.RemoveRange(0,spawnManager.getListPlanes.Count);
		print("cantidad d aviones "+spawnManager.getListPlanes.Count);
	}

}
