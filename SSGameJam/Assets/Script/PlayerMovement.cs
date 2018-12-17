using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject arms;
    public Animator animator;
    public GameObject CraftingMenu;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.Tab))
        {
            CraftingMenu.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            CraftingMenu.SetActive(false);
        }

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement = moveInput.normalized * speed;

        //animator.SetFloat("Horizontal", moveInput.x);
        //animator.SetFloat("Vertical", moveInput.y);

        if (moveInput.x == -1 && (moveInput.y >= 0 || moveInput.y <= 0))
        {
            arms.transform.rotation = Quaternion.Euler(0, 0, 180);
            animator.SetFloat("Horizontal", -1);
            animator.SetFloat("Vertical", 0);
        }
        if (moveInput.x == 1 && (moveInput.y >= 0 || moveInput.y <= 0))
        {
            arms.transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
        }

        if (moveInput.y == -1 && (moveInput.x >= 0 || moveInput.x <= 0))
        {
            arms.transform.rotation = Quaternion.Euler(0, 0, -90);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", -1);
        }
        if (moveInput.y == 1 && (moveInput.x >= 0 || moveInput.x <= 0))
        {
            arms.transform.rotation = Quaternion.Euler(0, 0, 90);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 1);
        }


        if (moveInput.x == 1 && moveInput.y == 1)
            arms.transform.rotation = Quaternion.Euler(0, 0, 45);
        if (moveInput.x == 1 && moveInput.y == -1)
            arms.transform.rotation = Quaternion.Euler(0, 0, -45);
        if (moveInput.x == -1 && moveInput.y == 1)
            arms.transform.rotation = Quaternion.Euler(0, 0, 135);
        if (moveInput.x == -1 && moveInput.y == -1)
            arms.transform.rotation = Quaternion.Euler(0, 0, 225);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x, movement.y);
    }
}
