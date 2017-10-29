using UnityEngine;
public class Detect : MonoBehaviour {

	private GameObject objParent;
	private  SpawnManager spawnManager;
	private CheckTargetColision checkTarget;
	//private bool choque=false;//boolean utilizado para el choque y n me saque 2 vidas
	void Awake () {
		spawnManager=GameObject.FindGameObjectWithTag("gameManager_tag").GetComponent<SpawnManager>();
		objParent=transform.parent.parent.gameObject;	
		checkTarget=GetComponent<CheckTargetColision>();
//		print(objParent.name);
	}
	void OnTriggerEnter2D(Collider2D col){
		print("contacto collider nave");
//		print("aterrizando 2d");
		if(checkTarget.CheckMyTarget(col.tag)){
			print("paneta");
			TakeOutPlane();
			GameManager.aterrizajes++;//aumento contador aterrizajes
		}else if(col.gameObject.tag=="shipRed"||col.gameObject.tag=="shipBlue"||col.gameObject.tag=="shipGreen") {
			print("choque d naves");
			//pregunto si choca nave a nave sn esta la condicion "cuando aterriza"perdes 1/2vida(vida=2 aviones)
			TakeOutPlane();
			GameManager.aviones++;
		}
		}

	private void TakeOutPlane(){
		print("objParent "+objParent.name);
		spawnManager.GetOutObjectFromList(objParent);//objeto padre del padre
		objParent.GetComponent<Delete>().DeleteMe();
	}




}
