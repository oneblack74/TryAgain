using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpDoor : MonoBehaviour
{

    [SerializeField] private Transform coordSpawn;
    [SerializeField] private Transform player;
    [SerializeField] private CameraLevelTp cameraLevelTp;

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

        player.position = coordSpawn.position;
        

        // Attendre pendant 1 seconde
        yield return new WaitForSeconds(2f);

        // Mettre la variable VariableGlobale.jeuEnPause à false
        VariableGlobale.jeuEnPause = false;
    }
}
