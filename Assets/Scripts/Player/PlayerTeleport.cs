using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameInputActions _inputActions;
    private GameObject currentTeleporter;
    public AudioSource warpSound;

    void Start()
    {
        _inputActions = new GameInputActions();
        _inputActions.Player.Enable();
    }

    void Update()
    {
        if (_inputActions.Player.Use.WasPerformedThisFrame())
        {
            Debug.Log("Teleport");
            if (currentTeleporter != null)
            {
                warpSound.Play();
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
