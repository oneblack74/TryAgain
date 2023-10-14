using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    [SerializeField] private Transform player;
    private ManagerLevel managerLevel;

    void Start()
    {
        managerLevel = GameObject.Find("LevelManager").GetComponent<ManagerLevel>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            player.position = managerLevel.getCoordSpawnPlayer[VariableGlobale.indLevel].position ;
        }
    }
}
