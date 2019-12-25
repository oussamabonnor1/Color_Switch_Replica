using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraBehaviour : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > transform.position.y)
            transform.position = new Vector3(0, player.position.y, transform.position.z);
        if(player.transform.position.y + transform.position.y < -7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
