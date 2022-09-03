using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMovement : MonoBehaviour
{
    [SerializeField] int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {

        if(health <= 0)
        {
            Destroy(gameObject);
        }


        if(other.transform.tag == "Arma")
        {
            Damage(1);
        }

    }

    public void Damage(int num)
    {
        health -= num;
    }
}
