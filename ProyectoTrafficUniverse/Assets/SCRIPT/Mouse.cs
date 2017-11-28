using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

	private GameObject spriteDown;
	private Timer timer;
	public float appearSD;
	public float appearSD2;

	public float timeAppearId;
	public float timeplayer;
	private int index=0;
	public GameObject []players;
	//public InputMouse inputMouse;
	public MovePointer movePointer;
	private GameObject currentPLayer;
	public float PersuitAgain;

	private Vector2 myPosTargetPMouse;
	private int index2=0;
	void Awake () {
		timer=new Timer(appearSD);
		spriteDown=transform.GetChild(0).gameObject;
		print("my child "+spriteDown);
		index2=0;
		currentPLayer=players[index2];
		myPosTargetPMouse=currentPLayer.GetComponent<InputMouse>().getMyPosPointer;
		timer.StartTime=true;
	}
	void Start(){
		timer.finishing+=OnFinish;
		Events();
	}
	void Events(){
		
		currentPLayer.GetComponent<InputMouse>().activeState+=OnActive;

		index=0;

	}
//	// Update is called once per frame
	void Update () {
		timer.MyUpdate();
	}
	private void OnFinish(){
		switch(index)
		{
		case 0:
			print("empiezo a rodar");
			spriteDown.SetActive(true);
			currentPLayer.GetComponent<InputMouse>().ActiveId();
			timer.setTargetTime=timeAppearId;
			movePointer.setMyTarget=myPosTargetPMouse;
			Reset();//reestep variables booleanas del timer y aumento el index para q pasae a la siguiente fase
			break;
		case 1:
			print("aparece id");
			spriteDown.SetActive(false);
		
			timer.setTargetTime=PersuitAgain;
			Reset();
			break;
		case 2:
			print("posicion cercana ");
			movePointer.setMyTarget=currentPLayer.GetComponent<Transform>().position;

			break;
		case 3:
			//aparece sprite down
			print("paso 3 target down");
			spriteDown.SetActive(true);
			timer.setTargetTime=timeplayer;
			Reset();
			break;

		case 4:
			//activo componentes del player y del path para q se muevan
			currentPLayer.GetComponent<MoveHowToPlay>().enabled=true;
			currentPLayer.GetComponent<AnimationPath>().enabled=true;
			break;
		}



	}
	private void OnActive(){
		timer.setTargetTime=appearSD2;
		Reset();

	}
	private void Reset(){
		timer.finishTime=false;
		timer.StartTime=true;
		index++;
	}
	public void setValues(){
		
		index2++;
		currentPLayer=players[index2];
		myPosTargetPMouse=currentPLayer.GetComponent<InputMouse>().getMyPosPointer;
		Events();

	}
	public void setMyStartTime(){
		
			timer.StartTime=true;
	
	}
}
