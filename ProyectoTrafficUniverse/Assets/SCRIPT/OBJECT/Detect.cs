using UnityEngine;
public class Detect : MonoBehaviour {

	private PathInputs  pathInputs;
	private  SpawnManager spawnManager;
	private string myTag;
	//private bool choque=false;//boolean utilizado para el choque y n me saque 2 vidas
	void Awake () {
		spawnManager=GameObject.FindGameObjectWithTag("gameManager_tag").GetComponent<SpawnManager>();
		pathInputs=GetComponent<PathInputs>();
		myTag=gameObject.tag;
	}
	void OnTriggerEnter2D(Collider2D col){
//		print("aterrizando 2d");
		if(CheckLanding(col.tag)){
			TakeOutPlane();
			GameManager.aterrizajes++;//aumento contador aterrizajes
		}else if(col.gameObject.tag=="naveA"||col.gameObject.tag=="naveB"||col.gameObject.tag=="naveC") {
			//pregunto si choca nave a nave sn esta la condicion "cuando aterriza"perdes 1/2vida(vida=2 aviones)
			TakeOutPlane();
			GameManager.aviones++;
		}
	}
	private void TakeOutPlane(){
		spawnManager.GetOutObjectFromList(this.gameObject);//te saco d la lista
		gameObject.GetComponent<Delete>().DeleteMe(); //te borro y tb paths
	}
	private bool CheckLanding(string planetTag){
		switch(planetTag){
		case"planetA":
			if(myTag=="naveA"){
				print("planeta a correcto aterrizando!");
				return true;
			}
			return false;
		case "planetB":
			if(myTag=="naveB"){
				print("planeta b correct");
				return true;
			}
			return false;
		case "planetC":
			if(myTag=="naveC"){
				print("planet c correct");
				return true;
			}
			return false;

		}
		return false;
	}



}
