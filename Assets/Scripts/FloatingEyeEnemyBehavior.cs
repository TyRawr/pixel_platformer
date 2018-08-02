using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Gamekit2D
{
    public class FloatingEyeEnemyBehavior : EnemyBehaviour
    {
        private void FixedUpdate()
        {
            if (m_Dead)
                return;
            m_CharacterController2D.Move(m_MoveVector * Time.deltaTime);
            //m_MoveVector.y = Mathf.Max(m_MoveVector.y - gravity * Time.deltaTime, -gravity);
            //Debug.Log("EYE Move " + m_MoveVector);
            //m_CharacterController2D.CheckCapsuleEndCollisions();

            UpdateTimers();

            //m_Animator.SetBool(m_HashGroundedPara, m_CharacterController2D.IsGrounded);
        }

        public override bool CheckForObstacle(float forwardDistance)
        {
            Vector3 castingPosition = (Vector2)(transform.position + m_LocalBounds.center) + m_SpriteForward * m_LocalBounds.extents.x;
            //Debug.DrawLine(castingPosition, castingPosition + forwardDistance * (m_LocalBounds.extents.x + 0.4f));
             
            float radius = 2.0f;
            Debug.Log(transform.forward);
            RaycastHit2D[] hits = Physics2D.CircleCastAll((Vector2)(castingPosition), radius, new Vector2(1, 1), forwardDistance, m_CharacterController2D.groundedLayerMask.value);
            for(int i = 0; i < hits.Length; i++)
            {
                //Debug.Log(hits[i].collider.gameObject.name + "\t" + i);
            }
            //Vector3 castingPosition = (Vector2)(transform.position + m_LocalBounds.center) + m_SpriteForward * m_LocalBounds.extents.x;
            Debug.DrawLine(castingPosition, castingPosition + (Vector3)m_SpriteForward * (m_LocalBounds.extents.y + 0.2f));

            RaycastHit2D hit = Physics2D.CircleCast(castingPosition, 0.2f, m_SpriteForward, 0.2f, m_CharacterController2D.groundedLayerMask.value);
            if(hit)
            {
                Debug.Log(hit.collider.gameObject.name);
                return true;
            }
               


            return false;
        }
    }
}