using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuVisibility : MonoBehaviour
{
    [Header("Re-apparing Object")]
    [Tooltip("Object that have to re-appear when the volume menu is closed")]
    public GameObject[] objectGainingVisibility;
    [Tooltip("Object that have to re-appear when the volume menu is closed")]
    public GameObject[] objectLosingVisibility;
    [Tooltip("Object that have to re-appear when the volume menu is closed")]
    public GameObject options;
    [Tooltip("Object that have to re-appear when the volume menu is closed")]
    public GameObject commands;
   public void SetVisibleMenu(){
        foreach(GameObject obj in objectLosingVisibility)
        {
            obj.SetActive(false);
        }
        foreach(GameObject obj in objectGainingVisibility)
        {
            obj.SetActive(true);
        }
        options.SetActive(true);
    }
    public void CloseMenu(){
        options.SetActive(false);
        foreach(GameObject obj in objectLosingVisibility)
        {
            obj.SetActive(true);
        }
        foreach(GameObject obj in objectGainingVisibility)
        {
            obj.SetActive(false);
        }
    }
    public void SetVisibleCommands(){
        commands.SetActive(true);
    }
    public void CloseCommands(){
        commands.SetActive(false);
    }
}
