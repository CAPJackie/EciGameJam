using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public int speed = 10;
    public int jumpForce = 6;
    private Rigidbody2D rb;
    private bool isGrounded;
    public static bool itemPicked = false;
    public static bool keyItemPicked = false;
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)){
            float translation = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            transform.Translate(translation, 0, 0);
        }

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0.0F, 2.0F) * jumpForce, ForceMode2D.Impulse);
        }

        Debug.Log(itemPicked);
        
	}

    void OnCollisionStay2D()
    {
        isGrounded = true;
    }

    void OnCollisionExit2D()
    {
        isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Finish") && itemPicked){
            itemPicked = false;
        }
    }
}