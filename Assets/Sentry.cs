using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class Sentry : MonoBehaviour
    {
        public Transform _bullet;
        public Transform parentSpawn;


        public Vector2 direction;
        
        public float forceScalar;

        // Use this for initialization
        void Start()
        {
            SpawnBullet();
            StartCoroutine(BulletTimer());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator BulletTimer()
        {
            while(gameObject != null && gameObject.activeInHierarchy)
            {
                yield return new WaitForSeconds(1f);
                SpawnBullet();
            }
            
        }

        private void SpawnBullet()
        {
            //Debug.Log("Spawn");
            Transform bullet = (Transform)GameObject.Instantiate(_bullet);
            bullet.parent = parentSpawn;
            bullet.localPosition = new Vector3(0f, 0f, 0f);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = forceScalar * direction;
            rb.gravityScale = 0;
        }
    }

}
