using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10;
    int damage = 20;
    int damageToEnemy = 20;
    Vector3 direction;
    

    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
        speed += 1f;
    }
    public void MakeSniper()
    {
        speed = 50;
        damage = 50;
    }

    public void MakePlayerSniper()
    {
        speed = 70;
    }
    
    public void NoFriendlyFire()
    {
        damage = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().EnemyChangeHealth(-damageToEnemy);
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerController>().ChangeHealth(-damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
