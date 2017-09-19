
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static int aterrizajes=0;
	public static  int vidas=3;
	public static int aviones=0;
	public GameObject guiLoose;
	public GameObject guiWin;
	public int targetPlanes;
	public SpawnManager spawnManager;
	public GameObject target;
	private int initialVidas;
	private int initialTarget;
	public GameObject guiGame;
	public GameObject buttonWin;
	public GameObject buttonLoose;

	void Awake () {
		initialVidas=vidas;
		initialTarget=targetPlanes;
	}
	void Start(){
		Replay.activateReplay+=OnReplay;	
	}
	

	void Update () {
		if(aviones==2){
			print("puf aviones muertos");
			vidas--;
			aviones=0;
		}
		Conditions();
	}
	private void Conditions(){
		if(vidas<=0){
			print("loose");
			Reset();
			buttonLoose.SetActive(true);
			guiLoose.SetActive(true);
		
		}else if(aterrizajes>=targetPlanes){

			print("victory");
			Reset();
			buttonWin.SetActive(true);
			guiWin.SetActive(true);
		}
	}
	private void Reset(){
	//primero borrar objetos despues listas
		//destruccion de naves y sus paths si los hay
		for(int i=0;i<spawnManager.getListaNaves.Count;i++){
			GameObject obj=spawnManager.getListaNaves[i];//obtenemos objeto
			for(int i2=0;i2<obj.GetComponent<Path>().getListSprite.Count;i2++){
				GameObject auxSpritePath=obj.GetComponent<Path>().getListSprite[i2];//destruimos el path
				Destroy(auxSpritePath);
			
			}
			if(obj.GetComponent<Path>().getPathVectors.Count>0){
				obj.GetComponent<Path>().getPathVectors.RemoveRange(0,obj.GetComponent<Path>().getPathVectors.Count);//vaciamos la lista
				obj.GetComponent<Path>().getListSprite.RemoveRange(0,obj.GetComponent<Path>().getListSprite.Count);
			}

			Destroy(obj);//destruccion nave
		}
		if(spawnManager.getListaNaves.Count>0){
			spawnManager.getListaNaves.RemoveRange(0,spawnManager.getListaNaves.Count);//vacio lista d naves
		}
	

	
		target.SetActive(false);
		spawnManager.enabled=false;
		guiGame.SetActive(false);
	}
	private void OnReplay(){
		print("replay new");
		if(buttonLoose.activeSelf){
			print("button loose deacctiva");
			buttonLoose.SetActive(false);
			guiLoose.SetActive(false);
		}else{
			print("button win deactive");
			buttonWin.SetActive(false);
			guiWin.SetActive(false);
		}
		targetPlanes=initialTarget;//reseteo aviones
		aterrizajes=0;//reseteo aterrizajes para no volver a ganar
		vidas=initialVidas;//reseteo vidas
		target.SetActive(true);
		spawnManager.enabled=true;
		guiGame.SetActive(true);
	}
	private void SpawnVictoriaGui(){
		
	}
		
}
