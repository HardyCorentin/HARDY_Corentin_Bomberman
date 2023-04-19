using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] private LayerMask _wall;
    [SerializeField] private LayerMask _default;
    [SerializeField] private float _timer = 2f;
    [SerializeField] private BombScript _bomb;
    public int explosionID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer = _timer -0.1f;
        if (_timer > 0)
        {
            var collisions = Physics.OverlapBox(gameObject.transform.position, Vector3.zero,Quaternion.identity, _wall);

            if (collisions.Length > 0)
            {
                var wallTouched = FindWallScriptInCollision(collisions);
                Debug.LogError(wallTouched);
                if(wallTouched.isDestructible == true)
                {
                    Debug.Log("DESTROY THIS GODDAMN WALL");
                    Destroy(wallTouched.gameObject);
                }
                else
                {
                    Debug.LogWarning("Wall is not destructible");

                    //So. What it SHOULD do is state which part of the explosion must be stoped but it seems it explodes the code instead.
                    if (explosionID == 3) 
                    {
                        _bomb.stopDownExplosion = true;
                    }

                    if (explosionID == 1) 
                    {
                        _bomb.stopLeftExplosion = true;
                    }
                    if (explosionID == 0)
                    {
                        _bomb.stopRightExplosion = true;
                    }


                    if (explosionID == 2) 
                    {
                        _bomb.stopUpExplosion = true;
                    }
                    Destroy(gameObject);
                }
                
            }
            
            //Check if a player is touched by this explosion
            
            var explozone = Physics.OverlapBox(gameObject.transform.position, Vector3.zero, Quaternion.identity, _default);
            if (explozone.Length > 0)
            {
                var playertouched = FindPlayerScriptInCollision(explozone);
                Debug.LogError(playertouched);
                if (playertouched.isAlive == true)
                {
                    playertouched.isAlive = false;
                    Debug.Log("KillPlayer");
                    //Destroy(playertouched.gameObject);
                }
                else
                {
                    Debug.LogWarning("PlayerDodged");
                }
            }
        
        
        }
        else
        {
            Destroy(gameObject);
            
        }
    }






    //____________________________________________________________________________________________________________________________





    //Functions


    public WallScript FindWallScriptInCollision(Collider[] array)
    {
        foreach (var col in array)
        {
            Debug.Log(col.gameObject.name);
            var wallScript = col.GetComponent<WallScript>();

            if(wallScript != null)
            {
                return wallScript;
            }
        }
        return null;
    }
    public PlayerScript FindPlayerScriptInCollision(Collider[] array)
    {
        foreach (var col in array)
        {
            Debug.Log(col.gameObject.name);
            var playerScript = col.GetComponent<PlayerScript>();

            if (playerScript != null)
            {
                return playerScript;
            }
        }
        return null;
    }
}
