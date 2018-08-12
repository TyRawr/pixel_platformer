using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{

    public class SentryEnemyBehavior : EnemyBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            StartCoroutine(FireTimer());
        }
        // Use this for initialization
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log("Update");

        }

        IEnumerator FireTimer()
        {
            while(true)
            {
                yield return new WaitForSeconds(4f);
                Debug.Log("Sentry Fire");
                m_Animator.SetTrigger("Fire");
                Shooting();
            }
            
        }

    }


}
