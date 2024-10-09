using UnityEngine;
using UnityEngine.InputSystem;
public class NoteDestroy : MonoBehaviour
{
    private InputSystem_Actions controls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool Jump = false;
    float waitTime = 0.25f;
    float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Jump)
        {
            timer-=Time.deltaTime;
            if (timer <= 0)
            {
                Jump = false;
                timer = waitTime;
            }
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
       Jump = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Jump)
        {

            Destroy(other.gameObject);
            Jump = false;
        }
    }
}
