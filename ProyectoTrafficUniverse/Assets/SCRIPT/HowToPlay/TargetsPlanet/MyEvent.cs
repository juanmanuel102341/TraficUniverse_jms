
using UnityEngine;

public class MyEvent : MonoBehaviour {

	private string id;
	public delegate void Finish(string _id);
	public event Finish finish;
	public delegate void Finish2();
	public event Finish2 finishing2;
	public static int counting=0;
	public GameObject pointer;

	void Awake () {
		id=tag;

	}
	void OnTriggerEnter2D(Collider2D col) {

		if(col.tag=="pointer" &&counting==GameManagmentHowTplay.totalPlanets-1){
			print("fuera pointer");
			//pointer.SetActive(false);
		}
		if(col.tag=="plane"){
			print("borrando avion");
			SpriteRenderer spr=col.gameObject.GetComponent<SpriteRenderer>();
			col.gameObject.GetComponent<MoveHowToPlay>().getPathGenerator.myPath.DeleteAllNodes();
			col.gameObject.GetComponent<AnimationPath>().enabled=false;
			col.gameObject.GetComponent<MoveHowToPlay>().enabled=false;
			col.gameObject.GetComponent<BoxCollider2D>().enabled=false;
			//Destroy(col.gameObject);
			spr.enabled=false;
			counting++;
			if(counting==GameManagmentHowTplay.totalPlanets){
				print("activo evento");
				finishing2();

			}
			finish(id);
		}

//		print("triguer rojo");
//	
//		print("counting "+counting );
//		print("total planets "+GameManagmentHowTplay.totalPlanets);


	}

}
