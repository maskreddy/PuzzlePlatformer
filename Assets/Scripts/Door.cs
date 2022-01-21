using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string keyColor;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(name + SceneManager.GetActiveScene().name, 0) == 1)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    public void Unlock()
    {
        PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name, 1);
        Destroy(this.gameObject);
    }
}
