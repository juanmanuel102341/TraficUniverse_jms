using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectsId : MonoBehaviour {
	public delegate void ClickSound();
	public event ClickSound OnclickSound;
	private GameObject currentActive=null;
	public void EventStart(GameObject obj){
		obj.GetComponent<PathInputs>().ClickMe+=OnClickMe;
	}
	private void OnClickMe(GameObject obj){
		if(MyParams.soundActive){
			OnclickSound();
		}
		if(currentActive==null){
			currentActive=obj;
			currentActive.transform.GetChild(3).gameObject.SetActive(true);//activo objeto id, identificacion

		}else{
			if(obj!=currentActive){
			currentActive.transform.GetChild(3).gameObject.SetActive(false);//apago id 
			print("apago mi id "+currentActive.name);
			currentActive=obj;
			currentActive.transform .GetChild(3).gameObject.SetActive(true);//prendo nueva id
			print("prendo nuevva del obj "+currentActive.name);
				if(MyParams.soundActive){
				OnclickSound();
				}
			}
			}
	}

}
