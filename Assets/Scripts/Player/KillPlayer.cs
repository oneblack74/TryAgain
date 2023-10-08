using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    [SerializeField] private Transform coordStart;
    [SerializeField] private Transform player;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            player.position = coordStart.position ;
        }
    }
}
