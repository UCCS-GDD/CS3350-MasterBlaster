using UnityEngine;
using System.Collections;


public class BlockChild : MonoBehaviour {
   

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

       if (pos.y < 0.05f)
        { 
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.tag = "Stationary";
        }

	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {

            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }

}
