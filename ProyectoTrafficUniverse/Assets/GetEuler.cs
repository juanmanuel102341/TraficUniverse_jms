
using UnityEngine;

public class GetEuler : MonoBehaviour {
	private int eulerZ;
	private AlertColision alertCol;
	// Use this for initialization
	void Start () {
		alertCol=transform.GetChild(0).GetComponent<AlertColision>();
		eulerZ=(int)Mathf.Round(transform.localEulerAngles.z);
			alertCol.setEuler=eulerZ;
		print("alert col "+alertCol.tag);
		print("euler get euler "+eulerZ);
	}


}
