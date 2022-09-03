using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float velocity;
    [SerializeField] float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        gameObject.transform.position -= new Vector3(1 * velocity * Time.deltaTime, 0, 0);

        if(timer >= 7f)
        {
            Destroy(gameObject);
        }
    }
}
