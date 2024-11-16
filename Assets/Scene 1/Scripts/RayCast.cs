using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public float rayDistance = 100f; // Maximum distance for the raycast

    void Update()
    {
        // Create a ray from the camera's position and direction
        Ray ray = new Ray(transform.position, transform.forward);

        // Always draw the ray in the Scene view (but not in the Game view)
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        // Perform the actual raycast when left mouse button is clicked
        if (Input.GetMouseButtonDown(0)) // Left-click to trigger the raycast
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name); // Log the name of the object hit by the ray

                // Optional: Interact with objects that have a specific tag
                if (hit.collider.CompareTag("Interactable"))
                {
                    Debug.Log("Interacted with " + hit.collider.gameObject.name);
                }
            }
            else
            {
                Debug.Log("No hit detected.");
            }
        }
    }
    public Color rayColor = Color.red; // Color of the ray

    // This method is called by Unity to draw Gizmos in the Scene View
    void OnDrawGizmos()
    {
        // Set the color of the Gizmo (the ray)
        Gizmos.color = rayColor;

        // Draw a ray from the camera's position forward
        Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
    }
}

