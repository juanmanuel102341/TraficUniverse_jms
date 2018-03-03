
using UnityEngine;

public class IdInicial : MonoBehaviour {

	public GameObject sprite;
	private float timer;
	public float timeId; 
	private GameObject mySprite;
	private float separateY;
	private float separateX;
	private float magnitudY=3;
	private float magnitudX=5;
	private string posInitial;
	public delegate void mySound();
	public event mySound onMySound;
	void Update () {
		timer+=Time.deltaTime;
		if(timer>timeId){
//			print("tiempo id sprite cumplido");
			DestroySprite();

			timer=0;
		}
		mySprite.transform.position=new Vector2(transform.position.x+separateX,transform.position.y+separateY);
		///etMySprite(posInitial);
//		print("'pos id "+posInitial);
	}
	public void SetMySprite(string pos){
		posInitial=pos;
//		print("'pos id "+posInitial);
//		print("sprite "+sprite);
		mySprite=Instantiate(sprite,transform.position,transform.rotation);
		if(MyParams.soundActive){
		onMySound();
		}

		switch(pos){
		case "up":
			separateX=0;
			separateY=-magnitudY;
			break;
		case "down":
			separateX=0;
			separateY=magnitudY;
			break;

		case "left":
			separateX=magnitudX;
			separateY=0;
			break;
		case "right":
			separateX=-magnitudX;
			separateY=0;
			break;
		}

	}
	public void DestroySprite(){
		Destroy(mySprite);
		Destroy(this);
	}
}
