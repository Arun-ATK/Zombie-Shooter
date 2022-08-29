using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Pathfinding AI

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float hitPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit(float damage)
    {
        hitPoints -= damage;
        Debug.Log("Zombie current health: " + hitPoints);

        if (hitPoints < 0) OnDeath();
    }

    private void OnDeath()
    {
        // TODO: Think of a better name
        Debug.Log("Death");
        Destroy(gameObject);
    }
}
