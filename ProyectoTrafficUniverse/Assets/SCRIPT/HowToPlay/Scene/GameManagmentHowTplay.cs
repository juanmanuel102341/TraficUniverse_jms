using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagmentHowTplay : MonoBehaviour {
	public GameObject [] targetsPlanets;//x si hay mas d uno posteriormente
	private int countPlanets=0;
	public GameObject [] player;//x si hay mas d uno posteriormente
	public GameObject puntero;
	public GameObject guiButton;
	public static int totalPlanets=0;
	void Awake(){
		guiButton.SetActive(false);
		totalPlanets=targetsPlanets.Length;
	}
	void Start () {
		for(int i=0;i<targetsPlanets.Length;i++){
			targetsPlanets[i].GetComponent<MyEvent>().finish+=TargetActive;
			print("data planeta "+i+") "+targetsPlanets[i].GetComponent<Transform>().position);
		}

	}
	public void TargetActive(string _id){
		switch(_id){
		case "targetRed":
			//empieza aca

			print("desde game managment tarrget tojo");
			FinishScene();

			print("contador "+countPlanets);
			break;
		case "targetBlue":
			print("desde game managment target blue");
		
			FinishScene();

			print("contador "+countPlanets);
			break;
		case "targetGreen":
			print("desde game managment target green");

			FinishScene();

			print("contador "+countPlanets);
			break;
		
		}
	}
	private void FinishScene(){
		print("contador "+countPlanets);
		print("tp "+targetsPlanets.Length);
		if(countPlanets>=targetsPlanets.Length-1){
			print("escena fin");
			DeleteObjects();
			guiButton.SetActive(true);

		}else{
			print("pasando al siguiente target");
			puntero.GetComponent<ManageComponents>().Active();//activo componentes del mouse
			puntero.GetComponent<MovePointer>().target=player[countPlanets+1].GetComponent<Transform>();//le paso info de target al puntero para q se mueva
			print("puntero next  "+player[countPlanets+1].GetComponent<Transform>().position);
			countPlanets++;
		}
	}
	private void DeleteObjects(){
		//nodos//planeta//player//puntero
		print("eliminacion objetos");
		for(int i=0;i<player.Length;i++){
//			player[i].GetComponent<PathGraphic>().Delete_ngraphics();//elmino nodos
			player[i].GetComponent<DeleteMe>().MyDelete();//elimino player
			}
		for(int i=0;i<targetsPlanets.Length;i++){
			targetsPlanets[i].GetComponent<DeleteMe>().MyDelete();//elimino planetas 
		}
		puntero.GetComponent<DeleteMe>().MyDelete();//elimino puntero
	}

}
