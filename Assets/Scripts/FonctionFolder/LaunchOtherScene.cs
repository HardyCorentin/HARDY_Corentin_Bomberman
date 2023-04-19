using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchOtherScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LaunchSoloPlay()
    {

        SceneManager.LoadScene("SoloGameScene");
        Debug.Log("Will launch the 9 by 9 map");
    }

    public void LaunchControlScreen()
    {

        SceneManager.LoadScene("ControlScreen");
    }
    public void LaunchTItleScreen()
    {

        SceneManager.LoadScene("TItleScreen");
    }

}
