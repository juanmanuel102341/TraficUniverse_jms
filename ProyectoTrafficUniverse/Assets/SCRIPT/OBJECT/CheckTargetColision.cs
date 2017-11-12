
using UnityEngine;

public class CheckTargetColision : MonoBehaviour {
	private string myTag;
	void Awake () {
		//su sentido es establer la correspondencia entre los tipos d naves y planetas 
		myTag=gameObject.tag;
//		print("myTag "+myTag);
	}
	
	public bool CheckMyTarget(string targetTag){
		switch(targetTag){
		case"targetRed":
			if(myTag=="shipRed"||myTag=="colisionRed"){
			//	print("planeta red");
				return true;
			}
			return false;
		case "targetBlue":
			if(myTag=="shipBlue"||myTag=="colisionBlue"){
			//	print("planeta blue");
				return true;
			}
			return false;
		case "targetGreen":
			if(myTag=="shipGreen"||myTag=="colisionGreen"){
			//	print("planet green");
				return true;
			}
			return false;
		case "asteroide":
			
				print("choque targetcol asteroide");
				return true;

			break;
		}
		return false;
	
		}	
	 

}
