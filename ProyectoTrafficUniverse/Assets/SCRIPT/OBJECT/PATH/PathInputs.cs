
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PathInputs : MonoBehaviour {

	private bool activatePath=false;
	private bool clickObj=false;
	private int contador=0;
	private Camera cameraGame;
	public Path path;
	public float myConstrainAngle;

	private PathGraphic pathGraphic;
	private bool over=false;
	public GameObject id;
	protected Vector2 playerPos;
	protected List<Vector2>listNodesVec=new List<Vector2>();
	public delegate void OnClickMe(GameObject obj);//evento q se disprara en detetcs id para prender circulito de identificacion a
	public event OnClickMe ClickMe;
	private PositionMouse posMouse;
	private DeleteAllPaths deleteAll;
	private MyPath myPrincipalPath;

	//private int numberPathId;
	protected void Awake () {
		//me quede en poner en unna lista los diversos paths q se va creand por el click del usuario, para despues borrarlos mas facil


		cameraGame=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		deleteAll=GetComponent<DeleteAllPaths>();

	//	print("my last node "+tag+lastNode);
		pathGraphic=GetComponent<PathGraphic>();


		id.SetActive(false);
		posMouse=GetComponent<PositionMouse>();
//		print("clase path inputs");
		if(tag=="plane"){
			myPrincipalPath=new MyPath(pathGraphic);
			//pathGraphic.lastNode.GetComponent<PathInputs>().getMyPrinciplePath=myPrincipalPath;
			print("desde plane my principal path "+myPrincipalPath);
		}

//		if(pathGraphic.gameObject.tag=="lastNode"){
//			print("desde last node my principal path "+	getMyPrinciplePath);
//			if(myPrincipalPath==null){
//				print("myprincipal desde last node null");
//			}else{
//				print("existencia princiapl desde last node");
//			}
//		}

	}
	void Start(){
		path=new Path(pathGraphic,myConstrainAngle,myPrincipalPath);
	}
	protected void Update () {
		GetInputMouse();
	}
	// Update is called once per frame
	void OnMouseDown(){
		//print("click path inputs "+tag);
		contador++;
		if(myPrincipalPath.getListVectors.Count>0&&tag=="plane"){
			//print("borrando desdea act path");
			//path.Delete();
			//print("cantidad d nodes "+myPrincipalPath.getListVectors.Count);
		//	print("cant graphics "+myPrincipalPath.listGraphics.Count);

			myPrincipalPath.DeleteAllNodes();
		//	print("cantidad d nodes despues "+myPrincipalPath.getListVectors.Count);
		//	print("cant graphics despues"+myPrincipalPath.listGraphics.Count);


		}
//		if(activatePath){
//			activatePath=false;
//		}
//

		if(tag!="lastNode"){
		ClickMe(this.gameObject);
		}

		activatePath=true;
	}
	public void OnMouseUp(){
		//activatePath=false;
		if(activatePath){
			//*****************usuario suelta boton para dibujar el path**********************
			//print("reset paths inputs");
			activatePath=false;
			clickObj=false;
			contador=0;
			//print("soltando mouse papa");
			path.OnMouseUp();
		}

	}


	public void GetInputMouse(){
		Vector2 auxInput=posMouse.Calc();
		if(Input.GetMouseButton(0)&&activatePath){
			//print("click "+auxInput);
			path.SetNewNode(auxInput);//parte codigo
			}
	}

	public PositionMouse getPosMouse{
		get{
			return posMouse;	
		}
	}
	public MyPath getMyPrinciplePath{
		get{
			return myPrincipalPath;
		}
		set{
			myPrincipalPath=value;
		}
	}




}
