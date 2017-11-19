
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private AlertColision alertColision;
	public DetectsId detectsId;
	public AudioClip attention;
	public AudioClip clickMe;
	public AudioClip explosion;
	public AudioClip landing;
	private AudioSource audioSourde;

	void Awake () {
		audioSourde=GetComponent<AudioSource>();
		audioSourde.clip=attention;
	}
	void Start(){
		detectsId.OnclickSound+=OnClickMe;
	}
	
	public void Events(GameObject obj){
		AlertColision alert =obj.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<AlertColision>();
		Detect detect=obj.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Detect>();//hijo del hijo

		print("OBJ "+alert);
		print("detect "+detect);
		alert.onAlertColsion+=OnContactPlanes;
		detect.OnContactPlane+=OnContactDestroy;
		detect.OnContactTarget+=OnContactLanding;
	}
	
	private void OnContactPlanes(){
		print("aviones colision");
		audioSourde.clip=attention;
		audioSourde.Play();
	}
	private void OnClickMe(){
		print("click me");
		audioSourde.clip=clickMe;
		audioSourde.Play();
	}
	private void OnContactDestroy(){
		print("destroy sound!!!!!!!!!!!!!!!!!!!");	
		audioSourde.clip=explosion;
		if(!audioSourde.isPlaying)
		audioSourde.Play();

	}
	private void OnContactLanding(){
		print("landing");
		audioSourde.clip=landing;
		if(!audioSourde.isPlaying)
			audioSourde.Play();
		}

}
