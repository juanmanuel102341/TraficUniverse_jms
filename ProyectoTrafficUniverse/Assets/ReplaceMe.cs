
using UnityEngine;

public class ReplaceMe : MonoBehaviour {
	public GameObject node;
	PathInputs pathInputs;
	CircleCollider2D circle;
	SpriteRenderer spr;
	void Awake () {
		pathInputs=GetComponent<PathInputs>();	
		circle=GetComponent<CircleCollider2D>();
		spr=GetComponent<SpriteRenderer>();
	}
	void Start(){

	}
	public void Replace(){
		print("remplazando data ");
		spr=node.GetComponent<SpriteRenderer>();
		GetComponent<Transform>().localScale=node.GetComponent<Transform>().localScale;
		Destroy(circle);
	}
}
