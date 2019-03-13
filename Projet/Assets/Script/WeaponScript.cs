using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BestMasterYi
{



    public class WeaponScript : MonoBehaviour
    {

        public Transform shotPrefab;
        public Transform shotPrefab2;
        public bool facingRight = true;
        public float shootingRate = 0.25f;



        //--------------------------------
        // 2 - Rechargement
        //--------------------------------
        private float shootCooldown;

        void Start()
        {
            shootCooldown = 0f;
        }

        void Update()
        {
            if (shootCooldown > 0)
            {
                shootCooldown -= Time.deltaTime;
            }

            PlayerScript dir = GetComponent<PlayerScript>();
            if (facingRight != dir.facingRight)
                Flip();
        }



        public void Attack(bool isEnemy)
        {
            if (CanAttack)
            {
                shootCooldown = shootingRate;
                PlayerScript shotType = GetComponent<PlayerScript>();


                if (shotType.timer >= shotType.startTime)
                {
                    var shotTransform = Instantiate(shotPrefab2) as Transform;
                    AttackType(shotTransform);
                }
                else
                {
                    var shotTransform1 = Instantiate(shotPrefab) as Transform;
                    AttackType(shotTransform1);
                }


            }
        }

        void AttackType(Transform t)
        {
            if (t.tag == "Melee" && facingRight)
            {
                t.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            }
            else if (t.tag == "Melee" && facingRight == false)
            {
                t.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            }
            else
            {
                t.position = transform.position;
            }

            Shot shot = t.gameObject.GetComponent<Shot>();

            if (shot != null)
            {
                shot.isEnemyShot = t;
            }
        }

        public bool CanAttack
        {
            get { return shootCooldown <= 0f; }
        }

        void Flip()
        {
            facingRight = !facingRight;
            shotPrefab.Rotate(0f, 180f, 0f);
        }

    }
}