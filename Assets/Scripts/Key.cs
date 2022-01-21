using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Key : MonoBehaviour
{
    public string keyColor;
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt(name + SceneManager.GetActiveScene().name, 0) == 1)
        {
            Destroy(this.gameObject);
            return;
        }
        // nothing else happens
    }

    public void Take()
    {
        PlayerPrefs.SetInt(name + SceneManager.GetActiveScene().name, 1);
        Destroy(this.gameObject);
    }
}
