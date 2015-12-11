using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour {

    Rigidbody2D turretRigid;  //store rigidbody of turret
    public GameObject bullet;  //store  gameobject of bullet
    float timeDown;            //used for how often turret can shoot
    AudioSource movementsound;
    public AudioClip movementclip;

    //Pickup fields
    public GameObject Bomb;
    Vector2 ShootingForce;


	// Use this for initialization
	void Start () {
        //start off being able to shoot and assign the rigidbody to the variable
         timeDown = 0;
         turretRigid = GetComponent<Rigidbody2D>();
         movementsound = GetComponent<AudioSource>();
         BlockChild.score = 0;
        ShootingForce = new Vector2(0, 10);
	}
	

    void FixedUpdate()
    {
        //if the left or right arrow key is pressed add a force in the right direction
        if (Input.GetKey(KeyCode.A))
        {
            turretRigid.AddForce(new Vector2(-0.4f, 0), ForceMode2D.Impulse);            
        }
        if (Input.GetKey(KeyCode.D))
        {
            turretRigid.AddForce(new Vector2(0.4f, 0), ForceMode2D.Impulse);
        }
        if(Mathf.Abs(turretRigid.velocity.x) > 4 && !movementsound.isPlaying)
        {
              movementsound.Play();
        }
        if (Mathf.Abs(turretRigid.velocity.x) <3)
        {
            movementsound.Stop();
        }
        
    }

    // Update is called once per frame
        void Update () {

            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    //turretRigid.AddForce(new Vector2(-0.4f, 0), ForceMode2D.Impulse);
            //    transform.Translate(-1, 0, 0);
            //}
            //if (Input.GetKeyDown(KeyCode.D))
            //{
            //    //turretRigid.AddForce(new Vector2(0.4f, 0), ForceMode2D.Impulse);
            //    transform.Translate(1, 0, 0);
            //}

            //have our time constantly going down
            timeDown -= Time.deltaTime; 

            //see where the player is relative to screen coordiinates - which are 0 to 1
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
           
            //if our turret is on the edge of the screen, set its velocity to 0 and set its position back to the edge of the screen
            if (pos.x < 0.07f)
            {
                pos.x = 0.07f;
                turretRigid.velocity = new Vector2(0, 0);
            }
            if (pos.x > 0.97f)
            {
                pos.x = 0.97f;
                turretRigid.velocity = new Vector2(0, 0);
            }
            
            //put our pos variable back into world coordinates and use that to determine the turret's position
            transform.position = Camera.main.ViewportToWorldPoint(pos);


           //if space is pressed and it is time to shoot a bullet...
          if (Input.GetKey(KeyCode.Space) && timeDown <= 0)
         {
            //insantiate a bullet and set the delay time between shooting
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            timeDown = 0.8f;
         }

        //if escape is pressed exit the  game
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        

	}
    public void HandleShootPickupEvent(Image pickupImage)
    {
        Debug.Log("puckup Projectile name " + pickupImage.sprite.name);
        if ( pickupImage.enabled && pickupImage.sprite.name == "Bomb")
        {
            GameObject bomb = Instantiate(Bomb, new Vector3(turretRigid.transform.position.x, turretRigid.transform.position.y +1), Quaternion.Euler(0,0,0)) as GameObject;
            Debug.Log(bomb.transform.position.ToString());
            bomb.GetComponent<Rigidbody2D>().AddForce(ShootingForce, ForceMode2D.Impulse);
        }
    }
    void OnEnable()
    {
        ShootPickupEvent.HandleShootPickupEventHandler(HandleShootPickupEvent);
    }
    //if you collect a bomb add it to inventory
    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Pickup")
        {
            CollectPickupEvent.FireCollectPickupEventHandler(collider.GetComponent<SpriteRenderer>().sprite);
        }
    }
        void OnGUI()
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 40;
            GUI.Label(new Rect(0, 0, 10, 10), BlockChild.score.ToString(), style);
        }
    void OnDisable()
    {
        ShootPickupEvent.DeregisterShootPickupEventHandler(HandleShootPickupEvent);    }
  
}
