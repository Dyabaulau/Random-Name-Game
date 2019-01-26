using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{    
    
    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    public bool grounded;
    public bool facingRight = true;
    private float moveX;   
    private Vector2 movement;

    void Update()
    {
        PlayerMove();
        shot();
    }   
    void shot()
    {
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        // Astuce pour ceux sous Mac car Ctrl + flèches est utilisé par le système

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false : le joueur n'est pas un ennemi
                weapon.Attack(false);
            }
        }
    }     
     void PlayerMove()
        {
            moveX = Input.GetAxis("Horizontal");
            
            if (Input.GetButtonDown("Jump") && grounded == true)
                Jump();
            if (moveX > 0.0f && facingRight == false)
                FlipPlayer();
            else if (moveX < 0.0f && facingRight == true)
                FlipPlayer();
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        void Jump()
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
            grounded = false;
        }
        void  FlipPlayer()
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }                    
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("player has collided with" + col.collider.name);
        if (col.gameObject.tag == "ground")
            grounded = true;
    }
}