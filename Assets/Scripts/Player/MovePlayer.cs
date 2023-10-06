using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private PlayerInput inputs;

    private InputAction moveAction;

    private GameManager manager;
    
    private Vector2 velocity = Vector2.zero;
    [SerializeField] private float speed = 2f;

    private int dir;
    private bool walk;

    [SerializeField] private Animator animator;


    void Start() 
    {
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();

        moveAction = inputs.actions.FindAction("Move");

        dir = 1;
        walk = false;
    }

    private void FixedUpdate()
    {

        // deplacement
        Vector2 _moveValue = moveAction.ReadValue<Vector2>();
        velocity = _moveValue*speed;
        transform.position += new Vector3(velocity.x * Time.fixedDeltaTime, 0, 0);


        // mettre la variable direction à 1 ou -1 (droite ou gauche) en fonction des touches appuyé
        if (_moveValue.x > 0)
        {
            dir = 1;
        }
        else if (_moveValue.x < 0)
        {
            dir = -1;
        }

        // mettre la variable de marche à true ou false
        walk = !(_moveValue[0] == 0 && _moveValue[1] == 0);
        
    }

    void Update()
    {
        // flip le sprite en fonction de la direction
        if (dir == 1 && GetComponent<SpriteRenderer>().flipX == true)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir == -1 && GetComponent<SpriteRenderer>().flipX == false)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }


        // Modifier les variables dans l'animator
        animator.SetBool("Walk", walk);

    }

    public virtual int getDir {
        get { return dir; }
    }

    
}



