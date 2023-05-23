using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackspaceScript : MonoBehaviour
{
    public NameScript NameScript;
    public string HandTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == HandTag)
        {
            NameScript.NameVar = NameScript.NameVar.Remove(NameScript.NameVar.Length - 1);
        }
    }
}
