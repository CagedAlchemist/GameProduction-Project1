using UnityEngine;

public class LightHit : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject guard;
    public Animator animate;
    public Light flashlight;
    public float playerRange = 5f;
    void Update()
    {
        if (flashlight.enabled)
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, playerRange))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.name == guard.name)
                {
                    animate.SetBool("isBlind", true);
                }
            }
            
        }
    }
}
