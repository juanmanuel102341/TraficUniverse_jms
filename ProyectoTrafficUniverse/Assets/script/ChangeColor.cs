
using UnityEngine;

public class ChangeColor : MonoBehaviour {
	private SpriteRenderer spr;
	public Color colorFirstClick;
	public Color colorSecondClick;
	private Color myColor;
	void Awake () {
		spr=GetComponent<SpriteRenderer>();		
		colorFirstClick.a=1;//hay q cambiar el alpha porq sn "desaparece"
		colorSecondClick.a=1;//idem
		myColor=spr.color;
	}
	public void ColorFirstClick(){
		//color cuando lo activas
		spr.color=colorFirstClick;

	}
	public void ColorSecondClick(){
		spr.color=colorSecondClick;
	}
	public void MyColor(){
		// se activa tu color
		spr.color=myColor;

	}
	

}
