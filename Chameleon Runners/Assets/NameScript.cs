using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.VR;
using TMPro;
public class NameScript : MonoBehaviour
{
    public string NameVar;
    public TextMeshPro NameText;
    private void Update()
    {
        if (NameVar.Length > 12)
        {
            NameVar = NameVar.Substring(0, 12);
        }
        NameText.text = NameVar;
        PhotonVRManager.SetUsername(NameVar);
    }
}
