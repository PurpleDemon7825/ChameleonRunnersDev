using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAddLetter : MonoBehaviour
{
    public RoomScript roomScript;
    public string Handtag;
    public string Letter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == Handtag)
        {
            roomScript.RoomVar += Letter;
        }
    }
}
