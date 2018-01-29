using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPath : MonoBehaviour {
	private PathGraphic path;

	private MoveHowToPlay move;
	private float time_anim;
	private float time;
	private int index=0;
	public delegate void Finish();
	public delegate void FinishNode(Vector2 target);
	public event FinishNode onFinishNode;
	public event Finish finish;
	public DataShips dataDad;
	void Awake () {
		time_anim=dataDad.timeAnim;
		move=GetComponent<MoveHowToPlay>();
		path=GetComponent<PathGraphic>();
	}
	void Update () {
		time+=Time.deltaTime;
		if(time>time_anim&&index<move.getPathGenerator.myPath.getListGraphic.Count){
			//path.SpawnGraphicPath(move.path.listNodes[index]);		
		
			time=0;
			if(move.getPathGenerator.myPath.getListVectors.Count>0){
				print("entrando animation path  cant d nodes "+move.getPathGenerator.myPath.getListVectors.Count);
				print("node actual "+move.getPathGenerator.myPath.getListVectors[index]);
				move.getPathGenerator.myPath.getListGraphic[index].GetComponent<ViewSprite>().SetOnMySprite();//prendo un nodo
			onFinishNode(move.getPathGenerator.myPath.getListVectors[index]);//le paso la posicion al puntero del mouse del primer node d la lista
			
			}
				index++;

		}else if (index>=move.getPathGenerator.myPath.getListGraphic.Count){
//			print("initialice move");
			finish();
		}
			
		}

}
