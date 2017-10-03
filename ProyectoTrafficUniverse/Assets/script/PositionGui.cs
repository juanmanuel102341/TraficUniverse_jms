
using UnityEngine;

public class PositionGui : MonoBehaviour {

	// Use this for initialization
	public ScreenValues screenValues;
	private float anchoScreen;
	private float altoScreen;
	private float anchoObj;
	private float altoObj;
	private RectTransform rect;
	public Camera cam;
	void Awake () {
		//tu ancho, alto ,ancho screen, alto screen,posicion donde quiero q vaya
		rect=GetComponent<RectTransform>();
	}
	void Start(){
		anchoScreen=screenValues.getWidthScene;
		altoScreen=screenValues.getHeightScene;
		Vector2 screen;
		screen.x=anchoScreen;
		screen.y=altoScreen;
		 screen=cam.WorldToScreenPoint (screen);
		print("screen pixeles"+screen );
		anchoObj=rect.sizeDelta.x;
		altoObj=rect.sizeDelta.y;
		print("anchoScreen "+anchoScreen);
		print("altoScreen "+altoScreen);
		print("anchoObj "+anchoObj);
		print("altoObj "+altoObj);
//
//		Vector3 newPos;
//		newPos.x=anchoObj;
//		newPos.y=screen.y-altoObj;
//
//		Vector2 view;
//		view.x=0.0f;
//		view.y=0;
//
//		newPos.z=0.0f;
//		rect.position=newPos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
