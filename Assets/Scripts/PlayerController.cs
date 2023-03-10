using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    public float playerRotate;
    public bool playerMove = false;
    private Rigidbody rb;
    private Vector3 displacement;
    //Se ejecuta antes del metodo Start
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float mh = Input.GetAxis("Horizontal");
        PlayerMove(mh);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerMove(float mh)
    {
        displacement.Set(0f,0f,mh);
        displacement = displacement.normalized * playerSpeed * Time.deltaTime;
        rb.MovePosition (transform.position + displacement);

        if(mh != 0f)
        {
            PlayerRotate(mh);
        }
        
        bool playerRun = mh != 0f;

        if(playerRun)
        {
            playerMove = true;
        }
        else
        {
            playerMove = false;
        }
    }

    void PlayerRotate(float mh)
    {
        float interpolation = playerRotate * Time.deltaTime;
        Vector3 targetDirection = new Vector3(0f,0f,mh);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(rb.rotation,targetRotation,interpolation);
        rb.MoveRotation(newRotation);
    }
}
