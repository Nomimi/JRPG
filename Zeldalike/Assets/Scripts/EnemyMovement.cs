using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{


    public float speed = 4;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator anim;


    //Numbers for Random
    public float keepMovementPercentage = 80f;
    public float standStillPercentage = 10f;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        change = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
        change = RandomMovement(change);
        
        UpdateAnimationAndMove();
    }

    //Set X and Y Movement to 1 | 0 | -1 with higher percentage for same value again
    Vector2 RandomMovement(Vector2 currentValue)
    {
        Vector2 result = Vector2.zero;
        
    
    float randomNumber = Random.Range(0, 100);
        if (randomNumber <= keepMovementPercentage)
        {
            Debug.Log("KeepingCurrentValue");
            return currentValue;
        }
        else if (randomNumber <= (keepMovementPercentage + standStillPercentage))
        {

            Debug.Log("Standing Still");
            return result;
        }
        else
        {
            Vector2 newDirection;
            newDirection = new Vector2(Random.Range(0, 2), Random.Range(0, 2));
            if (newDirection == currentValue)
            { newDirection = new Vector2(currentValue.x, currentValue.y); }
            Debug.Log("Change to "+ newDirection);
            return newDirection;
        }   
        
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