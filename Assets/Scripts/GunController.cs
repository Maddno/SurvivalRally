using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    [Header("Controll")]
    [SerializeField] private float speed = 1.0f;
    [SerializeField] GameObject gun;

    [Header("Damage")]
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float bulletSpeed = 200f;
    [SerializeField] private float carDamage = 1000f;
    [SerializeField] private float gunRate = 5f;
    [SerializeField] private float bulletDesteoyTime = 0.7f;

    private bool isShooting = false;
    private float bulletAcceleration = 10f;

    private void Update()
    {
        OnAttack();
    }

    private void OnMouseDrag()
    {
        float xAxisRotation = Touchscreen.current.primaryTouch.delta.x.ReadValue() * speed * Time.deltaTime;
        
        gun.transform.Rotate(Vector3.up, -xAxisRotation);

    }

    private void OnAttack()
    {
        if (!isShooting && Touchscreen.current.press.isPressed && !CanvaControle.isPaused)
        {
            muzzleFlash.Play();
            GameObject projectailObj = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            Rigidbody projectailRB = projectailObj.GetComponent<Rigidbody>();
            projectailRB.AddForce(projectailRB.transform.forward * bulletSpeed * bulletAcceleration);
            Destroy(projectailObj, bulletDesteoyTime);

            isShooting = true;
            Invoke(nameof(ResetAttack), gunRate);
        }
    }
    private void ResetAttack()
    {
        isShooting = false;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<HealthHolder>().GetDamage(carDamage);
        }
    }
}
  