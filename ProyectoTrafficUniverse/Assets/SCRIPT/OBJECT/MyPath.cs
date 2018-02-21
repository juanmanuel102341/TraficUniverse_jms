using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPath {
	public List<GameObject>listGraphics=new List<GameObject>();
	private List<Vector2>listVectors=new List<Vector2>();
	private List<GameObject>listLastNodeOld=new List<GameObject>();//parte grafica de los ultimo nodes q ya fueron desehechados por la creacion de otro nuevo en el mismo path
	private GameObject lastNode=null;
	private int indexLast=0;
	private PathGraphic pathGraphic;
	private MoveSoft moveSoft;

	public float px;
	public float py;


	public MyPath(PathGraphic _pathGraphic,MoveSoft _moveSoft){
		pathGraphic=_pathGraphic;
		moveSoft=_moveSoft;
	}

	public void InsertVector(Vector2 v){
		listVectors.Add(v);

	}
	public void InsertGraphics(GameObject obj){
		listGraphics.Add(obj);
		}

	public void DeleteLastNode(){
		DeleteNodeGraphic(listGraphics.Count-1);

	}
	public void DeleteFirstNode(){
		if(listGraphics!=null)
		DeleteNodeGraphic(0);


		listVectors.Remove(listVectors[0]);
	}
	public void DeleteAllNodes(){
		
		for(int i=0;i<listGraphics.Count;i++){
			GameObject obj=listGraphics[i];
			if(obj!=null)
			obj.GetComponent<DeleteMe>().MyDelete();
	
		}
		listGraphics.RemoveRange(0,listGraphics.Count);
		listVectors.RemoveRange(0,listVectors.Count);
	}
	private void DeleteNodeGraphic(int index){
		
		GameObject obj=listGraphics[index];

		listGraphics.RemoveAt(index);
		if(obj!=null)
		obj.GetComponent<DeleteMe>().MyDelete();
	

	}
	public List<Vector2> getListVectors{
		get{
			return listVectors;
		}
	}
	public List<GameObject> getListGraphic{
		get{
			return listGraphics;
		}
	}
	public GameObject setlastNode{
		set{
			lastNode=value;
		}
		get{
			return lastNode;
		}
	}
	public void CalcLastNodeVectors(){
		Vector2 aux2;
		if(listVectors.Count>1){
		Vector2 aux=listVectors[listVectors.Count-1]-listVectors[listVectors.Count-2];
			int dx=1;
			int dy=1;
			float d=Vector2.Distance(listVectors[listVectors.Count-1],listVectors[listVectors.Count-2]);
			//Debug.Log("ulitmo vector "+aux );
		//	Debug.Log("distancia "+d);
			px=aux.x/d;
			py=aux.y/d;
			if(d!=0){
			Debug.Log("px "+px);
			Debug.Log("py "+py);
			if(moveSoft.getLmitActive){
			moveSoft.setDir*=-1;
				moveSoft.getLmitActive=false;
			}
			//moveSoft.SetDirec(dx,dy);
			aux2.x=Mathf.Abs(px);
			aux2.y=Mathf.Abs(py);
		//	return aux2;
			}else{
				Debug.Log("mismo vector");
				px=0;
				py=1;
			}
			}else{
			
			px=0;
			py=1;
			aux2.x=px;
			aux2.y=py;
		
		//	return aux2;
		}
	
		moveSoft.onClickUp(px,py);
	
	}



}
