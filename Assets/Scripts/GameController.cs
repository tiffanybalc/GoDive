using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    //Outlet
    public GameController gameController;

    //State Tracking
    public bool isGameOver;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
    }

    public void RestartGame() {
        SceneManager.LoadScene("SampleScene");
    }
}
