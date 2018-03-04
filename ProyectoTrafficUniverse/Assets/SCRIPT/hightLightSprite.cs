
using UnityEngine;
using UnityEngine.UI;
public class hightLightSprite : MonoBehaviour {
	private Sprite spriteOff;
	private Sprite spriteOn;
	private Image image;
	public hightLightSprite [] other;
	private bool onState=true;
	public delegate void ActiveState(string state);
	public event ActiveState onActiveState;

	void Awake () {
		image=GetComponent<Image>();
		spriteOn=GetComponent<Button>().spriteState.pressedSprite;
		spriteOff=image.sprite;

		//		if(gameObject.tag=="on"){
//			onState=true;
//		}
//	
	}
	public void Click(){
		SetSpriteOn();
		for(int i=0;i<other.Length;i++){
			if(other[i].getOnState){
				other[i].SetSpriteOff();	
			}	
		}
		print("activando estado ");
		onActiveState(gameObject.name);

	}
	public void SetSpriteOn(){
		image.sprite=spriteOn;
		onState=true;
	}
	public void SetSpriteOff(){
		image.sprite=spriteOff;
		onState=false;
	}
	public bool getOnState{
		get{
			return onState;
		}
	}
}
