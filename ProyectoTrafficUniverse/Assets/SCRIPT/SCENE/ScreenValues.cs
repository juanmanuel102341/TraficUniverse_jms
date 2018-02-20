using UnityEngine;
public class ScreenValues : MonoBehaviour {
	private Camera cameraGame;
	private float widthScene=0;
	private float heightScene=0;
	private Vector2 constrainGui;
	void Awake () {
		//camara tiene q estar poscionada en (0,0)!!!
		cameraGame=GetComponent<Camera>();
	//		print ("camera "+cameraGame.orthographicSize);
		heightScene=cameraGame.orthographicSize;//alto de la camara 
		widthScene=cameraGame.aspect*cameraGame.orthographicSize;//ancho del tama;o d la camara multiplicado por la razon del ancho divido height(en mi caso 16/9)
		//print("height "+heightScene);
		//print("width "+widthScene);
	//	constrainGui=cameraGame.ScreenToWorldPoint(new Vector3( GameObject.FindGameObjectWithTag("guiBack").GetComponent<RectTransform>().rect.width-10,GameObject.FindGameObjectWithTag("guiBack").GetComponent<RectTransform>().rect.height+5,10));
		print("position gui x "+constrainGui);
		constrainGui.x=23;
		constrainGui.y=15;
	}
	public float getWidthScene{
		get{
			return widthScene;
		}
	}
	public float getHeightScene{
		get{
			return heightScene;
		}
	}
	public Vector2 getConstrainGui{

		get{
			return constrainGui;	
		}
	}

}
