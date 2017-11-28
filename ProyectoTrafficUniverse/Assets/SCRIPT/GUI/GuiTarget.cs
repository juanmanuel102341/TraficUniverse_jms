
using UnityEngine;
using UnityEngine.UI;
public class GuiTarget : MonoBehaviour {
	public Text numTarget;
	public Text numLandings;


	void Start(){
		SetTargetInitial();

	}
	public void EventsMe(GameObject obj){
		Detect detect=obj.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Detect>();//hijo del hijo
		detect.OnContactTarget+=OnActualizeMe;//evento q viene de cuando el avion aterriza
	}
	private void OnActualizeMe(){
		numLandings.text=GameManager.aterrizajes.ToString();
	}

	private void SetTargetInitial(){
		numTarget.text=GameManager.targetGame.ToString();
	}
	public void Reset(){
		OnActualizeMe();

	}
}
