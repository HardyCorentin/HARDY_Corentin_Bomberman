using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public bool isAlive = true;
    
    [SerializeField] private Movement _movement;

    [SerializeField] private PutTheBombDown _bombDrop;

    public float bombCD = 0f;

    public GameObject bombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(bombCD);
        //Movement inputs
        if (Input.GetKeyDown(KeyCode.D))
        {
            _movement.MoveRight();
            
            
        }
        
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _movement.MoveUp();
            
            
        }
        
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            _movement.MoveDown();
            
            
            
            
        }
        
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _movement.MoveLeft();
       
            
        }
        //End of movement input
        //Drop bomb

        if (bombCD <= 0)
        {
            if (bombCD < 0)
            {
                bombCD = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("I'M DROPPING A BOMB");
                _bombDrop.DropBomb();
                bombCD = 3f;

            }
        }

        else if (bombCD>0)
        {
            bombCD = bombCD - Time.deltaTime;
        }

        //End of Drop bomb
        
        
        if (!isAlive)///Death and launch of the death scene
        {
            Destroy(gameObject);
            //SceneManager.LoadScene("DefeatScene");
            Debug.Log("You're dead.");
        }
    }
}
