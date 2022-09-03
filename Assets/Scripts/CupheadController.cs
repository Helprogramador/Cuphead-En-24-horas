using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CupheadController : MonoBehaviour
{
    #region variables

    [SerializeField] GameObject bala;
    [SerializeField] GameObject spawnpoint;
    [SerializeField] bool move;
    [SerializeField] bool canjump;
    [SerializeField] bool left;
    [SerializeField] bool lookingUp;
    [SerializeField] bool damageable;
    [SerializeField] float jump_force;
    [SerializeField] float velocity;
    [SerializeField] float timer;
    [SerializeField] float timeToShoot;
    [SerializeField] Text healthtext;

    [SerializeField] int health;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthtext.text = "HP. " + health;
        timer += Time.deltaTime;
        if(move)
        {
            

            

            if(Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.GetComponent<Animator>().SetBool("Moving", true);
                gameObject.transform.rotation = new Quaternion(0, 50, 0, 50);
                gameObject.transform.Translate(0, 0, 1 * velocity * Time.deltaTime);
            }

            if(Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.GetComponent<Animator>().SetBool("Moving", true);
                gameObject.transform.rotation = new Quaternion(0, -50, 0, 50);
                gameObject.transform.Translate(0, 0, 1 * velocity * Time.deltaTime);
            }

            if(Input.GetKey("z") && canjump)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1000 * jump_force * Time.deltaTime, 0));
                canjump = false;
            }

            if(Input.GetKey(KeyCode.LeftShift))
            {
                gameObject.GetComponent<Animator>().SetBool("Look Up", true);
                Shoot();
                lookingUp = true;
            }

            if(Input.GetKey("x"))
            {
                gameObject.GetComponent<Animator>().SetBool("Shooting", true);
                Shoot();
            }

            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                gameObject.GetComponent<Animator>().SetBool("Moving", false);
            }

            if(Input.GetKeyUp(KeyCode.RightArrow))
            {
                gameObject.GetComponent<Animator>().SetBool("Moving", false);
            }

            if(Input.GetKeyUp(KeyCode.LeftShift) && canjump)
            {
                gameObject.GetComponent<Animator>().SetBool("Look Up", false);
                lookingUp = false;
            }

            if(Input.GetKeyUp("x"))
            {
                gameObject.GetComponent<Animator>().SetBool("Shooting", false);
            }
        }

        if(health <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }

        
    }

    void Shoot()
    {
        if(timer >= timeToShoot && !lookingUp)
        {
            timer = 0f;
            Quaternion rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
            Instantiate(bala, spawnpoint.transform.position, rotation);
            Debug.Log("Piu Piu....Piu");
        }

        if(timer >= timeToShoot && lookingUp)
        {
            timer = 0f;
            Quaternion rotation = new Quaternion(-50, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 50);
            Instantiate(bala, spawnpoint.transform.position, rotation);
            Debug.Log("Piu Piu....Piu");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Floor")
        {
            canjump = true;
        }

        if(other.transform.tag == "Enemy" && damageable)
        {
            gameObject.GetComponent<Animator>().SetBool("Damage", true);
            health -= 1;
            damageable = false;
            Invoke("Damage", 3f);
        }

    }

    public void Damage()
    {
        damageable = true;
        gameObject.GetComponent<Animator>().SetBool("Damage", false);
    }
}
