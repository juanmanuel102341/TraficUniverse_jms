
using UnityEngine;
using System.Collections;
public class Detect : MonoBehaviour {

	private PathInputs  pathInputs;
	private  SpawnManager spawnManager;

	//private bool choque=false;//boolean utilizado para el choque y n me saque 2 vidas
	void Awake () {
		spawnManager=GameObject.FindGameObjectWithTag("gameManager_tag").GetComponent<SpawnManager>();
		pathInputs=GetComponent<PathInputs>();
	}
	

	void OnTriggerEnter2D(Collider2D col){
		print("aterrizando 2d");
		if(col.tag=="planetaTarget"){
			print("nave A aterrizaje");
			TakeOutPlane();
			GameManager.aterrizajes++;//aumento contador aterrizajes

		}else if(col.gameObject.tag=="nave") {
			//pregunto si choca nave a nave sn esta la condicion "cuando aterriza"perdes 1/2vida(vida=2 aviones)
			TakeOutPlane();
			GameManager.aviones++;
		}
	}
	private void TakeOutPlane(){
		//pathInputs.Delete();//te borro los paths si tenes
		spawnManager.GetOutObjectFromList(this.gameObject);//te saco d la lista
		gameObject.GetComponent<Delete>().DeleteMe(); //te borro y tb paths
	}


}
