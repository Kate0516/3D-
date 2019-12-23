using UnityEngine;
using Vuforia;

public class butt : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vbs;
    public Animator animator;

    void Start()
    {
        VirtualButtonBehaviour vbb = vbs.GetComponent<VirtualButtonBehaviour>();
        if (vbb)
        {
            vbb.RegisterEventHandler(this);
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Pressed");
        animator.SetBool("isjump", true);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Released");
        animator.SetBool("isjump", false);
    }
}
