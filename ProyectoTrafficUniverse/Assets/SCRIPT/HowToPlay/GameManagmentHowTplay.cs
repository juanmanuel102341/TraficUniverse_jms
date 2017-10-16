using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagmentHowTplay : MonoBehaviour {
	public GameObject [] targetsPlanets;
	private int countPlanets=0;
	public GameObject [] player;//x si hay mas d uno posteriormente
	public GameObject puntero;
	public GameObject guiButton;
	void Awake(){
		guiButton.SetActive(false);
	}
	void Start () {
		for(int i=0;i<targetsPlanets.Length;i++){
			targetsPlanets[i].GetComponent<MyEvent>().finish+=TargetActive;
		}
	}
	public void TargetActive(string _id){
		switch(_id){
		case "targetRed":
			countPlanets++;
			print("desde game managment tarrget tojo");
			FinishScene();
			break;
		}
	}
	private void FinishScene(){
		if(targetsPlanets.Length>=countPlanets){
			print("escena fin");
			DeleteObjects();
			guiButton.SetActive(true);
		}
	}
	private void DeleteObjects(){
		//nodos//planeta//player//puntero
		print("eliminacion objetos");
		for(int i=0;i<player.Length;i++){
			player[i].GetComponent<PathGraphic>().Delete_ngraphics();//elmino nodos
			player[i].GetComponent<DeleteMe>().MyDelete();//elimino player
			}
		for(int i=0;i<targetsPlanets.Length;i++){
			targetsPlanets[i].GetComponent<DeleteMe>().MyDelete();//elimino planetas 
		}
		puntero.GetComponent<DeleteMe>().MyDelete();//elimino puntero
	}

}
