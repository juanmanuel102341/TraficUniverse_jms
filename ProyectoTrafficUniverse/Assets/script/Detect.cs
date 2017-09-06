
using UnityEngine;
using System.Collections;
public class Detect : MonoBehaviour {


	private  GameManager gameManager_obj;
	private string id;
	private bool choque=false;//boolean utilizado para el choque y n me saque 2 vidas
	void Awake () {
		gameManager_obj=GameObject.FindGameObjectWithTag("gameManager_tag").GetComponent<GameManager>();
		id=gameObject.tag;
		choque=false;//cuidado hay q resetearo en replay
	}
	

	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		
		print("aterrizando 2d");
		if(col.gameObject.tag=="naveA"&&id=="planetaTarget"){
			print("nave A aterrizaje");
			print("cantidad elemntos lista antes "+gameManager_obj.getValuesList.Count);
			ObjOut(col.gameObject);
//			print("cantidad elemntos lista despues "+spawnUp.getValuesListA.Count);
			GameManager.aterrizajes++;

		}else {
			GameManager.aviones++;
			print("choque entre objetos");
			ObjOut(this.gameObject);

		}
	
	}
	public void ObjOut(GameObject _obj){
		GameObject aux=_obj;
		gameManager_obj.GetOutObjectFromList(aux);
		aux.gameObject.GetComponent<SpriteRenderer>().enabled=false;
		aux.gameObject.GetComponent<Path>().RemovePaths();
		if(aux.gameObject.GetComponent<Path>().getPath.Count==0){
			Destroy(aux);
		}
	}


}
