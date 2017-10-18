using UnityEngine;
public class MovePath : MonoBehaviour {
	private int index=0;
	private Move move;
	private int direccion=1;
	private Bounds bounds;
	void Awake () {
		//	pathInput=GetComponent<PathInputs>();
		move=GetComponent<Move>();
		bounds=GetComponent<Bounds>();
	}

	void Update () {
		if(move.getPathInputs.path.listNodes.Count>0){
			if(!bounds.limiteActive){
				Move_01();
				ChangeIndexPath();	
			}else{
				//limite activo , path "dentro" del limite, borro paths, entra en juego moveWhithouth path q "cambia de sentido"
				move.getFinalVec=CalcFinal();//guardamos data del ultimo vector y lo setiemos
				GetComponent<Delete>().DeleteNodes();
				bounds.limiteActive=false;
				index=0;
			}
		}
	}
	public void ChangeIndexPath(){
		//		print("nodo desde move path  "+pathInputs.path.listNodos[index]);
		//		print("index "+index);
		if(Vector2.Distance(move.getPathInputs.path.listNodes[index].posicion,transform.position)<=0){
			if(index<move.getPathInputs.path.listNodes.Count-1){
				index++;			
				//print("cambio indice");
			}else if(index==move.getPathInputs.path.listNodes.Count-1){
				//borro nodos
				move.getFinalVec=CalcFinal();//guardamo data del ultimo vector y lo setiemos
				GetComponent<Delete>().DeleteNodes();//borro nodos
				index=0;
			}
		}

	}
	private Vector2 CalcFinal(){
		//metodo publico asi puedo accede desde path inputs y obtener el vectir apropiado cuando clickea de nuevo el usuario sobre y genera otro path
		Vector2 aux;
		if(move.getPathInputs.path.listNodes.Count>1){
			//si hay 2 entras, calculo de diferencia de nodos entre el ultimo y anteultimo, obteniendo el vector correspondiente
			aux=move.getPathInputs.path.listNodes[move.getPathInputs.path.listNodes.Count-1].posicion-move.getPathInputs.path.listNodes[move.getPathInputs.path.listNodes.Count-2].posicion;
			//print("vec final "+aux);
			return aux;
		}else{
			print("vec final menos d 1 ");
			Vector2 aux2;
			aux2.x=transform.position.x;//busco posicion x e y
			aux2.y=transform.position.y;

			aux=aux2-move.getPathInputs.path.listNodes[0].posicion;
			print("pos player "+aux2);
			print("vec path "+move.getPathInputs.path.listNodes[0].posicion);
			print("pos player "+aux);
			return aux;
		}
	}
	private void Move_01(){
		transform.position=Vector2.MoveTowards(transform.position,move.getPathInputs.path.listNodes[index].posicion,move.velocity*Time.deltaTime*direccion);
		transform.up=VecDirection();
	}
	private Vector2 VecDirection(){
		Vector2 posPlayer;
		Vector2 target;
		Vector2 r;
		posPlayer.x=transform.position.x;
		posPlayer.y=transform.position.y;
		target=move.getPathInputs.path.listNodes[index].posicion;
		r=target-posPlayer;
		//		print("posplayer "+posPlayer);
		//print("target "+target);
		//print("res "+r);
		return r;
	}
	public int setIndex{
		set{
			index=value;//viene de path inputs cuando clickea usuario y se borran los nodos
		}
	}
	public Vector2 getCurrentVector{
		get{
			return VecDirection();
		}
	}

}
