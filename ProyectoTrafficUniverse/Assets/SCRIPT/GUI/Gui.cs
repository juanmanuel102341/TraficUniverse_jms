using UnityEngine;
using UnityEngine.UI;
public class Gui : MonoBehaviour {
	public Text target;
	private string id;
	private int vidas=0;
	void Awake () {
		id=this.gameObject.tag;
	}
	void Update () {
		switch(id){

		case "guiVidas":
			target.text=vidas.ToString();	
			break;
		case "guiAterrizajes":
			target.text=GameManager.aterrizajes.ToString();
			break;
			}
	}
	public int setVidas{
		set{
			vidas=value;
		}
	}

}
