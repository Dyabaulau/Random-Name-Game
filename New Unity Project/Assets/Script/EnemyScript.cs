using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Comportement générique pour les méchants
/// </summary>

public class EnemyScript : MonoBehaviour


{
    public float speed;
    public int xMoveDirection;

    private WeaponScript[] weapons;

    void Awake()
    {
        // Récupération de toutes les armes de l'ennemi
        weapons = GetComponentsInChildren<WeaponScript>();
    }
      
    void Flip()
        {
            if (xMoveDirection > 0)
                xMoveDirection = -1;
            else
                xMoveDirection = 1;
        }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * speed;
        if (hit.distance < 0.1f)
           Flip();
    
        foreach (WeaponScript weapon in weapons)
        {
            // On fait tirer toutes les armes automatiquement
            if (weapon != null && weapon.CanAttack)
            {
                weapon.Attack(true);
            }
        }
    }

    
}
