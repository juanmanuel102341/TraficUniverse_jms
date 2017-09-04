
using UnityEngine;
using UnityEngine.UI;

public class Gui : MonoBehaviour {
	//public Text aterrizesGui;

	public Text target;
	private string id;
	void Awake () {
		id=this.gameObject.tag;
	}
	

	void Update () {
		switch(id){

		case "guiVidas":
			target.text=GameManager.vidas.ToString();	
			break;
		case "guiAterrizajes":

			target.text=GameManager.aterrizajes.ToString();
			break;

		}


	}
}
