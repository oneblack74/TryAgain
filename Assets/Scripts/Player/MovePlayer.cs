using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private PlayerInput inputs;

    private InputAction moveAction;
    private InputAction jumpAction;

    private GameManager manager;
    
    private Vector2 velocity = Vector2.zero;
    [SerializeField] private float speed = 2f;
    [SerializeField] private int jumpForce;
    [SerializeField] private int doubleJumpForce;

    private Transform verifierSolGauche;
    private Transform verifierSolDroit;

    private int dir;
    private bool walk;

    [SerializeField] private Animator animator;

    private bool estAuSol;
    private bool doubleJumpOn;
    private Rigidbody2D rb;

    [SerializeField] private Transform coordStart;


    void Start() 
    {
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();

        moveAction = inputs.actions.FindAction("Move");
        jumpAction = inputs.actions.FindAction("Jump");

        rb = GetComponent<Rigidbody2D>();

        dir = 1;
        doubleJumpOn = true;

        verifierSolGauche = GameObject.Find("verifierJumpL").GetComponent<Transform>();
        verifierSolDroit = GameObject.Find("verifierJumpR").GetComponent<Transform>();

        transform.position = coordStart.position;
    
    }

    private void FixedUpdate()
    {
        if (!VariableGlobale.jeuEnPause)
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
            walk = (_moveValue[0] != 0);
        }
        
    }

    void Update()
    {
        if (!VariableGlobale.jeuEnPause)
        {
            // mise à jour de la variable estAuSol
            estAuSol = Physics2D.OverlapArea(verifierSolGauche.position, verifierSolDroit.position, LayerMask.GetMask("Solide"));
            // mise à jour de la variable doubleJumpOn
            if (estAuSol && !doubleJumpOn) doubleJumpOn = true;

            // flip le sprite en fonction de la direction
            if (dir == 1 && GetComponent<SpriteRenderer>().flipX == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (dir == -1 && GetComponent<SpriteRenderer>().flipX == false)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }


            // faire un sout ou double saut si la touche est trigger
            if (jumpAction.triggered && estAuSol)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
            else if (jumpAction.triggered && doubleJumpOn)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, 0);
                rb.AddForce(new Vector2(0f, doubleJumpForce), ForceMode2D.Impulse);
                doubleJumpOn = false;
            }


            // Modifier les variables dans l'animator
            animator.SetBool("Walk", walk);
        }
    }

    public virtual int getDir {
        get { return dir; }
    }

    
}



