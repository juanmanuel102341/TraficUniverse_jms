using UnityEngine;
using UnityEngine.Events;
public class Replay : MonoBehaviour {
	public delegate void ReplayGame(string id);
	public event ReplayGame activateReplay;

	public void ReplayMethod(){
		print("replay ");
		activateReplay(gameObject.tag);
	}
}
