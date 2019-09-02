using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.iOS;

public class scubadiver : MonoBehaviour {

    public static scubadiver instance;


    public Text coinsText;
    public Text winText;
    public Text scoreUI;

    private int coinsCount;
    public int score;
    public bool isPaused;

    Rigidbody rigidbody3D; //was private before
    public Transform aimPivot;
    public GameObject projectilePrefab;
    public GameObject explosionPrefab;
    public Image imageHealthBar;
    Animator animator;
    public float speed = 0.1F;
    //bool isInWater;
    public float healthMax = 100f;
    public float health;
    public float timeElapsed;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        rigidbody3D = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        score = PlayerPrefs.GetInt("Score");
        health = PlayerPrefs.GetFloat("Health");

        imageHealthBar.fillAmount = health / healthMax;
        
        coinsCount = 0;
        SetCoinsText ();
        winText.text = "";
        //isInWater = true;
        isPaused = false;
	}

    void FixedUpdate()
    {
        //This Update Event is synchronized with the Physics Engine
        float height = rigidbody3D.transform.position.y;
        animator.SetFloat("Height", height);
    }

    // Update is called once per frame
    void Update () {
        if(isPaused) {
            return;
        }
        timeElapsed += Time.deltaTime;
        //Update UI
        scoreUI.text = score.ToString(); //causing error so temporarily commented out

        //if(health <= 0) {
            //Die();
        //}
        if(score >= 1000) {
            winText.text = "You won!";
        }

        if(Input.GetKey(KeyCode.Escape)) {
            MenuController.instance.Show();
        }


        float gravity = 6.5f; //in real life, this is 9.8f
        float height = rigidbody3D.transform.position.y;
        if (height < 2.0 && height >= 0) {
            gravity = 6.5f - 2.0f + height;
        }
        else if (height < 0 && height > -7.7) {
            gravity = 4.5f + height;
        }
        else {
            gravity = 0.1f;
        }
        rigidbody3D.AddForce(Vector3.down * gravity);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody3D.AddTorque(new Vector3(0, 1, 0)*-speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody3D.AddTorque(new Vector3(0, 1, 0) * speed);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody3D.AddRelativeForce(new Vector3(0, 0, 5f));

        }

        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            rigidbody3D.AddRelativeForce(new Vector3(0, 0, -5f));

        }

        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody3D.AddRelativeForce(Vector3.up * speed);
        }
        if (Input.GetKey(KeyCode.X)) 
        {
            rigidbody3D.AddRelativeForce(Vector3.down * speed);
        }

        //Aim Toward Mouse
        Vector3 mousePosition = Input.mousePosition;
        //Vector3 mousePositionInWorld = Camera.main.ScreenToViewportPoint(mousePosition);
        //Vector3 directionFromPlayerToMouse = mousePositionInWorld - transform.position;

        //float radiansToMouse = Mathf.Atan2(directionFromPlayerToMouse.y, directionFromPlayerToMouse.x);
        //float angleToMouse = radiansToMouse * 180f / Mathf.PI;

        //aimPivot.rotation = Quaternion.Euler(0, 0, angleToMouse);

        //Shoot
        if(Input.GetMouseButtonDown(0)) {
            GameObject newProjectile = Instantiate(projectilePrefab);
            newProjectile.transform.position = transform.position;
            newProjectile.transform.rotation = aimPivot.rotation;
        }


        /*
            //touch screen inputs
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            rigidbody.AddForce(mousePos / 1000);
            Debug.Log("Left mouse button pressed");
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
            Debug.Log("touch");
        }
        */

    }

    void TakeDamage(float damage) {
        Debug.Log("Take Damage");
        health -= damage;
        PlayerPrefs.SetFloat("Health", health);
        if (score >= 50) {
            score -= 50;
            PlayerPrefs.SetInt("Score", score);
        }
        if (health <= 0) {
            Die();
        }
        imageHealthBar.fillAmount = health / healthMax;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "SeaLife") {
            Debug.Log("Collision with SeaLife");
            TakeDamage(10);
        }
    }

    void Die() {
        winText.text = "You died :(";
        print("You died");

        PlayerPrefs.DeleteKey("Score");
        instance.score = 0;
        PlayerPrefs.DeleteKey("Health");
        instance.health = 100f;
        PlayerPrefs.SetFloat("Health", health);
        SceneManager.LoadScene("SampleScene-3D");
    }


    //was private before
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            coinsCount++;
            SetCoinsText();
        }
    }
    void SetCoinsText() 
    {
        //coinsText.text = "Count: " + coinsCount.ToString();
        if (score >= 1000)
        {
            //winText.text = "You won!";
        }
    }
}
