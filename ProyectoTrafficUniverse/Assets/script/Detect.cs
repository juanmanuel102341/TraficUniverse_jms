
using UnityEngine;
using System.Collections;
public class Detect : MonoBehaviour {

	private PathInputs  pathInputs;
	private  SpawnManager gameManager_obj;
	private string id;
	private bool choque=false;//boolean utilizado para el choque y n me saque 2 vidas
	void Awake () {
		//gameManager_obj=GameObject.FindGameObjectWithTag("gameManager_tag").GetComponent<SpawnManager>();
		id=gameObject.tag;
		choque=false;//cuidado hay q resetearo en replay
		pathInputs=GetComponent<PathInputs>();
	}
	

	void OnTriggerEnter2D(Collider2D col){
		print("aterrizando 2d");
		if(col.gameObject.tag=="nave"&&id=="planetaTarget"){
			print("nave A aterrizaje");
			//print("cantidad elementos lista antes "+gameManager_obj.getValuesList.Count);
			if(id=="nave"){
				
				pathInputs.Delete();
				Destroy(this.gameObject);
			}
			//ObjOut(col.gameObject);
//			print("cantidad elemntos lista despues "+spawnUp.getValuesListA.Count);
			GameManager.aterrizajes++;

		}else if(id=="nave"&&col.gameObject.tag=="nave") {
			//pregunto si choca nave a nave sn esta la condicion "cuando aterriza"perdes 1/2vida(vida=2 aviones)
			GameManager.aviones++;
			print("choque entre objetos");
			//ObjOut(this.gameObject);
			print("cantidad nodos "+pathInputs.path.listNodos.Count);
//			
			pathInputs.Delete();
			print("cantidad nodos despues "+pathInputs.path.listNodos.Count);
			//	Destroy(this.gameObject);
			this.GetComponent<SpriteRenderer>().enabled=false;
		}
	}
	public void ObjOut(GameObject _obj){
		GameObject aux=_obj;
	//	gameManager_obj.GetOutObjectFromList(aux);
		aux.gameObject.GetComponent<SpriteRenderer>().enabled=false;

		Destroy(aux);

	}


}
