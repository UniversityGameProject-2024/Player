using UnityEngine;

public class LampToggle : MonoBehaviour
{
    [SerializeField] public Transform player;
    private Light lampLight;
    private Renderer lampRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lampLight = GetComponent<Light>();
        lampRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < 8f)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Debug.Log("Pressed E near lamp");
                lampLight.enabled = !lampLight.enabled;
                lampRenderer.material.color = lampLight.enabled ? Color.white : Color.gray;
            }
        }

    }
}
