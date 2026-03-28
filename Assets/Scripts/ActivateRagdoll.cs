using UnityEngine;

public class ActivateRagdoll : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void Start()
    {
        if (anim == null)
            anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (anim == null) return;

            if (anim.enabled == true)
                anim.enabled = false;
            else if (anim.enabled == false)
                anim.enabled = true;
        }
    }
}
