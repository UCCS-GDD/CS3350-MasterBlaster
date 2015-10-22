using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    GameObject toMove;
    Vector3 pixelpos;
    GameObject transformObject;

    // Use this for initialization
    void Start()
    {
        //since we don't need rotation, we can constrain the z position right away
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //if mouse is pressed
        if (Input.GetMouseButtonDown(0))
        {
            //get mouse posiiton and set its depth
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 5f;

            //see where the mouse is in terms of world coordinates
            Vector2 v = Camera.main.ScreenToWorldPoint(mousePosition);

            //get the colliders the mouse is over
            Collider2D col = Physics2D.OverlapPoint(v);

            //if the mouse is over something
            if (col != null)
            {
                //set the shape that can be moved to the colliders the mouse is pressing

                Debug.Log("Collided with: " + col.gameObject.name);
                toMove = col.gameObject.transform.parent.gameObject;
                //toMove.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, 0);

            }
        }

        if (toMove != null && gameObject == toMove)
        {
            Debug.Log("ToMove: " + toMove);
            //Debug.Log("ToMove.position: " + toMove.position);
            //Debug.Log("ToMove.transform.position: " + toMove.transform.position);
            // pixelpos = Camera.main.WorldToScreenPoint(toMove.transform.position);

            //                                            Debug.Log("pixelpos " + pixelpos.ToString());

            if (Input.GetKeyDown(KeyCode.A) && toMove.tag != "Stationary")
            {
                //pixelpos.x -= 1;
                //Vector3 pixelToMove = Camera.main.ScreenToWorldPoint(new Vector3(pixelpos.x - 1, pixelpos.y, pixelpos.z));
                //Debug.Log("pixeltomove " + pixelToMove);

                // toMove.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(-0.0005f, 0), ForceMode2D.Impulse);
                //toMove.transform.parent.position -= new Vector3(1, 0);
                toMove.transform.position -= new Vector3(1, 0);

            }
            else if (Input.GetKeyDown(KeyCode.D) && toMove.tag != "Stationary")
            {
                toMove.transform.position += new Vector3(1, 0);
            }
            //Debug.Log("ToMove: " + toMove);
            //Debug.Log("ToMove.position: " + toMove.position);
            //Debug.Log("ToMove.transform.position: " + toMove.transform.position);
        }

        //if A is pressed and we have an object selected, move the shape left

        //see where the player is relative to screen coordiinates - which are 0 to 1
        Vector3 pos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        //Debug.Log("POS: " + pos.ToString());

        //if our block is on the edge of the screen, set its velocity to 0 and set its position back to the edge of the screen
        if (pos.x < 0.03f)
        {
            pos.x = 0.03f;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }
        if (pos.x > 0.97f)
        {
            pos.x = 0.97f;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        //put our pos variable back into world coordinates and use that to determine the turret's position
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        //Debug.Log(toMove);
        if (gameObject.tag == "Stationary")
        {
            //Debug.Log("SETTING TO STATIONARY");
            Transform[] childTs = GetComponentsInChildren<Transform>();

            foreach (Transform trans in childTs)
            {
                trans.gameObject.tag = "Stationary";
            }
            //Destroy(gameObject);
        }

        //see where the shapes are relative to the screen




        //if the shape is not at the bottom of the screen the shape can fall down
        if (pos.y > 0)
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);

        }


    }

    void FixedUpdate()
    {



    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //test to see if it hits specific shapes will it stop moving - also did not work nor did the tag work
        if (coll.gameObject.tag == "Stationary")
        {
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.tag = "Stationary";
        }
    }


}