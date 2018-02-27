
using UnityEngine;

public class NextPage : MonoBehaviour {

	public GameObject Disable;
	public GameObject Active;
	public GameObject credit1;
	public void OnActive(){

	
		if(gameObject.name=="Button (2)"){
			print("reset credits final");
			GameObject obj2=GameObject.Find("2");
	
			obj2.SetActive(false);
			credit1.SetActive(true);//para q vuelva a como estaba antes y no empiece en 2
		//	print("2 "+obj2);

		}
		Active.SetActive(true);
		Disable.SetActive(false);
		}

}
