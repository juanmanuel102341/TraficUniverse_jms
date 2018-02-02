using UnityEngine.UI;
using UnityEngine;

public class EnabledLevel : MonoBehaviour {
	public Sprite mySprite;
	private Image image;
	private Button button;
	// Use this for initialization
	void Awake () {
		image=GetComponent<Image>();
		button=GetComponent<Button>();
	}
	public void ApplyLevel(){
		image.sprite=mySprite;
		button.enabled=true;
	}
}
