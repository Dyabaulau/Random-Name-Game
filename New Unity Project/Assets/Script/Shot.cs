using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Comportement des tirs
/// </summary>
public class Shot : MonoBehaviour
{
    // 1 - Designer variables

    /// <summary>
    /// Points de dégâts infligés
    /// </summary>
    public int damage = 1;

    /// <summary>
    /// Projectile ami ou ennemi ?
    /// </summary>
    public bool isEnemyShot = false;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
            Destroy(gameObject);
    }

    void Start()
    {
        // 2 - Destruction programmée
        Destroy(gameObject, 10); // 10 sec

    }
}
