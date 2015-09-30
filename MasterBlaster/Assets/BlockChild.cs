using UnityEngine;
using System.Collections;


public class BlockChild : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.y > 0.02 && transform.parent == null)
        {
            transform.position -= transform.up * Time.deltaTime * 3;
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

        }
        //else if (pos.y < 0.02)
        //{
        //    gameObject.AddComponent<Rigidbody2D>();
        //    GetComponent<Rigidbody2D>().gravityScale = 0;
        //}
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {

            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
      if (coll.gameObject.tag == "Block")
      {
          Debug.Log("hit");
      }
    }
}
