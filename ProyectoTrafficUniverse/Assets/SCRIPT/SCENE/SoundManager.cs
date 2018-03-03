
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private AlertColision alertColision;
	public DetectsId detectsId;
	public Pause pause;
	public FastTime fastTime;
//	public AudioClip attention;
//	public AudioClip clickMe;
//	public AudioClip explosion;
//	public AudioClip landing;
	public AudioClip loosee;
	public AudioClip win;
	public AudioClip speedUp;
	public AudioClip speedNormal;
	private GameManager gameManager;
	public AudioSource []audioSources;

	void Awake () {
	//	audioSource=GetComponent<AudioSource>();
		//audioSource.clip=attention;
		if(MyParams.soundActive){
		gameManager=GameObject.FindGameObjectWithTag("gameManager_tag").GetComponent<GameManager>();
		gameManager.onFinalLoose+=onLoose;
		gameManager.onFinalWin+=onWin;
		}
	}
	void Start(){
		if(MyParams.soundActive){
		detectsId.OnclickSound+=OnClickMe;
		pause.pauseOff+=OnPaseOn;
		fastTime.speedUp+=OnSpeedUp;
		fastTime.speedNormal+=OnSpeedNormal;
		}else{
		//	this.gameObject.SetActive(false);
		}
	}
	
	public void Events(GameObject obj){
		
		AlertColision alert =obj.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<AlertColision>();
		Detect detect=obj.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Detect>();//hijo del hijo
		IdInicial idInitial=obj.GetComponent<IdInicial>();
		//print("OBJ "+alert);
//		print("detect "+detect);
		alert.onAlertColsion+=OnContactPlanes;
		detect.OnContactPlane+=OnContactDestroy;
		detect.OnContactTarget+=OnContactLanding;
		idInitial.onMySound+=OnInitialOut;
	
	}
	//alert, alert inm,pause,explosion,click,aterrizar,timer
	private void OnInitialOut(){
		audioSources[0].Play();

	}
	private void OnContactPlanes(){
		print("sonidoo aviones colision");
		audioSources[1].Play();
	}
	private void OnPaseOn(){
		audioSources[2].Play();
	}

	private void OnContactDestroy(){
		print("destroy sound!!!!!!!!!!!!!!!!!!!");	
		audioSources[3].Play();
	}
	private void OnClickMe(){
		print("click me");
		audioSources[4].Play();
	}
	private void OnContactLanding(){
		print("landing");
		audioSources[5].Play();
		}

	private void OnSpeedNormal(){
		print("sonido normal");
		audioSources[6].clip=speedNormal;
		audioSources[6].Play();
	}
	private void OnSpeedUp(){
		print("sonido speed up");
		audioSources[6].clip=speedUp;
		audioSources[6].Play();
	}
	private void onLoose(){
		audioSources[7].clip=loosee;
		audioSources[7].Play();

	}
	private void onWin(){
		audioSources[7].clip=win;
		audioSources[7].Play();
	}


}
