using UnityEngine;
using UnityEngine.UI;
public class SetTarget : MonoBehaviour {
	private int targetPlanes=0;
	private Text myText;
	void Start () {
		myText=GetComponent<Text>();
		myText.text=targetPlanes.ToString();
	}
	
	public int setTarget{
		set{
			targetPlanes=value;
		}
	}

}
