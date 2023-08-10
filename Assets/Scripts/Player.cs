using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed = 5f;
    private Vector2 targetposition;

    public GameObject RestartPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            SetTargetPosition();
        }

        Move();
    }

    void SetTargetPosition() {
        targetposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move() {

        Vector2 direction = new Vector2(targetposition.x - transform.position.x, targetposition.y - transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, targetposition, Speed*Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

            RestartPanel.SetActive(true);

        }
    }

}


