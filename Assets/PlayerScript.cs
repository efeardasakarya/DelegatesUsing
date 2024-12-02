using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void ActionDelegate();
    public ActionDelegate spaceDelegate;
    public ActionDelegate shiftDelegate;

    public void Fire()
    {
        Debug.Log("ATEÞ");
    }

    public void Dash()
    {
        Debug.Log("Dash!");
    }

    public void Teleport()
    {
        Debug.Log("Beam me up, Scotty");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spaceDelegate != null)
        {
            spaceDelegate.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && shiftDelegate != null)
        {
            shiftDelegate.Invoke();
        }
    }
}
