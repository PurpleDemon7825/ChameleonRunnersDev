using UnityEngine;
using Photon.VR;

public class JoinRoom : MonoBehaviour
{
    public RoomScript roomScript;

    public string Handtag;
    private string roomcode;


    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Handtag)
        {
            //Join code:
            roomcode = roomScript.RoomVar;
            int maxPlayers = 10;
            PhotonVRManager.JoinPrivateRoom(roomcode, maxPlayers);
        }
    }
}
