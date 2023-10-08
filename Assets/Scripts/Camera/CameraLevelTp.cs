using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevelTp : MonoBehaviour
{
    [SerializeField] private Transform[] coordLevel;
    [SerializeField] private Transform coord;

    // Start is called before the first frame update
    void Start()
    {
        VariableGlobale.indLevel = 0;
        coord.position = coordLevel[VariableGlobale.indLevel].position;
    }

    public void niveauSuivant()
    {
        coord.position = coordLevel[VariableGlobale.indLevel].position;
    }
}
