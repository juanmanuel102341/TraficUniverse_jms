
using UnityEngine;

public class MyEvent : MonoBehaviour {

	private string id;
	public delegate void Finish(string _id);
	public event Finish finish;
	public delegate void Finish2();
	public event Finish2 finishing2;
	public static int counting=0;
	void Awake () {
		id=tag;

	}
	void OnTriggerEnter2D(Collider2D col) {
		print("triguer rojo");
		counting++;
		print("counting "+counting );
		print("total planets "+GameManagmentHowTplay.totalPlanets);
		if(counting==GameManagmentHowTplay.totalPlanets){
			print("activo evento");
			finishing2();
		}
		finish(id);

	}

}
