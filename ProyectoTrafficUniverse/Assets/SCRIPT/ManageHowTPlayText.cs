
using UnityEngine;

public class ManageHowTPlayText : MonoBehaviour {
	public NextPageHowToPlay next;
	public GameObject objCheck;

	// Use this for initialization

	void Awake(){
		MyParams.initialCycle=true;
	}
	void Start () {
		next.onFinish+=onFinishing;
		next.onBack+=onBacking;
	}

	private void onFinishing(){
		print("finalizando");
		objCheck.SetActive(true);
	}
	private void onBacking(){
		print("vuelta para atras");
		objCheck.SetActive(false);
		next.gameObject.SetActive(true);
	}
}
