using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    //Player stats
    public float Speed = 5;
    float Movement = 0f;
    bool jump = false;
    private int healthPoints = 3;

    public Animator animator;

    //Limite del terreno
    private int lowerBound = -10;


    private float horizontalInput;
    private Rigidbody2D rb; //rb = rigid body

    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ottieni il componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
/*
    //mi distrugge gli item che hanno Is Trigger on 
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Ho raccolto qualcosa");
        Destroy(other.gameObject);
        gameManager.UpdateScore(1);
    }


    public void goToGameOver() 
    {
        SceneManager.LoadScene(2);
    }*/
    

        Movement = Input.GetAxisRaw("Horizontal") * Speed;

        animator.SetFloat("speed", Mathf.Abs(Movement));

        //condizione per saltare
        if(Input.GetButtonDown("Jump")) 
        {
            jump = true;
            animator.SetBool("ground", true);
        }

        
        if(transform.position.y < lowerBound) 
        {
            //fa il reset del livello
            goToGameOver();
            Debug.Log("Sono caduto!!!");
        }

    }

    //tiene aggiornato le robe in update
    void FixedUpdate()
    {
        //Movimento del Player
        controller.Move(Movement * Time.fixedDeltaTime, false, jump);
        jump = false;

    }

    //mi dice quando tocco qualsiasi cosa
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Obstacle")) 
        {
            Debug.Log("Ho colpito qualcosa");
        }
    }

     public void goToGameOver() 
    {
        SceneManager.LoadScene(2);
    }
    
    public void onLanding() 
    {
            animator.SetBool("ground", false);
    }


}