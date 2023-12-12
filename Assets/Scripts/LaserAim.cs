using UnityEngine;
using UnityEngine.InputSystem;

public class LaserAim : MonoBehaviour
{
    [SerializeField] private Transform holder;
    [SerializeField] private float laserRange = 50f;

    LineRenderer laserLine;

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Touchscreen.current.press.isPressed && !CanvaControle.isPaused)
        {
            laserLine.enabled = true;
            Ray ray = new Ray(holder.position, holder.forward);
            bool cast = Physics.Raycast(ray, out RaycastHit hit, laserRange);
            Vector3 hitPosition = cast ? hit.point : holder.position + holder.forward * laserRange;
            laserLine.SetPosition(0, holder.position);
            laserLine.SetPosition(1, hitPosition);
        }
        else
        {
            laserLine.enabled = false;
        }
    }
}
