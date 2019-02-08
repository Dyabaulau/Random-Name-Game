using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponScript : MonoBehaviour
{
 
    public Transform shotPrefab;
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
        PlayerScript dir = transform.GetComponent<PlayerScript>();
        if (facingRight != dir.facingRight)
            Flip();
    }

    
    
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;           
            var shotTransform = Instantiate(shotPrefab) as Transform;
            if (shotPrefab.tag == "Melee"  && facingRight == true)
            {
                
                shotTransform.position = new Vector3( transform.position.x +0.18f,transform.position.y,transform.position.z);
                

            }
            else if (shotPrefab.tag == "Melee"  && facingRight == false)
            {
                shotTransform.position = new Vector3( transform.position.x -0.18f,transform.position.y,transform.position.z);
            }
            else
            {
                shotTransform.position = transform.position;
            }
                

            Shot shot = shotTransform.gameObject.GetComponent<Shot>();

            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }
            
            
        }
    }

  
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        shotPrefab.Rotate(0f, 180f, 0f);
    }
    
}
