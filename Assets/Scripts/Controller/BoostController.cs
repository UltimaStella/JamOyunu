using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Controller
{
    public class BoostController : Controller
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Npc"))
            {
                if (!targetLevel.Contains(other.gameObject.GetComponent<HumanController>().level))
                    return;
                if (targetLevel.Contains(other.GetComponent<HumanController>().level))
                    other.GetComponent<HumanController>().LevelUp(); 
            }
        }
    }
}