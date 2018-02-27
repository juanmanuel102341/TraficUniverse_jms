using UnityEngine;
public class Detect : MonoBehaviour {

	private GameObject objParent;
	private  SpawnManager spawnManager;
	private CheckTargetColision checkTarget;
	public delegate void OnContact();
	public event OnContact OnContactPlane;
	public event OnContact OnContactTarget;
	public event  OnContact OnContactFrontier;
	//public Bounds bounds;
	public GameObject explosion;


	//private bool choque=false;//boolean utilizado para el choque y n me saque 2 vidas
	void Awake () {
		spawnManager=GameObject.FindGameObjectWithTag("gameManager_tag").GetComponent<SpawnManager>();
		objParent=transform.parent.parent.gameObject;	
		checkTarget=GetComponent<CheckTargetColision>();
//		print(objParent.name);
	}
	void OnTriggerEnter2D(Collider2D col){
		//print("contacto collider nave "+col.name);
		if(col.gameObject.tag=="frontier"){
			print("fontier colisioon!!");
			//bounds.setLimitOutside=true;
			OnContactFrontier();

		}
		if(tag=="shipRed"&&col.tag=="targetRed"||tag=="shipBlue"&&col.tag=="targetBlue"||tag=="shipGreen"&&col.tag=="targetGreen"){
		TakeOutPlane();
		print("aterrizando 2d");
				//print("paneta");
		GameManager.aterrizajes++;//aumento contador aterrizajes
		OnContactTarget();
				
		}
		if(col.gameObject.tag=="shipRed"||col.gameObject.tag=="shipBlue"||col.gameObject.tag=="shipGreen") {
			print("choque d naves");
			//pregunto si choca nave a nave sn esta la condicion "cuando aterriza"perdes 1/2vida(vida=2 aviones)
			TakeOutPlane();
			GameManager.aviones++;
			if(GameManager.aviones==2){
			OnContactPlane();
			Explosion();
			}
			
		}
	
		if(col.tag=="asteroide")
		{	TakeOutPlane();
			print("colision asteroide muerte nave");
			OnContactPlane();//el evento se vincula con gui y dentro de esta se le resta una vida
			Explosion();
		}
	
	}

	private void TakeOutPlane(){
		//print("objParent "+objParent.name);
		objParent.GetComponent<PathInputs>().getMyPrinciplePath.DeleteAllNodes();//borro los nodes 
		spawnManager.GetOutObjectFromList(objParent);//objeto padre del padre
		objParent.GetComponent<Delete>().DeleteMe();
	}


	private void Explosion(){

		print("entrando explosion");
		Instantiate(explosion,transform.position,transform.rotation);
	}

}
