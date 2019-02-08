using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{    
    
    public float playerSpeed = 10f;
    public int playerJumpPower = 1250;
    public bool grounded;
    public bool facingRight = true;
    private float moveX;   
    private Vector2 movement;
    private int DoubleJump = 0;

    void Update()
    {
        PlayerMove();
        shot();
    }   
    void shot()
    {
        bool shoot = Input.GetButtonDown("Fire1");
       
        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false : le joueur n'est pas un ennemi
                weapon.Attack(false);
                Sound.Instance.MakePlayerShotSound();
            }
        }
    }     
     void PlayerMove()
        {
            moveX = Input.GetAxis("Horizontal");
            
            if (Input.GetButtonDown("Jump")  && DoubleJump<=1)
                Jump();
            if (moveX > 0.0f && facingRight == false)
                FlipPlayer();
            else if (moveX < 0.0f && facingRight == true)
                FlipPlayer();
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        void Jump()
        {
            
            
            if (DoubleJump == 1)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity =
                    new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
                DoubleJump += 1;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity =
                    new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
                DoubleJump += 1;
            }
        }
        void  FlipPlayer()
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "ground")
        {
            //grounded = true;
            DoubleJump = 0;
        }
    }
}