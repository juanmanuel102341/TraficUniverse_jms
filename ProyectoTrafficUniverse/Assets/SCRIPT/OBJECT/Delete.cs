
using UnityEngine;

public class Delete : MonoBehaviour {


	public void DeleteMe(){
		DeleteNodes();
		Destroy(this.gameObject);
	}
	public void DeleteNodes(){
		PathInputs pathInputs=GetComponent<PathInputs>();
		pathInputs.getMyPrinciplePath.DeleteAllNodes();
			
	}

}
