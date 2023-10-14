using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting;
using UnityEngine;

public class CameraLevelTp : MonoBehaviour
{
    private Transform coord;
    private ManagerLevel managerLevel;

    void Start()
    {
        managerLevel = GameObject.Find("LevelManager").GetComponent<ManagerLevel>();
        coord = GetComponent<Transform>();

        coord.position = managerLevel.getCoordCamera[VariableGlobale.indLevel].position;
    }

    public void niveauSuivant()
    {
        coord.position = managerLevel.getCoordCamera[VariableGlobale.indLevel].position;
    }
}
