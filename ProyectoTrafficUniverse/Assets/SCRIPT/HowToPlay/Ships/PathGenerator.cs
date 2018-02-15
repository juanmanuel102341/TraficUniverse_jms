
using UnityEngine;

public class PathGenerator  {
	public Path path;
	public MyPath myPath;
	private float distance=0;
	private int total=0;
	private float distanceNodes;//distancia entre los nodos
	private Vector2 posPlayer;
	private Vector2 posTarget;
	private PathGraphic pathGraphic;
	public PathGenerator(Vector2 _posPlayer, Vector2 _posTarget,int _totalNodes,PathGraphic _pathGraphic){
		posPlayer=_posPlayer;
		posTarget=_posTarget;
		distance=GetDistance();
		total=_totalNodes;
		pathGraphic=_pathGraphic;
//		Debug.Log("posPlayer "+posPlayer);
//		Debug.Log("posTarget "+posTarget);
//		Debug.Log("distanceNodes "+distanceNodes);
//		Debug.Log("distance "+distance);
//		Debug.Log("total "+total);
		myPath=new MyPath(null,null);
		path=new Path(pathGraphic,0,myPath,0.9f);//parametro 0, para q la condicion de distanciadentro de la clase path n entre en vigor
		Calc();
	}
	float GetDistance(){
	return Vector2.Distance(posPlayer,posTarget);
	}

	float CalcMagnitudX(){
		float n=posTarget.x-posPlayer.x;
		return n/total;
	}
	float CalcMagnitudY(){
		float n=posTarget.y-posPlayer.y;
		return n/total;
	}
	void Calc(){
		Vector2 posInitial=posPlayer;
		float mx=CalcMagnitudX();
		float my=CalcMagnitudY();
//		Debug.Log("mag x "+mx);
//		Debug.Log("mag y "+my);
		for(int i=0;i<total;i++){
			posInitial.x+=mx;
			posInitial.y+=my;
			path.SetNewNode(posInitial);//creo un nodo ala posicion inicial d player mas la magnitud respectiva en x como en y
//			Debug.Log("nodo "+posInitial);
		}
//		for(int i=0;i<total;i++){
//			Debug.Log("path desde pg"+path.listNodes[i].posicion);
//		}
//		completeLoad();
	 
	}
	public Path getPath{
		get{
			return path;
		}
	}
}
