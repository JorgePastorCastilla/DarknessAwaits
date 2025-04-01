using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float healthPoints = 2f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DealDamage()
    {
        healthPoints--;
        if (!isAlive())
        {
            //trigger death animation
            // GetComponent<CharacterMovement>().enabled = false;
            // GetComponent<PlayerController>().enabled = false;
            // GetComponent<Animator>().SetTrigger("PlayerDeath");
            KillPlayer();
        }
    }

    public void DealDamage(float damage)
    {
        healthPoints -= damage;
        if (!isAlive())
        {
            // GetComponent<CharacterMovement>().enabled = false;
            // GetComponent<PlayerController>().enabled = false;
            // GetComponent<Animator>().SetTrigger("PlayerDeath");
            KillPlayer();

        }
    }
    private bool isAlive()
    {
        return healthPoints > 0;
    }

    public void KillPlayer()
    {
        gameManager.PlayerDeath();
    }
}
