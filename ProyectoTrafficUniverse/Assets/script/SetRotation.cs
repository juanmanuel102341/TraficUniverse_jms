
using UnityEngine;

public class SetRotation : MonoBehaviour {

	public Bounds bounds;
	private float currentRotation=0;
	private bool apply=false;
	private float widhtObj;
	void Awake () {
		apply=true;
		widhtObj=GetComponent<SpriteRenderer>().bounds.size.x;
		print("width "+widhtObj);
		currentRotation=0;
	}
	

	void Update () {
		if(bounds.limiteActive){
			ChangeRotation(bounds.idLimite);
		}
		if(apply){
		RotateObject();
		apply=false;
		}
		}
	private void RotateObject(){
		transform.Rotate(new Vector3(0,0,currentRotation));
		apply=false;
	}
	private void ChangeRotation(string _id){
		switch(_id)
		{

		case "up":
			transform.position=new Vector3(transform.position.x,bounds.lHeight_up,transform.position.z);
			apply=true;
			currentRotation=Random.Range(90,250);
		
			print("rot up "+currentRotation);
			print("transform y "+transform.position.y);

			break;
		case "down":
			transform.position=new Vector3(transform.position.x,bounds.lHeight_down,transform.position.z);
			apply=true;
			print("transform y "+transform.position.y);
			float n1=Random.Range(270,340);//aplico rotacion para un lado 
			float n2=Random.Range(0,80);//aplico para otro
			float r=Random.Range(1,3);//random entre las 2, lo hago por q ni puedo hacer un solo random
			if(r==1){
				currentRotation=n1;
			}else{
				currentRotation=n2;
			}
			print("rot down "+currentRotation);
			break;
		case "left":
			transform.position=new Vector3(bounds.lWidth_izq,transform.position.y,transform.position.z);
			print("rot right "+currentRotation);
			apply=true;
			currentRotation=Random.Range(190,280);
			print("rot left "+currentRotation);
			break;
		case "right":
			transform.position=new Vector3(bounds.lWidth_der,transform.position.y,transform.position.z);
			apply=true;
			print("posicion x "+transform.position.x);
			currentRotation=Random.Range(45,90);
			print("rot right "+currentRotation);

			break;
		}

	}
}
