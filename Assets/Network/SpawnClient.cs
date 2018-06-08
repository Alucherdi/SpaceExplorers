using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

//Basically, what ": NetworkManager" does is overwriting that very same component (NetworkManager). That means, we have control of networkManager manually
public class SpawnClient : NetworkManager {
	
	//public Transform spawnPosition;

	//0 --> Leo23    1 --> Ek    2 --> Kaleb
	//Add more players if needed (and add an additional function for the canvas button

	[HideInInspector] public int curPlayer = 0;		//DEFAULT Leo23
	public GameObject[] allPlayerPrefabs;
	
	
	//Called on client when connect
	public override void OnClientConnect(NetworkConnection conn) {       
		
		// Create message to set the player
		IntegerMessage msg = new IntegerMessage(curPlayer);      
		
		// Call Add player and pass the message
		ClientScene.AddPlayer(conn,0, msg);
	}
	
	// Server
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader )
	{
		int theIndex = 0;
		
		// Read client message and receive index
		if (extraMessageReader != null)
		{
			IntegerMessage stream = extraMessageReader.ReadMessage<IntegerMessage> ();
			theIndex = stream.value;
		}       
		
		// Create player object with prefab
		GameObject newClient = Instantiate (allPlayerPrefabs [theIndex], FindObjectOfType<NetworkStartPosition>().GetComponent<Transform>().position, Quaternion.identity);
		
		// Add player object for connection
		NetworkServer.AddPlayerForConnection(conn, newClient, playerControllerId);
	}
	
	
	public void GetLeo23()
	{
		curPlayer = 0;
		CharacterMenuController.instance.Leo23Selection ();
	}
	
	public void GetEk()
	{
		curPlayer = 1;
		CharacterMenuController.instance.EkSelection ();
	}
	
	public void GetKaleb()
	{
		curPlayer = 2;
		CharacterMenuController.instance.KalebDuneSelection ();
	}

	public void GetMatsumoto()
	{
		curPlayer = 3;
		CharacterMenuController.instance.MatsumotoSelection ();
	}

	public void GetNone()
	{
		curPlayer = 4;
		CharacterMenuController.instance.NoPlayerSelection ();
	}
}
