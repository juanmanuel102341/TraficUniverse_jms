using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPath {
	private List<GameObject>listGraphics=new List<GameObject>();
	private List<Vector2>listVectors=new List<Vector2>();

	private List<Path>listPaths=new List<Path>();
	void Start () {
		
	}
	public void InsertPathGrapchicList(List<GameObject> l){
		for(int i=0;i<l.Count;i++){
			listGraphics.Add(l[i]);
		}
		Debug.Log("numero elementos "+listGraphics.Count);
	}
	public void InsertPath(Path p){
		listPaths.Add(p);
	}
	public void InsertPathVectorsList(List<Vector2> l){
		for(int i=0;i<l.Count;i++){
			listVectors.Add(l[i]);

		}
//		listVectors.Add(l);
		Debug.Log("numero vectores elem "+listVectors.Count);
	}
	public void RemovePathGrapicList(){
		for(int i=0;i<listGraphics.Count;i++){
			GameObject aux=listGraphics[i];
//			aux.GetComponent<PathGraphic>().Delete_ngraphics();

		}
	}
	public void DeleteMyElementGraphic(GameObject obj){
		
		listGraphics.Remove(obj);
	}
	public List<GameObject>getListGraphic{
		get{
			return listGraphics;
		}
	}
	public void RemovePaths(){
		for(int i=0;i<listPaths.Count;i++){
			listPaths[i].Delete();
		}
	}
}
