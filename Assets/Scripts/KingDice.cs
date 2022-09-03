using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingDice : MonoBehaviour
{

    [SerializeField] int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 155;   
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene("Ganaste");
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
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