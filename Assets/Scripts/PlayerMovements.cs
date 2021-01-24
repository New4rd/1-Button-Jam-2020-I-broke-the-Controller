using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    static public PlayerMovements Instance;

    [SerializeField] GameObject arrow;

    [Header ("Player's states")]
    public bool move;
    public bool moveForward = true;

    [Header ("Player's movements parameters")]
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;

    Rigidbody2D rb;

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (!TrackManager.Instance.lapStarted)
        {
            return;
        }


        if (moveForward)
        {
            rb.angularVelocity = 0f;
            rb.velocity = transform.up * movementSpeed;
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(ScenesManager.Instance.LoadScene("Unavailable Button Scene"));
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveForward = false;
            rb.velocity = Vector3.zero;
            arrow.SetActive(true);

            AudioManager.Instance.LoadEngineSound("Slide sound");
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.freezeRotation = false;
            transform.Rotate(transform.forward, -rotationSpeed);
        }


        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.freezeRotation = true;
            moveForward = true;
            arrow.SetActive(false);

            AudioManager.Instance.LoadEngineSound("Engine_03");
        }


        if (!move)
        {
            rb.velocity = Vector2.zero;
            arrow.SetActive(false);
            return;
        }
    }
}
