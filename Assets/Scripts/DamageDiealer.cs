using UnityEngine;

public class DamageDiealer : MonoBehaviour
{
    [SerializeField] private float damage = 25f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<HealthHolder>().GetDamage(damage);
        }
        Destroy(gameObject);
    }

}
