
using UnityEngine;

public class ViewSprite : MonoBehaviour {

	private SpriteRenderer spr;
	void Awake () {
		spr=GetComponent<SpriteRenderer>();
	}
	public void SetOnMySprite(){
		spr.enabled=true;
	}
	public void setOffMySprite(){
		spr.enabled=false;
	}


}
