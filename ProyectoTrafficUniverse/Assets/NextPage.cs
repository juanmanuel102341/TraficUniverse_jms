
using UnityEngine;

public class NextPage : MonoBehaviour {

	public GameObject Disable;
	public GameObject Active;

	public void OnActive(){

		Active.SetActive(true);
		Disable.SetActive(false);
		}

}
