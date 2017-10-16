using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPath : MonoBehaviour {
	private PathGraphic path;
	public int totalNodes;
	private MoveHowToPlay move;
	public float time_anim;
	private float time;
	private int index=0;
	public delegate void Finish();
	public event Finish finish;
	void Awake () {
		move=GetComponent<MoveHowToPlay>();
		path=GetComponent<PathGraphic>();
	}


	void Update () {
		time+=Time.deltaTime;
		if(time>time_anim&&index<move.path.listNodes.Count){
			path.SpawnGraphicPath(move.path.listNodes[index].posicion);		
			time=0;
			index++;
		}else if (index>=move.path.listNodes.Count){
			print("initialice move");
			finish();
		}
			
		}

}
