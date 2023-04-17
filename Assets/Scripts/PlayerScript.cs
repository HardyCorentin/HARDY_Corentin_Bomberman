using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private bool _isAlive = true;
    
    [SerializeField] private Movement _movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement inputs
        if (Input.GetKeyDown(KeyCode.D))
        {
            _movement.MoveRight();
            
            Debug.Log("Right.");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _movement.MoveUp();
            
            Debug.Log("Up.");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _movement.MoveDown();
            
            Debug.Log("Down.");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _movement.MoveLeft();
            
            Debug.Log("Left.");
        }
        //End of movement input
        //Drop bomb
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("I'M DROPPING A BOOOOOOOOOOOOOOOOOOOOOMB !");
        }
        if (!_isAlive)///Death and launch of the death scene
        {
            Destroy(gameObject);
            //SceneManager.LoadScene("DefeatScene");
            Debug.Log("You're dead.");
        }
    }
}
