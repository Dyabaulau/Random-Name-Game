﻿using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

namespace BestMasterYi
{



    public class PlayerScript : MonoBehaviour
    {

        public float playerSpeed = 10f;
        public int playerJumpPower = 1250;
        public bool grounded;
        public bool facingRight = true;
        private float moveX;
        public float startTime = 0f;
        float holdTime = 2.0f; // 2 seconds
        private Vector2 movement;
        private int DoubleJump = 0;
        public float timer = 0;


        void Update()
        {
            PlayerMove();
            timer = Time.time;

            if (Input.GetButtonDown("Fire1"))
            {

                startTime = Time.time + holdTime;

            }

            if (Input.GetButtonUp("Fire1") && startTime >= 0.1f)
            {
                shot();
                startTime = 0f;
            }
        }

        void shot()
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false : le joueur n'est pas un ennemi
                weapon.Attack(false);
                Sound.Instance.MakePlayerShotSound();
            }

        }





        void PlayerMove()
        {
            moveX = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump") && DoubleJump <= 1)
                Jump();
            if (Input.GetButtonUp("Jump"))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity =
                    new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);

            }

            if (moveX > 0.0f && facingRight == false)
                FlipPlayer();
            else if (moveX < 0.0f && facingRight == true)
                FlipPlayer();
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed,
                gameObject.GetComponent<Rigidbody2D>().velocity.y);
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

        void FlipPlayer()
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }

        void OnCollisionEnter2D(Collision2D col)
        {

            if (col.gameObject.tag == "ground")
            {
                grounded = true;
                DoubleJump = 0;
            }
        }
    }
}