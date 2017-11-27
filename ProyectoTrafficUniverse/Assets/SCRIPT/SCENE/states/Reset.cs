using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {
	//se encarga de resetiar valores y dejarlos como en su nivel inicil

	public GameObject [] aPlanets;
	private GameObject [] aAsteroids;
	public GameObject gui;
	public SpawnManager spawnManager;
	public DetectsId detetId;
	public Pause pause;
	public Replay replay;
	public GameObject guiFinal;
	public SoundBack soundBack;
	void Awake () {
		aAsteroids=GameObject.FindGameObjectsWithTag("asteroide");


	}
	void Start(){
		Off();
		replay.activateReplay+=On;
	}
	public void Off(){
		Planes();
		Planets(false);
		Asteroids(false);
		MyGui(false);
		soundBack.StopMe();
		Scripts(false);

	}
	public void On(){
		
		Planets(true);
		Asteroids(true);
		MyGui(true);
		Scripts(true);
		guiFinal.SetActive(false);
		soundBack.PlayMe();
	}
	
	void Planets(bool _active){
		for(int i=0;i<aPlanets.Length;i++){
			aPlanets[i].SetActive(_active);
		}
	}
	void Asteroids(bool _active){
		for(int i=0;i<aAsteroids.Length;i++){
			aAsteroids[i].SetActive(_active);
		}	
	}
	void MyGui(bool _active){
//		if(Gui.myLife>0){
//		//paso d level
//		
//		}else{
//			
//		}
//		gui.transform.GetChild(2).gameObject.GetComponent<FastTime>().OnResetMe();
		GameManager.aterrizajes=0;
		GameManager.lifesGame=3;
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
			GameObject aux=spawnManager.getListPlanes[i];
			//spawnManager.GetOutObjectFromList(aux);
			aux.GetComponent<Delete>().DeleteMe();//destruyo nave y nodos
		}
	
		spawnManager.getListPlanes.RemoveRange(0,spawnManager.getListPlanes.Count);
		print("cantidad d aviones "+spawnManager.getListPlanes.Count);
	}

}
