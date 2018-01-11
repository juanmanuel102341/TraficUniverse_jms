
using UnityEngine;

public class DetectClick : MonoBehaviour {

	private bool active=false;
	private Path path;
	private PositionMouse posMouse;
	private CircleCollider2D box;
	private bool over=false;
	void Awake(){
		box=GetComponent<CircleCollider2D>();	
	}
	void Update(){
		if(active&&Input.GetMouseButton(0)&&!over){
			print("entrando node detect");
			Vector2 aux=posMouse.Calc();
			path.SetNewNode(aux);
		}
	}

	void OnMouseDown(){

		active=true;
	}

//	void OnMouseUp(){
//		if(path.listNodes.Count>0){
//		this.enabled=false;
//		box.enabled=false;
//		}
//		path.OnMouseUp();
//		active=false;
//	}
	public Path SetPath{
		set{
			path=value;
		}
	}
	public PositionMouse SetPositionMouse{
		set{
			posMouse=value;
		}
	}
	void OnMouseOver(){
		//si el jugador clickea encima "xra q n se genere ningun path" para eso este booleano
		over=true;
	}
	void OnMouseExit(){
		over=false;
		//print("mouse fuera");
	}
	public void DeleteMe(){
		Destroy(this.gameObject);
//		path.countNodes--;
		//path.angleConstrain.setCounting--;
	}

}
