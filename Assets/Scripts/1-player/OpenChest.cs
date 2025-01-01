using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private Animator animator;
    [SerializeField] public Transform player;

    bool animPlayedOnce = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < 8f)
        {
            if (!animPlayedOnce)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("Pressed E");
                    animator.Play("rotateHinge");
                    animPlayedOnce = true;
                }
            }
        }
    }
}
