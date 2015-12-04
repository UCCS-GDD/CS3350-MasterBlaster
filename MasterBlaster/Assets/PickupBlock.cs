using UnityEngine;
using System.Collections;

public class PickupBlock : MonoBehaviour {
    //public static int score;
    public static GameObject gridPos;
    public GameObject bomb;
    //int count = 0;
    int maxCount = 10;
    //public static int count1 = 0;
    AudioSource destructionSound;


    // Use this for initialization
    void Start()
    {
        destructionSound = GetComponentInParent<AudioSource>();
        //ScoringGrid.blocks.Add(gameObject);
    }

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        //if they are at the bottom of the screen turn the parent's rigidbody off and it SHOULD set a tag
        if (pos.y < 0.043)
        {
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //GetComponent<Rigidbody2D>().isKinematic = true;
            transform.parent.tag = "Stationary";
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //if the block is hit by a bullet, destroy the bullet and block
        if (coll.gameObject.tag == "Bullet" && gameObject.tag != "Stationary")
        {

            Instantiate(bomb, transform.position, Quaternion.Euler(0, 0, 0));
            destructionSound.Play();
            //score += 5;
            Destroy(gameObject);
            Destroy(coll.gameObject);
            if (destructionSound.time >= 2)
            {
                destructionSound.Stop();
            }


        }
        //if (coll.gameObject.tag == )
    }
}
