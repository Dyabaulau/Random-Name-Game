using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BestMasterYi
{
    public class NetworkManager : MonoBehaviourPunCallbacks
    {
        public Button ConnectToMaster;
        public Button JoinRandomRoom;

        public bool TriesToConnectToMaster;
        public bool TriesToConnectToRoom;
        
        private string scene = "Stage1";

        public string Scene
        {
            get => scene;
            set => scene = value;
        }
        
            
        void Start()
        {
            DontDestroyOnLoad(gameObject);
            TriesToConnectToMaster = false;
            TriesToConnectToRoom = false;
            scene = PersistantManagerScript.Instance.level;
        }

        // Update is called once per frame
        void Update()
        {
            if(ConnectToMaster!=null)
                ConnectToMaster.gameObject.SetActive(!PhotonNetwork.IsConnected && !TriesToConnectToMaster);
            if (JoinRandomRoom!=null)
                JoinRandomRoom.gameObject.SetActive(PhotonNetwork.IsConnected && !TriesToConnectToMaster && !TriesToConnectToRoom);                        
        }

        public void OnClickToMaster()
        {
            TriesToConnectToMaster = true;
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
            TriesToConnectToMaster = false;
            TriesToConnectToRoom = false;
            Debug.Log(cause);
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            TriesToConnectToMaster = false;
            Debug.Log("Connected to Master!");
        }
        
        public void OnClickConnectToRoom()
        {
            if (!PhotonNetwork.IsConnected)
                return;
            TriesToConnectToRoom = true; 
            
            PhotonNetwork.JoinRandomRoom();               //Join a random Room     - Error: OnJoinRandomRoomFailed  
        }
        
        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            TriesToConnectToRoom = false;
            Debug.Log("Master: " + PhotonNetwork.IsMasterClient + " | Players In Room: " + PhotonNetwork.CurrentRoom.PlayerCount + " | RoomName: " + PhotonNetwork.CurrentRoom.Name);
            PhotonNetwork.LoadLevel(Scene);
        }
         
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            base.OnJoinRandomFailed(returnCode, message);
            //no room available
            //create a room (null as a name means "does not matter")
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
        }
        
        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            base.OnCreateRoomFailed(returnCode, message);
            Debug.Log(message);            
            TriesToConnectToRoom = false;
        }
        
        
        


    }
}
