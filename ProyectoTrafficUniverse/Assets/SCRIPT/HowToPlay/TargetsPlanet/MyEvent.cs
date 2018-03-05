
using UnityEngine;

public class MyEvent : MonoBehaviour {

	private string id;
	public static int counting=0;
//	public GameObject pointer;
	private GameManagmentHowTplay gameManagment;

	void Awake () {
		id=tag;
		gameManagment=GameObject.FindGameObjectWithTag("managerHow").GetComponent<GameManagmentHowTplay>();
	}
	void OnTriggerEnter2D(Collider2D col) {


		if(col.tag=="plane"){
			print("borrando avion");
			//SpriteRenderer spr=col.gameObject.GetComponent<SpriteRenderer>();
		//	spr.enabled=false;
			col.gameObject.GetComponent<Move_How_to_play>().Delete();
			counting++;
			gameManagment.FinishScene();

	//		finish(id);
		}

//		print("triguer rojo");
//	
//		print("counting "+counting );
//		print("total planets "+GameManagmentHowTplay.totalPlanets);


	}

}
