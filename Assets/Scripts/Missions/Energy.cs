using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Controller;


public class Energy : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Npc"))
        {
            int newEnergy = 0;
            switch (other.GetComponent<HumanController>().level)
            {

                case 0:
                    newEnergy = 1;
                    break;
                case 1:

                    newEnergy = 3;
                    break;
                case 2:

                    newEnergy = 8;
                    break;
                case 3:

                    newEnergy = 12;
                    break;

            }

            gm.AddEnergy(newEnergy);
        }
    }
}
