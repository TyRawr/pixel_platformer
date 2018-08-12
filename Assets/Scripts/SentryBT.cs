using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTAI;

namespace Gamekit2D
{
    public class SentryBT : MonoBehaviour
    {


        Animator m_Animator;
        Damageable m_Damageable;
        Root m_Ai = BT.Root();
        EnemyBehaviour m_EnemyBehaviour;

        private void OnEnable()
        {
            m_EnemyBehaviour = GetComponent<SentryEnemyBehavior>();
            m_Animator = GetComponent<Animator>();

            m_Ai.OpenBranch(
                BT.Trigger(m_Animator, "Shooting"),
                BT.Call(m_EnemyBehaviour.RememberTargetPos),
                BT.WaitForAnimatorState(m_Animator, "Attack")
            );
        }

        private void Update()
        {
            m_Ai.Tick();
        }
    }

}
