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
            gameManager.PlayerDeath();
        }
    }

    public void DealDamage(float damage)
    {
        healthPoints -= damage;
        if (!isAlive())
        {
            gameManager.PlayerDeath();
        }
    }
    private bool isAlive()
    {
        return healthPoints > 0;
    }
}
