using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed = 4;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator anim;
    
    // Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        change = Vector2.zero;
     
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
        }

    void UpdateAnimationAndMove()
    {
                if (change != Vector3.zero)
        {

            MoveCharacter();
    anim.SetFloat("moveX", change.x);
            anim.SetFloat("moveY", change.y);
            anim.SetBool("moving", true);

        }
        else
        {
            anim.SetBool("moving", false);
        }
    }


    void MoveCharacter()
    {
        myRigidbody.MovePosition(

            transform.position + change * speed * Time.deltaTime
           
            );

    }
}
