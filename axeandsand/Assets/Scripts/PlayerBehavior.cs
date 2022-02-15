using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main script to define how the player behaves
/// </summary>
public class PlayerBehavior : MonoBehaviour
{
    public GameBehavior gameBehavior;
    public Transform playerTransform;


    public float moveSpeed = 7f;
    public float rotateSpeed = 90f;
    public float jumpVelocity = 10f;
    private float vInput;
    private float hInput;
    public GameObject bullet;


    // Variable for distance to ground
    public float distanceToGround = 0.1f;
    // Layermask variable that we can use from inspector
    public LayerMask groundLayer;
    // Variable for player's collider component
    private BoxCollider _col;


    //The Rigidbody object we will use
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        this.gameBehavior = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
        this.playerTransform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();

        // Get Player's capsule collider info
        _col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vertical input
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        //Horizontal input
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

    }
    void FixedUpdate()
    {
        //Vector for rotation
        Vector3 rotation = Vector3.up * hInput;
        //Getting the angle for rotation
        Quaternion angleRot = Quaternion.Euler(rotation *
       Time.fixedDeltaTime);
        //Use the Rigitbody method for traversal
        _rb.MovePosition(this.transform.position +
       this.transform.forward * vInput * Time.fixedDeltaTime);
        // Use the Rigitbody method for rotation
        _rb.MoveRotation(_rb.rotation * angleRot);
    }

    private void GainPoint()
    {
        gameBehavior.EnemyKilled = gameBehavior.EnemyKilled + 1;
    }
  
    // On collision store info of collision
    void OnCollisionEnter(Collision collision)
    {
        // If it is the player execute code
        if (collision.gameObject.name == "Enemy")
        {
            GainPoint();
        }

        if (collision.gameObject.name == "prefab cannon ball(Clone)")
        {
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.name == "canon")
        {
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.name == "wall")
        {
            SceneManager.LoadScene(1);
        }
    }
}
