using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLevel : MonoBehaviour
{
    [SerializeField] private Transform[] coordSpawnPlayer;
    [SerializeField] private Transform[] coordCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform cam;

    void Start()
    {
        VariableGlobale.indLevel = 0;

    }
    public void passerLevel()
    {
        if (VariableGlobale.indLevel < VariableGlobale.maxIndLevel - 1)
        {
            VariableGlobale.indLevel++;
        }
    }


    public virtual Transform[] getCoordSpawnPlayer
    {
        get { return coordSpawnPlayer;}
    }

    public virtual Transform[] getCoordCamera
    {
        get { return coordCamera;}
    }
}
