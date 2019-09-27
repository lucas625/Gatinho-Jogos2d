using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    public float upForce = 200;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb2d.Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.IsStarted()) {
            StartMoving();
        }
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
    }

    // checks if the cat is dead.
    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameController.instance.CatDied();
    }

    // Starts the rigidbody
    public void StartMoving()
    {
        rb2d.WakeUp();
    }

}
