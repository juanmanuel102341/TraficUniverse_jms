
using UnityEngine;

public class SpawnNode : MonoBehaviour {
	public GameObject node;
	private float time;
	public float frame;
	private Vector2 vec;
	public float total;

	// Use this for initialization
	private int cont=0;
	void Start () {
		vec=this.transform.position;
		print("vec "+vec);
	}
	
	// Update is called once per frame
	void Update () {
		time+=Time.deltaTime;
	
		if(time>frame&&cont<total){
			
			Instantiate(node,vec,transform.rotation);
			vec.x+=1;
			vec.y+=1;
			cont++;
			time=0;
		}
			

	}
}
