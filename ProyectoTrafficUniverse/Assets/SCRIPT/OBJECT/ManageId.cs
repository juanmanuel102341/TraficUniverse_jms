using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageId : MonoBehaviour {
	private SpawnManager spawnManager;
	//public List<GameObject>listId=new List<GameObject>();
	private GameObject current=null;
	private GameObject last=null;
	void Awake () {
		spawnManager=GetComponent<SpawnManager>();
	
	}
	void Start(){
		
	}
	private GameObject GetActive(){
		if(spawnManager.getListPlanes.Count>0){
					for(int i=0;i<spawnManager.getListPlanes.Count;i++){
				if(spawnManager.getListPlanes[i]!=null){
				if(spawnManager.getListPlanes[i].transform.GetChild(2).gameObject.activeSelf&&spawnManager.getListPlanes[i].transform.GetChild(2).gameObject!=current||current==null){
					return spawnManager.getListPlanes[i].transform.GetChild(2).gameObject; 
					}
				}
//				print("id "+spawnManager.getListPlanes[i].transform.GetChild(2).gameObject.name);
			}
		}

		return null;
	}

	void Update () {
		
		GameObject aux=GetActive();
		if(aux!=null){
			if(current==null){
				current=aux;
//				print("1er id activo "+current.name);
			}
			if(aux!=current){
				last=current;
				last.SetActive(false);
				current=aux;
				current.SetActive(true);
			//s	print("click en otro "+current.name);
			}
		
		}
	}
}
