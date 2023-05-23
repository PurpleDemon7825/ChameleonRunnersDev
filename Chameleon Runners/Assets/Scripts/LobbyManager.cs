using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Collider lobbyCollider;
    [SerializeField] private Recorder recorder;

    private bool isInLobby = false;
    private Room currentRoom = null;
    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        boxCollider.size = new Vector3(2, 2, 2); // Set the size of the collider as needed
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isInLobby && other == boxCollider)
        {
            ConnectToPhoton();
            isInLobby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isInLobby && other == boxCollider)
        {
            if (currentRoom != null)
            {
                LeaveRoom();
            }
            DisconnectFromPhoton();
            isInLobby = false;
        }
    }

    private void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        if (PhotonNetwork.CountOfRooms == 0)
        {
            CreateRoom();
        }
        else
        {
            JoinNonFullRoom();
        }
    }

    private void JoinNonFullRoom()
    {
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        RoomInfo bestRoom = null;
        int maxPlayers = 0;

        foreach (RoomInfo room in rooms)
        {
            if (!room.IsFull && room.MaxPlayers >= 15 && room.PlayerCount > maxPlayers)
            {
                bestRoom = room;
                maxPlayers = room.PlayerCount;
            }
        }

        if (bestRoom != null)
        {
            PhotonNetwork.JoinRoom(bestRoom.Name);
        }
        else
        {
            CreateRoom();
        }
    }

    private void CreateRoom()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 15;

        PhotonNetwork.CreateRoom(null, options);
    }

    public override void OnJoinedRoom()
    {
        currentRoom = PhotonNetwork.CurrentRoom;

        // Set up voice chat
        if (recorder != null)
        {
            // Set the recorder's source to the Photon Voice audio source
            recorder.SourceType = Recorder.InputSourceType.Mic;
            recorder.AudioClipCapture.StartRecording();
        }
    }

    private void LeaveRoom()
    {
        if (recorder != null)
        {
            // Stop recording and dispose of the audio clip
            recorder.AudioClipCapture.StopRecording();
            recorder.AudioClipCapture.Dispose();
        }

        PhotonNetwork.LeaveRoom();
        currentRoom = null;
    }

    public override void OnLeftRoom()
    {
        currentRoom = null;
    }

    private void DisconnectFromPhoton()
    {
        PhotonNetwork.Disconnect();
    }
}
