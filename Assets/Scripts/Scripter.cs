using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripter : MonoBehaviour
{

    [SerializeField] Transform left;
    [SerializeField] Transform right;
    [SerializeField] GameObject m_KingDice;
    [SerializeField] GameObject cartas_right;
    [SerializeField] GameObject cartas_left;
    [SerializeField] float timeToAttack;
    [SerializeField] int stateOfDice;
    [SerializeField] float timer;
    Animator m_Dice;
    
    // Start is called before the first frame update
    void Start()
    {
        stateOfDice = 1;
        m_Dice = m_KingDice.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        m_Dice.SetInteger("State", stateOfDice);

        
        if(timer >= timeToAttack)
        {
            switch (stateOfDice)
            {
                case 0:
                    Right();
                    timer = 0.0f;
                    stateOfDice = 3;
                    break;

                case 1:
                    Left();
                    timer = 0.0f;
                    stateOfDice = 2;
                    break;
                
                case 2:
                    timer = 0.0f;
                    stateOfDice = 0;
                    break;

                case 3:
                    timer = 0.0f;
                    stateOfDice = 1;
                    break;
            }
        }
    }

    void Left()
    {
        Quaternion rotation = new Quaternion(left.rotation.x, left.rotation.y, left.rotation.z, left.rotation.w);
        Instantiate(cartas_left, left.position, rotation);
    }

    void Right()
    {
        Quaternion rotation = new Quaternion(right.rotation.x, right.rotation.y, right.rotation.z, right.rotation.w);
        Instantiate(cartas_right, right.position, rotation);
    }
    
}
