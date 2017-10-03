using UnityEngine;

public class Replay : MonoBehaviour {
	public delegate void ReplayGame();
	public static event ReplayGame activateReplay;
	public void ReplayMethod(){
		print("replay ");
		activateReplay();
	}
}
