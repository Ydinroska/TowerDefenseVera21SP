using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed = 10f;
    [SerializeField] float damage = 5f;

    private Rigidbody rb;
    private Enemy targetedEnemy;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Setup the projectile as soon as it is created
    public void Setup(Vector3 enemyDirection, Enemy incomingTargetedEnemy)
    {
        targetedEnemy = incomingTargetedEnemy;   // who to chase?
        //Vector3 force = enemyDirection * 5.0f; // calculate force
        //rb.AddForce(force, ForceMode.Impulse); // apply force

    }

    private void Update()
    {
        if (targetedEnemy) // if the targeted enemy is still alive
        {
            // travel towards the enemy
            transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetedEnemy.transform.position,
                    speed * Time.deltaTime);
                
        }
    }

    private void OnTriggerEnter(Collider other)
    {

       if(other.gameObject == targetedEnemy.gameObject)
       {
            targetedEnemy.InflictDamage(damage); 
       }

       // get destroyed anyway
        Destroy(this.gameObject);
       



    }


}
