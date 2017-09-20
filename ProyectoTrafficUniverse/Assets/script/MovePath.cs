
using UnityEngine;

public class MovePath : MonoBehaviour {
	
	private Move moveBase;
	private Vector2 currentPath;
	private int index=0;

	void Awake () {
		
		moveBase=GetComponent<Move>();
		}
	

	void Update () {
		if(moveBase.getPath.getPathVectors.Count>0&&index<moveBase.getPath.getPathVectors.Count){
			print ("entrando desde move ");
			currentPath=moveBase.getPath.getPathVectors[index];
			transform.position=Vector2.MoveTowards(MyPos(),currentPath,moveBase.getVelocity*Time.deltaTime);
			Finish();
			}
	}

	private Vector2 MyPos(){
	Vector2 aux;
	aux.x=transform.position.x;
	aux.y=transform.position.y;
	return aux;
	}
	private void Finish(){
		if(Vector2.Distance(MyPos(),currentPath)<=0.0f){
		//	print("cambio desde move");
			index++;
		
		}

	}
	public int setIndex_m{
		set{
			index=value;
		}
	}


}
