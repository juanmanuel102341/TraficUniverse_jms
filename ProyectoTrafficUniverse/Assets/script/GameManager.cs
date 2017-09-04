
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static int aterrizajes=0;
	public static  int vidas=3;
	public static int aviones=0;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
		if(aviones==2){
			vidas--;
			aviones=0;
		}
	}
}
