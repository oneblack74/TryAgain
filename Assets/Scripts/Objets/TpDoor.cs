using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpDoor : MonoBehaviour
{

    private Transform player;
    private CameraLevelTp cameraLevelTp;
    private ManagerLevel managerLevel;

    void Start()
    {
        managerLevel = GameObject.Find("LevelManager").GetComponent<ManagerLevel>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        cameraLevelTp = GameObject.Find("MainCamera").GetComponent<CameraLevelTp>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TeleportAndPause());
        }
    }

    private IEnumerator TeleportAndPause()
    {
        // Mettre la variable VariableGlobale.jeuEnPause à true
        VariableGlobale.jeuEnPause = true;

        // Téléporter le joueur au départ (pour le niveau suivant)
        
        if (VariableGlobale.indLevel < VariableGlobale.maxIndLevel - 1)
        {
            VariableGlobale.indLevel++;
        }

        cameraLevelTp.niveauSuivant();

        player.position = managerLevel.getCoordSpawnPlayer[VariableGlobale.indLevel].position;
        

        // Attendre pendant 1 seconde
        yield return new WaitForSeconds(2f);

        // Mettre la variable VariableGlobale.jeuEnPause à false
        VariableGlobale.jeuEnPause = false;
    }
}
