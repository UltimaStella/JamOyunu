using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Controller;
public class Fuel : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Npc"))
        {
            int newFuel = 0;
            switch (other.GetComponent<HumanController>().level)
            {

                case 0:
                    newFuel = 1;
                    break;
                case 1:

                    newFuel = 3;
                    break;
                case 2:

                    newFuel = 8;
                    break;
                case 3:

                    newFuel = 12;
                    break;

            }
            gm.AddFuel(newFuel);
        }
    }
}
