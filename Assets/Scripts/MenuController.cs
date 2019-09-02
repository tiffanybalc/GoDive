using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public static MenuController instance;

    //Outlets
    public GameObject mainMenu;
    public GameObject optionsMenu;

    //Methods
    void Awake()
    {
        instance = this;
        Hide();
    }

    public void Show() {
        ShowMainMenu();
        gameObject.SetActive(true);
        Time.timeScale = 0;
        scubadiver.instance.isPaused = true;
    }

    public void Hide() {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        if(scubadiver.instance != null) {
            scubadiver.instance.isPaused = false;
        }
    }

    void SwitchMenu(GameObject someMenu) {
        //Turn off all menus
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);

        //Turn on requested menu
        someMenu.SetActive(true);
    }

    public void ShowMainMenu() {
        SwitchMenu(mainMenu);
    }

    public void ShowOptionsMenu() {
        SwitchMenu(optionsMenu);
    }

    public void ResetScore() {
        PlayerPrefs.DeleteKey("Score");
        scubadiver.instance.score = 0;
        PlayerPrefs.DeleteKey("Health");
        scubadiver.instance.health = 100f;
        PlayerPrefs.SetFloat("Health", 100f);
        scubadiver.instance.imageHealthBar.fillAmount = scubadiver.instance.health / scubadiver.instance.healthMax;
    }

    public void LoadLevel() {
        SceneManager.LoadScene("SampleScene-3D");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
