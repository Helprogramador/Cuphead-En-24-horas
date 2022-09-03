using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    bool move = false;
    float timer;
    [SerializeField] float velocity;
    // Start is called before the first frame update
    void Start()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            timer += Time.deltaTime;
            gameObject.transform.Translate(0, 0, 1f * velocity * Time.deltaTime);
        }

        if(timer >= 2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        
        
    }
}
