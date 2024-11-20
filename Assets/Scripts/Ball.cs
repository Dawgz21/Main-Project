using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LineRenderer lr;

    [SerializeField] private float maxPower = 10f;
    [SerializeField] private float power = 2f;
    [SerializeField] private float maxGoalSpeed = 5f;

    private bool isClicking;
    private bool scored;
    //this will be to shoot the ball and check if the ball has gone in the hole
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private bool IsMoving()
    {
        return rb.velocity.magnitude > 0.15f;
    }

    private void PlayerInput()
    {
        if (IsMoving())
        {
            return;
        }
        Vector2 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(transform.position, inputPos);

        if (Input.GetMouseButtonDown(0) && distance <= 0.5f) ClickStart();
        if (Input.GetMouseButton(0) && isClicking) ClickChange(inputPos);
        if (Input.GetMouseButtonUp(0) && isClicking) ClickRelease(inputPos);
    }

    private void ClickStart()
    {
        isClicking = true;
        lr.positionCount = 2;
    }

    private void ClickChange(Vector2 pos)
    {
        Vector2 dir = (Vector2)transform.position - pos;

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, (Vector2)transform.position + Vector2.ClampMagnitude((dir * power) / 2, maxPower / 2)); 
    }

    private void ClickRelease(Vector2 pos)
    {
        float distance = Vector2.Distance((Vector2)transform.position, pos);
        isClicking = false;
        lr.positionCount = 0;

        if (distance < 1f)
        {
            return;
        }

        Levels.main.IncreaseStroke();

        Vector2 dir = (Vector2)transform.position - pos;

        rb.velocity = Vector2.ClampMagnitude(dir * power, maxPower);
    }

    private void CheckWinState()
    {
        if (scored) return;

        if(rb.velocity.magnitude <= maxGoalSpeed)
        {
            scored = true;

            rb.velocity = Vector2.zero;
            gameObject.SetActive(false);

            Levels.main.LevelFinished();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hole") CheckWinState();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Hole") CheckWinState();
    }
}
