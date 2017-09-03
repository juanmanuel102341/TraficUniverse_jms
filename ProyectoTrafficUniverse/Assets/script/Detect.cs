
using UnityEngine;
using System.Collections;
public class Detect : MonoBehaviour {

	private int aterrizajes=0;
	public SpawnPointUp spawnUp;

	void Awake () {
		
	}
	

	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		print("aterrizando 2d");
		if(col.gameObject.tag=="naveA"){
			print("nave A aterrizaje");
			print("cantidad elemntos lista antes "+spawnUp.getValuesListA.Count);
			GameObject aux=col.gameObject;
			spawnUp.GetOutObjectFromList(aux);
			aux.gameObject.GetComponent<SpriteRenderer>().enabled=false;
			aux.gameObject.GetComponent<Path>().RemovePaths();
			if(aux.gameObject.GetComponent<Path>().getPath.Count==0){
				Destroy(aux);
			}
//			print("cantidad elemntos lista despues "+spawnUp.getValuesListA.Count);
			aterrizajes++;//contador aterrizajes para gui

		}
	
	}
//	private void RemovingObjectFromList(GameObject _obj){
//		for(int i=0;i<spawnUp.getValuesListA.Count;i++){
//			if(spawnUp.getValuesListA[i].GetComponent<SpriteRenderer>().enabled==false){
//				print("sacando objeto de la lista");
//				spawnUp.setValuesListA.Remove(_obj);
//			}
//		}
//	}
	public int getAterrizajes{
		get {
			return aterrizajes;
		}
	}

}
