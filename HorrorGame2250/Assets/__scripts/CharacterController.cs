using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{

    //Variables for Player Controller
   
   //text variables
    public Text alertText;
    public Text storyText;

    //game objects player uses
    public GameObject Player;
    public GameObject hand;
    public GameObject leftHand;
    public GameObject spotLight;
    
    //inventory and image pick up declarations
    public Inventory inventory;
    public  UI_Inventory uiInventory;
    public Image img;
    public Image img2;
    public Image img3;
    public Image img4;
    public Image cpuScreen;

    //angle for pick up
    private Vector3 FlashlightAngle = new Vector3(124.943f, 3.28299f, -176.69f);
    
    //boolean variables used for script funtions
    private bool _status = false;
    private bool _fDown = false;
    private bool _pageOneVisted = false;
    private bool _pageTwoVisted = false;
    private bool _pageThreeVisted = false;
    private bool _pageFourVisted = false;
    private bool _bootFound = false;
    private bool _isGrounded;
    public bool imgStatus;

    //audio source for sound effects
    public AudioSource playerHit;

    //varaibles to help track scene
    Scene m_Scene;
    string sceneName;


    //static variables for the controller player
    public static int health = 100;
    public static int score = 0;

   
    //variable for selection screen
    private readonly string selectedCharacter = "SelectedCharacter";


    //varibale that controls player speed
    public float speed;


    //Start is called before the first frame update
    void Start()
    {
        //in accordance to selection screen, player selecttion 
        //controls speed and health of character instance
        int getCharacter;
        getCharacter = PlayerPrefs.GetInt(selectedCharacter);
        switch (getCharacter)
        {
            case 1:
                speed = 23.0f;
                health = 100;
                break;
            case 2:
                speed = 17.0f;
                health = 70;
                break;
            case 3:
                speed = 10.0f;
                health = 200;
                break;
            default:
                speed = 17.0f;
                health = 100;
                break;
        }

        //locks cursor
        Cursor.lockState = CursorLockMode.Locked;

        //resets HUD on start, clearing the display
        ResetText();
        img.enabled = false;
        img2.enabled = false;
        img3.enabled = false;
        img4.enabled = false;
        cpuScreen.enabled = false;
       

        //scene checker, deals with player respawning labels, as well as score 
        if (SceneManager.GetActiveScene().name == "SamLevel")
        {
            score = score + 5;
            CheckLight();
            alertText.text = "Level 2: The Maze";
            Invoke("ResetText", 2);
        }
    }

    //awake function sets and declares new inventory for the player to use throughout the game
    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
       
    }

    // Update is called once per frame
    void Update()
    {
        //movement variables 
        float translation;
        float strafe;
        CheckLight();

        //movement controls for sprint and regular movement
        if (Input.GetKey(KeyCode.LeftShift) && _bootFound)
        {
            translation = Input.GetAxis("Vertical") * speed * 2f;
            strafe = Input.GetAxis("Horizontal") * speed * 1.5f;
        }
        else
        {
            translation = Input.GetAxis("Vertical") * speed * 1.0f;
            strafe = Input.GetAxis("Horizontal") * speed * 1.0f;
        }
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;
        transform.Translate(strafe, 0, translation);

        //unlocks cursor to exit game
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        //checks if F is being pressed, sets variable
        if (Input.GetKeyDown("f"))
        {   
            //logs to console
            Debug.Log("F press");
            _fDown = true;
        }else {
            _fDown = false;
        }

    }

    //on trigger, when player collides with trigger game objects
    public void OnTriggerEnter(Collider col)
    {
        //deals with pick ups
        if (col.gameObject.tag == "PickUp")
        {
            Debug.Log("Pickup Detected");
            ItemFoundCalled();
            if (Input.GetKey("f"))
            {
                //adds to score and sets object using function call
                 score = score + 2;
                Debug.Log("Call from inside");
                SetObject(col.gameObject);
                //clear alert
                ResetText();
                Debug.Log("Object being set");
            }
        }
        //deals with story pages
        if (col.gameObject.tag == "StoryPage")
        {
            Debug.Log("StoryPage Detected");
            StoryPageFoundCalled();
            
            if (Input.GetKey("f"))
            {
                //adds to score and sets inv
                score++;
                Debug.Log("Call from inside");
                ViewStoryPage(col.gameObject);
                //clear alert
                ResetText();
                Debug.Log("Object being set");
            }
        }

        //deals with boot that allows sprint
        if (col.gameObject.tag == "Boot")
        {
            Debug.Log("Boot Detected");
            BootFoundCalled();
            if (Input.GetKey("f"))
            {
                //sets score and inv
                score = score + 2;
                Debug.Log("Call from inside");
                SetObject(col.gameObject);
                ResetText();
                Debug.Log("Object being set");
            }
        }

        //function to view computer screen
        if (col.gameObject.tag == "cpu"){
             alertText.text = "~Hold F to View Computer ~";
              if (Input.GetKey("f"))
            {
                score = score + 2;
                ResetText();
                imgStatus = true;
                cpuScreen.enabled = imgStatus;
                
            }
         }

        //function to add progression at spawns
         if (col.gameObject.tag == "spawn"){
             score = score + 5;
             health = health + score;
         }
    }

    //secondary functions to help display alerts to player upon collisions
    public void ItemFoundCalled()
    {
        alertText.text = "~Item Found - Hold F to Pick Up~";
    }

    public void StoryPageFoundCalled()
    {
        alertText.text = "~Story Page Found - Hold F to View ~";
    }

    public void BootFoundCalled()
    {
        alertText.text = "~Boots Found - Hold F to Pick Up - Use Left Shift To Sprint ~";
    }

    //function to reset alert text
    public void ResetText()
    {
        alertText.text = "";

    }

    //function to activate flashlight
    public void CheckLight()
    {
        spotLight.SetActive(_status);
    }

    //inventory and player setting function
    public void SetObject(GameObject goItem)
    {
        ResetText();

        //deals with flashlight pick up and setting it in player hand abd inventory
        if (goItem.name == "Flashlight")
        {
            goItem.transform.parent = hand.transform;
            goItem.transform.eulerAngles = FlashlightAngle;
            goItem.transform.position = hand.transform.position;

            _status = true;
            CheckLight();
            inventory.AddItem(new PickUpItem { itemType = PickUpItem.ItemType.Flashlight, amount = 1 });
            uiInventory.SetInventory(inventory);
        }

        //deals with gun pick up and setting it in player hand and inventory
        if (goItem.name == "Gun")
        {
            goItem.transform.parent = leftHand.transform;
            goItem.transform.eulerAngles = FlashlightAngle;
            goItem.transform.position = leftHand.transform.position;
            inventory.AddItem(new PickUpItem { itemType = PickUpItem.ItemType.Gun, amount = 1 });
        }
        //deals with boot pickup and setting it in inventory 
        if (goItem.name == "Boot")
        {
            _bootFound = true;
            inventory.AddItem(new PickUpItem { itemType = PickUpItem.ItemType.Boot, amount = 1 });
        }

    }

    //function that allows user to view story pages dfound
    public void ViewStoryPage(GameObject goItem)
    {
        //each fucntions deals with each seprarte story page and displaying it
        if (goItem.name == "StoryPage1")
        {
            imgStatus = true;
            img.enabled = imgStatus;
            if (!_pageOneVisted)
            {
                inventory.AddItem(new PickUpItem { itemType = PickUpItem.ItemType.Map, amount = 1 });
                uiInventory.SetInventory(inventory);
                _pageOneVisted = true;
            }
        }

        // same for page 2
        if (goItem.name == "StoryPage2")
        {
            imgStatus = true;
            img2.enabled = imgStatus;
            if (!_pageTwoVisted)
            {
                inventory.AddItem(new PickUpItem { itemType = PickUpItem.ItemType.Map, amount = 1 });
                uiInventory.SetInventory(inventory);
                _pageTwoVisted = true;
            }
        }

        // same for page 3
        if (goItem.name == "StoryPage3")
        {
            imgStatus = true;
            img3.enabled = imgStatus;
            if (!_pageThreeVisted)
            {
                inventory.AddItem(new PickUpItem { itemType = PickUpItem.ItemType.Map, amount = 1 });
                uiInventory.SetInventory(inventory);
                _pageThreeVisted = true;
            }
        }
        // same for page 4
        if (goItem.name == "StoryPage4")
        {
            imgStatus = true;
            img4.enabled = imgStatus;
            if (!_pageFourVisted)
            {
                inventory.AddItem(new PickUpItem { itemType = PickUpItem.ItemType.Map, amount = 1 });
                uiInventory.SetInventory(inventory);
                _pageFourVisted = true;
            }
        }
    }

    //function to deal with exit collison with story page and setting HUD accoridngly 
    public void ExitStoryPage()
    { 
        imgStatus = false;
        img.enabled = imgStatus;
        img2.enabled = imgStatus;
        img3.enabled = imgStatus;
        img4.enabled = imgStatus;
        cpuScreen.enabled = imgStatus;
    }

    //function that lets player take damage
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            //triggers death is health = 0
            Die();
        }
    }

    //function that deals with death of player and respawn to curretn level accordingly
    void Die()
    {
        if(SceneManager.GetActiveScene().name == "SamLevel"){
            alertText.text = "You Died - Level Restarting";
            SceneManager.LoadScene("SamLevel");
            DontDestroyOnLoad(gameObject);
            gameObject.transform.position = new Vector3(596.4005f,2.31f,716.5336f);
            health = 100;
            Invoke("ResetText",3);
        }

    }

    //trigger exit function 
    void OnTriggerExit(Collider col)
    {
        ResetText();
        ExitStoryPage();
    }

    



}
