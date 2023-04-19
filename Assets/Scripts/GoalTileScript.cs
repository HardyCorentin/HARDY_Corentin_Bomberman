using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTileScript : MonoBehaviour
{
    [SerializeField] private LayerMask _default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("IT SUPPOSED TO RELOAD THE SCENE ON OVERLAP");
        
    }
}
