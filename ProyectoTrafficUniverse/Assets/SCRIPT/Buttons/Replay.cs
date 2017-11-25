using UnityEngine;
using UnityEngine.Events;
public class Replay : MonoBehaviour {
	public delegate void ReplayGame();
	public event ReplayGame activateReplay;

	public void ReplayMethod(){
		print("replay ");
		activateReplay();
	}
}
