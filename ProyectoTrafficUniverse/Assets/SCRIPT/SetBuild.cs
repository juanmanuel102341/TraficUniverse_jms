
using UnityEngine;
using UnityEngine.UI;
public class SetBuild : MonoBehaviour {

	private Text myBuidNumber;
	private float num=0.15f;
	void Awake () {
		myBuidNumber=GetComponent<Text>();
		myBuidNumber.text=num.ToString();
	}
	

}
