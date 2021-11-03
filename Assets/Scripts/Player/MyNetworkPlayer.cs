using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro; 

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar(hook = nameof(HandlerDisplayNameUpdated))]
    [SerializeField]
    string displayName = "Missing Name";

    [SyncVar(hook = nameof(HandlerDisplayColorUpdated))]
    [SerializeField]
    Color displayColor;

    [SerializeField]
    TextMeshPro pro; 

    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName; 
    }



    [SerializeField]
    Renderer render;
    [Server]
    public void SetColor(Color newColor)
    {
        displayColor = newColor; 
    }


    /*
    //Llamar funcion desde el editor
    [ContextMenu("UpdateColor")]
    private void UpdateColor()
    {
        displayColor = Color.black;
    }
    */

    private void HandlerDisplayColorUpdated(Color oldColour, Color newColour)
    {
        Debug.Log(newColour); 
        render.material.SetColor("_Color", newColour);
    }


    private void HandlerDisplayNameUpdated(string oldValue, string newValue)
    {
        pro.text = newValue; 

    }


}