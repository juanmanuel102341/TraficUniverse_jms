
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NodeMovement : MonoBehaviour {
	
	public GameObject target;
	public GameObject node;
	public float velocity;
	public float rateNode;
	private float time;
	private List<GameObject> listNodes=new List<GameObject>();
	private List<Vector2> posListNodes=new List<Vector2>();
	// Use this for initialization
	public delegate void activeMove(List<Vector2>l);
	public event activeMove active;
	public event activeMove activePointer;
	private Vector2 initialPos;
	//public GameObject puntero;
	void Awake () {
		initialPos=transform.position;
	
	
	}
	//pensar mejjor el codigo separa parte de coidgo de la grafica tratar de ver si puedo aplicar herencia, como esta ahora es poco eficiente, le estoy pasando una lista n nodos frame a frame
	//lo mismo con el puntero
	void Update () {
		time+=Time.deltaTime;
	
		transform.position=Vector2.MoveTowards(transform.position,target.GetComponent<Transform>().position,velocity*Time.deltaTime);

		//transform.Translate(Vector2.right*Time.deltaTime);
//		print("pos "+transform.position);
		if(time>rateNode&&Vector2.Distance(transform.position,target.GetComponent<Transform>().position)>0){
			GameObject obj= Instantiate(node,transform.position,transform.rotation);
			listNodes.Add(obj);
//			for(int i=0;i<listNodes.Count;i++){
//				print("pos"+i+": "+listNodes[i]);	
//			}
		//	activePointer(
			time=0;
		}else if (Vector2.Distance(transform.position,target.GetComponent<Transform>().position)<=0){
			time=0;	
		//	print("fin");
			if(posListNodes.Count==0){
				posListNodes=GetPositionListOfGameObect(listNodes);
			}
			if(posListNodes.Count>0)
			active(posListNodes);
		}
	}
	public void DeleteNodesGraphic(){
		for(int i=0;i<listNodes.Count;i++){
			GameObject aux=listNodes[i];
			Destroy(aux);
		}
		print("cant nodos "+listNodes.Count);
		Destroy(target);
		Destroy(this.gameObject);//destruyo

	}
				private List<Vector2> GetPositionListOfGameObect(List<GameObject>listGameObj){
		//paso la data de posicion d los game objects a una lista de vector 2 para pasarsela a moveHowTplay 
					print("entrando en convert ");
					List <Vector2>listAux=new List<Vector2>();//entro una vez
					for(int i=0;i<listGameObj.Count;i++){
						listAux.Add(listGameObj[i].GetComponent<Transform>().position);
					}
					return listAux;
		}
		public void DeleteNodesData(){
		
		posListNodes.RemoveRange(0,posListNodes.Count);
		print("cant data pos "+posListNodes.Count);
		}
//	public void Reset(){
//		transform.position=initialPos;
//
//	}
}
