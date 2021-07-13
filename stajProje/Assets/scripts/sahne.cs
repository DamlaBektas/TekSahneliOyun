using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahne : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    void Start()
    {
    }

    void Update()
    {
    }
    public void Replay()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
