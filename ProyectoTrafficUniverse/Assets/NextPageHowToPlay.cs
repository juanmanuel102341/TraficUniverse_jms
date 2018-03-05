using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPageHowToPlay : MonoBehaviour {

	public GameObject [] worldScene;
	public GameObject [] guiScene;
	int index=0;
	public delegate void FinishPage();
	public event FinishPage onFinish;
	public event FinishPage onBack;
	private bool final=false;

	void Awake () {
		worldScene[index].SetActive(true);
		guiScene[index].SetActive(true);
		index=0;
	}
	public void ApplyNext(){
		if(index<worldScene.Length-1){
		print("apply next");
		worldScene[index].SetActive(false);
		guiScene[index].SetActive(false);
		index++;
		worldScene[index].SetActive(true);
		guiScene[index].SetActive(true);
		if(index==worldScene.Length-1){
			onFinish();
				final=true;
			}
		}else{
			print("error pagina ultima no puedes avanzar mas");
		}
	}

	public void ApplyBack(){
		if(index>0){
			if(final){
				onBack();
				final=false;

			}
		
		worldScene[index].SetActive(false);
		guiScene[index].SetActive(false);

		index--;

		worldScene[index].SetActive(true);
		guiScene[index].SetActive(true);
		}else{
			print("error pagina primera no puedo ir mas para atras");
		}
	}
}
