using UnityEngine;

public class SpriteDirectionalController : MonoBehaviour
{
    [SerializeField] float backAngle = 65f;
    [SerializeField] float sideAngle = 155f;
    [SerializeField] Transform mainTransform;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void LateUpdate()
    {
        // Camera x and z componenets
        Vector3 camForwardVector = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
        // Store angle in relation to the x and z axis from our camera
        float signedAngle = Vector3.SignedAngle(mainTransform.forward, camForwardVector, Vector3.up);
        // Store values to pass into animator
        Vector2 animationDirection = new Vector2(0f, -1f);
        // Dynamic variable to change the parameter if angle is too low
        float angle = Mathf.Abs(signedAngle);

        // Play certain animations depending on which angle is greater
        if (angle < backAngle)
            animationDirection = new Vector2(0f, -1f); // Back animation
        else if (angle < sideAngle)
            animationDirection = new Vector2(1f, 0f); // Side animation
        else
            animationDirection = new Vector2(0f, 1f); // Front animation

        animator.SetFloat("moveX", animationDirection.x);
        animator.SetFloat("moveY",animationDirection.y);    

    }
}
