﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class FloatingEyeAttackSMB : SceneLinkedSMB<EnemyBehaviour>
    {
        public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnSLStateExit(animator, stateInfo, layerIndex);

            //m_MonoBehaviour.SetHorizontalSpeed(0);
        }
    }
}