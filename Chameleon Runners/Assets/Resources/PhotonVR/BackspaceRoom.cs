using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackspaceRoom : MonoBehaviour
{
    public RoomScript RoomScript;
    public string HandTag;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == HandTag)
        {
            RoomScript.RoomVar = RoomScript.RoomVar.Remove(RoomScript.RoomVar.Length - 1);
        }
    }
}
