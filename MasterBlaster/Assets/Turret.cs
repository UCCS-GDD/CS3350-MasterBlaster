using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour {

    Rigidbody2D turretRigid;  //store rigidbody of turret
    public GameObject bullet;  //store  gameobject of bullet
    float timeDown;            //used for how often turret can shoot


	// Use this for initialization
	void Start () {
        //start off being able to shoot and assign the rigidbody to the variable
         timeDown = 0;
         turretRigid = GetComponent<Rigidbody2D>();
         BlockChild.score = 0;
	}
	

    void FixedUpdate()
    {
        //if the left or right arrow key is pressed add a force in the right direction
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turretRigid.AddForce(new Vector2(-0.4f, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            turretRigid.AddForce(new Vector2(0.4f, 0), ForceMode2D.Impulse);
        }
        
    }

    // Update is called once per frame
        void Update () {
            //have our time constantly going down
            timeDown -= Time.deltaTime; 

            //see where the player is relative to screen coordiinates - which are 0 to 1
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
           
            //if our turret is on the edge of the screen, set its velocity to 0 and set its position back to the edge of the screen
            if (pos.x < 0.03f)
            {
                pos.x = 0.03f;
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
            timeDown = 0.5f;
         }

        //if escape is pressed exit the  game
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        

	}
        void OnGUI()
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 40;
            GUI.Label(new Rect(0, 0, 10, 10), BlockChild.score.ToString(), style);
        }
  
}
