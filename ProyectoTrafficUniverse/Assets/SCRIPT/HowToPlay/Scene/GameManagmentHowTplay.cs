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
			MovePointer pmouse=puntero.GetComponent<MovePointer>();
			pmouse.SetDestiny(player[countPlanets+1].GetComponent<Transform>().position);//le paso info de target al puntero para q se mueva
			pmouse.SetEventAnimation(player[countPlanets+1].GetComponent<AnimationPath>());//seteo evento de animation;
			print("player "+player[countPlanets+1].name);
			//print(" destiny p[layer "+player[countPlanets+1].GetComponent<)
			print("puntero next  "+player[countPlanets+1].GetComponent<Transform>().position);
	//		print("destno player "+player[countPlanets+1].)
			countPlanets++;
		}
	}
	private void DeleteObjects(){
		//nodos//planeta//player//puntero
		print("eliminacion objetos");
		for(int i=0;i<player.Length;i++){
			player[i].GetComponent<MoveHowToPlay>().getPathGenerator.myPath.DeleteAllNodes();//elmino nodos
			player[i].GetComponent<DeleteMe>().MyDelete();//elimino player
			}
		for(int i=0;i<targetsPlanets.Length;i++){
			targetsPlanets[i].GetComponent<DeleteMe>().MyDelete();//elimino planetas 
		}
		puntero.GetComponent<DeleteMe>().MyDelete();//elimino puntero
	}

}
