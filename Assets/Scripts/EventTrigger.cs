using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public GameEvent Event;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Event.Raise();
        }
    }
}