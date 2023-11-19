using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class HumanController : MonoBehaviour
    {
        public int level;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.transform.position += transform.forward * 3/2* Time.deltaTime;
        }
        public void LevelUp()
        {
            level++;


        }
    }
  
}