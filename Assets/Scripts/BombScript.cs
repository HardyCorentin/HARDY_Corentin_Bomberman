using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float timer = 3f;
    [SerializeField] private GameObject _playerPrefab ;
    public int explosionRadius = 3;
    [SerializeField] private GameObject _explosionPrefab;
    public bool stopUpExplosion = false;
    public bool stopDownExplosion = false;
    public bool stopLeftExplosion = false;
    public bool stopRightExplosion = false;
    public ExplosionScript explosion;

    public void Start()
    {
        
    }

    public void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer <= 0f )
        {
            //Each for loop is a side of the explosion.
            // Right explosion
            for (int x = 0; x < explosionRadius+1; x++)
            {
                if (stopRightExplosion == false)
                {
                    var Explosion = Instantiate(_explosionPrefab, new Vector3(gameObject.transform.position.x + x - 1, gameObject.transform.position.y, -1), Quaternion.identity);
                    
                }
                else
                {
                    break;
                }
            }
            //Left explosion
            for (int x = 0; x < explosionRadius + 1; x++)
            {
                if (stopLeftExplosion == false)
                {
                    var BackExplosion = Instantiate(_explosionPrefab, new Vector3(gameObject.transform.position.x - x + 1, gameObject.transform.position.y, -1), Quaternion.identity);
                    explosion.explosionID = 1;

                }
                else
                {
                    break;
                }
                

            }
            //Up explosion
            for (int y = 0; y < explosionRadius; y++)
            {
                if (stopUpExplosion == false)
                {
                    var Explosion = Instantiate(_explosionPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + y, -1), Quaternion.identity);
                    explosion.explosionID = 2;
                }
                else
                {
                    break;
                }

                
                
            }

            //Down explosion
            for (int y = 0; y < explosionRadius; y++)
            {
                if (stopDownExplosion == false)
                {
                    var BackExplosion = Instantiate(_explosionPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - y, -1), Quaternion.identity);
                    explosion.explosionID = 3;
                }
                else
                {
                    break;
                }
                

            }


            Destroy(gameObject);
        }

    }
}
