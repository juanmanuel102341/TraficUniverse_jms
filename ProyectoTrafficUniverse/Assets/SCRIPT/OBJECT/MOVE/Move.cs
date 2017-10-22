
using UnityEngine;
public class Move:MonoBehaviour {
	protected Rigidbody2D rb;
	public float velocity;
	MoveFirst moveFirst;
	private MovePath movePath;
//	MoveWhithoutPath moveWhithoutPath;
	protected PathInputs pathInputs;
	protected Bounds bounds;
	private Vector2 finalVec;
	private int direction=1;
	private bool activate=false;

	void Awake () {
		rb=GetComponent<Rigidbody2D>();
		//print("rb move "+rb);
		bounds=GetComponent<Bounds>();
		pathInputs=GetComponent<PathInputs>();
		moveFirst=new MoveFirst();

		movePath=new MovePath();
		//no se como diferenciar la lista d nodos de path inputs de la q tengo en move path, para n andar pasando nose frame a frame innceserios
//		moveWhithoutPath=GetComponent<MoveWhithoutPath>();
	
//		moveWhithoutPath.enabled=false;
		}
	void Update () {
		if(pathInputs.path.listNodes.Count>0){
			//path activo
			//****************momento path*****************************
			if(activate==false){
				activate=SetInputsMovePath();
		
			}
			movePath.posPlayer=transform.position;
			transform.localPosition=Vector2.MoveTowards(transform.position,movePath.GetVecDirection(),1);
			print(" movePath.direction"+movePath.GetVecDirection() );
		}else{
			//******************momento inicial sin nodos**************************
					//			print("idle");
					Move_Idle();
					
				}
		}
	private void Move_Idle(){
		Direction();
		transform.Translate(moveFirst.MoveIdle()*direction* velocity*Time.deltaTime);
		}

	public Vector2 getFinalVec{
		get{
			return finalVec;
		}
		set{
			finalVec=value;
		}
	}
	public PathInputs getPathInputs{
		get{
			return pathInputs;
		}
	}
	public void Direction(){
		if(bounds.limiteActive){
	//		print("limite idle");
			bounds.limiteActive=false;
			transform.up=-transform.up;//cambio vector por el sentido contrario
		}

	
	}
	private bool SetInputsMovePath(){
		//metodo q le pasa la lista de nodos y la posicion del player a la clase move path
		for(int i=0;i<pathInputs.path.listNodes.Count;i++){
			//	print("nodo "+pathInputs.path.listNodes[i].posicion);
			//	listVec.Add(pathInputs.path.listNodes[i].posicion);
			movePath.list_Vec.Add(pathInputs.path.listNodes[i].posicion);
		}
		return true;

	}
}
