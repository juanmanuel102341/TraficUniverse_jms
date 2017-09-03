
using UnityEngine;

public class Dead : MonoBehaviour {

	private bool alive=true;
	void Awake () {
		alive=true;
	}
	public bool getAlive{
		get{
			return alive;
		}
	}
	public bool setAlive{
		set{
			alive=value;
		}
	}	

}
