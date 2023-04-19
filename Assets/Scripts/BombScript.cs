using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float timer;
    [SerializeField] private GameObject _playerPrefab ;
    public int explosionRadius = 3;
    [SerializeField] private GameObject _explosionPrefab;
    public bool stopUpExplosion;
    public bool stopDownExplosion;
    public bool stopLeftExplosion;
    public bool stopRightExplosion;
    public ExplosionScript explosion;
    public bool activateDestructionOfBomb;
    

    public void Start()
    {
        activateDestructionOfBomb = false;
        stopUpExplosion = false;
        stopRightExplosion = false;
        stopLeftExplosion = false;
        stopDownExplosion = false;
        timer = 3f;

    }

    public void Update()
    {
        Debug.LogWarning(timer);
        timer = timer - Time.deltaTime;
        
        if (timer <= 1f && timer >= 0 && activateDestructionOfBomb == false)
        {
            //Each for loop is a side of the explosion.
            // Right explosion
            for (int x = 0; x < explosionRadius+1; x++)
            {
                if (stopRightExplosion == false)
                {
                    var RightExplosion = Instantiate(_explosionPrefab, new Vector3(gameObject.transform.position.x + x - 1, gameObject.transform.position.y, -1), Quaternion.identity);
                    RightExplosion.GetComponent<ExplosionScript>().explosionID = 0;

                }
                //Stops this side of the explosion
                else if (stopRightExplosion == true)
                {
                    Debug.Log("SRIGHT");
                }
            }
            //Left explosion
            for (int x = 0; x < explosionRadius + 1; x++)
            {
                if (stopLeftExplosion == false)
                {
                    var LeftExplosion = Instantiate(_explosionPrefab, new Vector3(gameObject.transform.position.x - x + 1, gameObject.transform.position.y, -1), Quaternion.identity);
                    LeftExplosion.GetComponent<ExplosionScript>().explosionID = 1;

                }
                //Stops this side of the explosion
                else if (stopLeftExplosion == true)
                {
                    Debug.Log("SLEFT");
                }
                

            }
            //Top explosion
            for (int y = 0; y < explosionRadius; y++)
            {
                if (stopUpExplosion == false)
                {
                    var TopExplosion = Instantiate(_explosionPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + y, -1), Quaternion.identity);
                    TopExplosion.GetComponent<ExplosionScript>().explosionID = 2;
                }
                //Stops this side of the explosion
                else if (stopUpExplosion == true)
                {
                    Debug.Log("STOP");
                }

                
                
            }

            //Down explosion
            for (int y = 0; y < explosionRadius; y++)
            {
                if (stopDownExplosion == false)
                {
                    var DownExplosion = Instantiate(_explosionPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - y, -1), Quaternion.identity);
                    DownExplosion.GetComponent<ExplosionScript>().explosionID = 3;
                }
                //Stops this side of the explosion
                else if(stopDownExplosion == true)
                {
                    Debug.Log("SDOWN");
                }
                

            }


            
        }
        else if (timer<=0 || activateDestructionOfBomb == true)
        {
            Debug.Log("BOMB DESTROYED");
            Destroy(gameObject);
        }

    }
}
