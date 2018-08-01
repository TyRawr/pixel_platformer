using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class FloatingEyePatrolSMB : SceneLinkedSMB<EnemyBehaviour>
    {
        public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

            
            //We do this explicitly here instead of in the enemy class, that allow to handle obstacle differently according to state
            // (e.g. look at the ChomperRunToTargetSMB that stop the pursuit if there is an obstacle) 
            //Debug.LogWarning("Check Obstacle");
            float dist = m_MonoBehaviour.speed;
            Debug.Log("dist " + dist);
            if (m_MonoBehaviour.CheckForObstacle(dist))
            {
                Debug.Log("CheckForObstacle was true");
                //this will inverse the move vector, and UpdateFacing will then flip the sprite & forward vector as moveVector will be in the other direction
                m_MonoBehaviour.SetHorizontalSpeed(-dist);
                m_MonoBehaviour.UpdateFacing();
            }
            else
            {
                Debug.Log("CheckForObstacle was false");
                m_MonoBehaviour.SetHorizontalSpeed(dist);
            }
            

            m_MonoBehaviour.ScanForPlayer();
        }
    }
}
