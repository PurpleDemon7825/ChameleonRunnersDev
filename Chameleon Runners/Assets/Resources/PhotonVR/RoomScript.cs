using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.VR;
using TMPro;

public class RoomScript : MonoBehaviour
{
    public string RoomVar;
    public TextMeshPro RoomText;
    private void Update()
    {
    if(RoomVar.Length > 12)
    {
        RoomVar = RoomVar.Substring(0, 12);
    }
    RoomText.text = RoomVar;
    }
}
