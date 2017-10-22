
using UnityEngine;

public class AlertColision : MonoBehaviour {
	private string id;
	public GameObject sprite;
	public GameObject objColision;
	private Transform transfSprite;
	private Transform transformParent;
	//float heightSpriteAttention=0;
	//float myWidth=0;
	//float myHeight=0;
//	public delegate void GetPos(Vector2 _vec);
//	public event GetPos GettingPos;
//	public delegate void DestroySprite();
//	public event DestroySprite EventDestroy;
	private Vector2 myVec;
	private int MyeulerZ;
	private int n;
	void Awake () {
		id=gameObject.tag;
		objColision.SetActive(false);
		sprite.SetActive(true);

	
		//transfSprite=sprite.GetComponent<Transform>();
	//	myVec=transfSprite.up;
		print("n "+MyeulerZ);
	}
	void Start(){
		print("my euler "+MyeulerZ);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag=="colisionArea"&&id=="colisionArea"){
			print("area");

			objColision.SetActive(true);
			sprite.SetActive(true);
			//transfSprite.up=myVec;
		}
		
	}

	void OnTriggerExit2D(Collider2D col){
		print("exit");
		sprite.SetActive(false);
		objColision.SetActive(false);
	}

//	public int getEuler{
//		get{
//			return MyeulerZ;
//		}
//	}
////	public float setHeightShip{
//		set{
//			myHeight=value;
//			print("altura obj "+myHeight);
//		}
//	}
//	public float setWidhtShip{
//		set{
//			myWidth=value;
//			print("ancho obj "+myWidth);
//		}
//	}
//

}
