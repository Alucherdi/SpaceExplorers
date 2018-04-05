using UnityEngine;
using UnityEngine.Networking;


public class PlayerSetup : NetworkBehaviour{
   
	[SerializeField]
	public Behaviour[] componentsToDisable;

	void Start(){
		// Disable components
		if(!isLocalPlayer)
		{
			for(int i=0; i<componentsToDisable.Length; i++)
			{
				componentsToDisable [i].enabled = false;
			}
		}
	}


}
