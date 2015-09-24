using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour {
    Rigidbody2D turretRigid;
    public GameObject bullet;
    float timeDown;

    float minScreenBounds;
    float maxScreenBounds;

	// Use this for initialization
	void Start () {

         timeDown = 0;
         turretRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turretRigid.AddForce(new Vector2(-0.4f, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            turretRigid.AddForce(new Vector2(0.4f, 0), ForceMode2D.Impulse);
        }

    }
        void Update () {
           

            timeDown -= Time.deltaTime; 
          if (Input.GetKey(KeyCode.Space) && timeDown <= 0)
         {
          Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), bullet.transform.rotation);
          timeDown = 0.5f;
         }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        

	}
  
}
