using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagmentHowTplay : MonoBehaviour {

	private int countPlanets=0;
	public GameObject [] player;//x si hay mas d uno posteriormente
	public GameObject puntero;
	public GameObject guiButton;
	private GameObject[] targets;
	private GameObject buttonSkip;
	void Awake(){
		guiButton.SetActive(false);
		targets=GameObject.FindGameObjectsWithTag("targets");
		buttonSkip=GameObject.FindGameObjectWithTag("skip");
	}
	public void FinishScene(){
		print("contador "+countPlanets);
		countPlanets++;
		if(countPlanets>=targets.Length){
			print("escena fin");
			DeleteObjects();//borro planetas y puntro fin de escena
			guiButton.SetActive(true);

		}else{
			print("pasando al siguiente target");
			puntero.GetComponent<ManageComponents>().Active();//activo componentes del mouse
			MovePointer pmouse=puntero.GetComponent<MovePointer>();
			pmouse.SetDestiny(player[countPlanets].GetComponent<Transform>().position);//le paso info de target al puntero para q se mueva

			print("player "+player[countPlanets].name);
			//print(" destiny p[layer "+player[countPlanets+1].GetComponent<)
			print("puntero next  "+player[countPlanets].GetComponent<Transform>().position);
	//		print("destno player "+player[countPlanets+1].)
		
		}
	}
	private void DeleteObjects(){
		//nodos//planeta//player//puntero
		print("eliminacion objetos");
		Destroy(buttonSkip);
		for(int i=0;i<targets.Length;i++){
			targets[i].GetComponent<DeleteMe>().MyDelete();
		}
		puntero.GetComponent<DeleteMe>().MyDelete();//elimino puntero
	}
	public int getNumberPlanets{
		get{
			return targets.Length;
		}
	}
}
