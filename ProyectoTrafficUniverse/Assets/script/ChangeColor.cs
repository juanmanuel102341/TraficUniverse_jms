
using UnityEngine;

public class ChangeColor : MonoBehaviour {
	private SpriteRenderer spr;
	private PathInputs eventMouse;
	public Color cactive;
	public Color cPersuit;
	//public Color cIdle;
	private Color currentColor;
	private Color colorInitial;

	void Awake () {
		spr=GetComponent<SpriteRenderer>();		
		eventMouse=GetComponent<PathInputs>();
		currentColor=spr.color;
		cactive.a=1;//hay q cambiar el alpha porq sn "desaparece"
		cPersuit.a=1;
	//	cIdle.a=1;
		colorInitial=spr.color;
	}
	void Update () {
//		if(eventMouse.getClick&&currentColor!=cactive){
//			//si hiciste click y tu color es distinto al elegido
//			ColorActive();
//			print("cambio d color");
//		}

	}
	public void ColorActive(){
		//color cuando lo activas
		spr.color=cactive;
		currentColor=spr.color;
	}
	public void ColorPersuit(){
		//color cuando se mueve
		spr.color=cPersuit;
		currentColor=spr.color;
	}
	public void ColorIdle(){
		//color predeterminado sin q hagas nada
		spr.color=colorInitial;
		currentColor=spr.color;
	}

}
