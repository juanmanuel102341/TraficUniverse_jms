using UnityEngine;

public class Replay : MonoBehaviour {
	public delegate void ReplayGame(string id);
	public static event ReplayGame activateReplay;

	public void ReplayMethod(){
		print("replay ");
		activateReplay(gameObject.tag);
	}
}
