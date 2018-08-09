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
            UpdateFireTimer();

            //m_Animator.SetBool(m_HashGroundedPara, m_CharacterController2D.IsGrounded);
        }

        public virtual void UpdateTimers()
        {
            if (m_TimeSinceLastTargetView > 0.0f)
                m_TimeSinceLastTargetView -= Time.deltaTime;

            if (m_FireTimer > 0.0f)
                m_FireTimer -= Time.deltaTime;
        }

        public override void ScanForPlayer()
        {
            //Debug.Log("ScanForPlayer");
            //If the player don't have control, they can't react, so do not pursue them
            if (!PlayerInput.Instance.HaveControl)
                return;

            Vector3 dir = PlayerCharacter.PlayerInstance.transform.position - transform.position;

            if (dir.sqrMagnitude > viewDistance * viewDistance)
            {
                return;
            }

            Vector3 testForward = Quaternion.Euler(0, 0, spriteFaceLeft ? Mathf.Sign(m_SpriteForward.x) * -viewDirection : Mathf.Sign(m_SpriteForward.x) * viewDirection) * m_SpriteForward;

            float angle = Vector3.Angle(new Vector3(0f,0f,viewDirection), dir);
            Debug.Log("angle " + viewDirection);
            if (viewDirection > viewFov * 0.5f)
            {
                return;
            }

            m_Target = PlayerCharacter.PlayerInstance.transform;
            m_TimeSinceLastTargetView = timeBeforeTargetLost;

            m_Animator.SetTrigger(m_HashSpottedPara);
        }

        public override void OrientToTarget()
        {
            if (m_Target == null)
                return;

            Vector3 toTarget = m_Target.position - transform.position;
            transform.LookAt(m_Target);
            if (Vector2.Dot(toTarget, m_SpriteForward) < 0)
            {
                //SetFacingData(Mathf.RoundToInt(-m_SpriteForward.x));
            }

            Vector3 diff = m_Target.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            viewDirection = rot_z;
        }

        public override bool CheckForObstacle(float forwardDistance)
        {
            Vector3 castingPosition = (Vector2)(transform.position + m_LocalBounds.center) + m_SpriteForward * m_LocalBounds.extents.x;
            //Debug.DrawLine(castingPosition, castingPosition + forwardDistance * (m_LocalBounds.extents.x + 0.4f));
             
            float radius = .2f;
            Debug.Log(transform.forward);
            RaycastHit2D[] hits = Physics2D.CircleCastAll((Vector2)(castingPosition), radius, new Vector2(1, 1), forwardDistance, m_CharacterController2D.groundedLayerMask.value);
            for(int i = 0; i < hits.Length; i++)
            {
                //Debug.Log(hits[i].collider.gameObject.name + "\t" + i);
            }
            //Vector3 castingPosition = (Vector2)(transform.position + m_LocalBounds.center) + m_SpriteForward * m_LocalBounds.extents.x;
            Debug.DrawLine(castingPosition, castingPosition + (Vector3)m_SpriteForward * (m_LocalBounds.extents.y + radius));
            //Physics2D.CircleCastAll()
            RaycastHit2D hit = Physics2D.CircleCast(castingPosition, radius, m_SpriteForward, .2f, m_CharacterController2D.groundedLayerMask.value);
            if(hit)
            {
                Debug.Log(hit.collider.gameObject.name);
                return true;
            }
               


            return false;
        }
    }
}