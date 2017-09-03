
using UnityEngine;
using UnityEngine.UI;

public class Gui : MonoBehaviour {
	public Text aterrizesGui;
	public Detect detect;
	void Awake () {
		
	}
	

	void Update () {
		aterrizesGui.text=detect.getAterrizajes.ToString();
	}
}
