using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    
    public int damage; //урон который враг наносит
    public int health; //здоровье врага
    protected GameObject player; //Информация о игроке
    bool dead = false; //Мертвый ли враг
    protected SpawnManager _spawnManager;
    public GameObject dropedHeal;
    public GameObject dropedAmmo;
    public Slider HB;


    public virtual void Move() //Враг может как-то двигаться
    {

    }
    public virtual void Attack() //Враг может как-то атаковать
    {

    }
    void Start()
    {
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        player = FindObjectOfType<PlayerController>().gameObject; //Находим игрока
    }

    public void EnemyChangeHealth(int count)
    {
        health = health + count;
        print("damage");
        if (health <= 0) 
        {
            OnDeath();
        }
    }


    public void OnDeath() //Умирают враги одинаково
    {
        dead = true;
        GetComponent<CharacterController>().enabled = false; 
        var anyEvent = Random.Range(1, 9);
        if ((1<= anyEvent) && (anyEvent < 3)){
            Vector3 pos = transform.position + new Vector3(0,1,0);
            GameObject dropHeal = Instantiate(dropedHeal,pos, Quaternion.identity); 
        }

        if ((3< anyEvent) && (anyEvent < 5)){
            Vector3 pos = transform.position + new Vector3(0,1,0);
            GameObject dropAmmo = Instantiate(dropedAmmo,pos, Quaternion.identity); 
        }
        player.GetComponent<PlayerController>().ChangeCoins(Random.Range(80, 90));
        
        _spawnManager.EnemyDefeated();
        Destroy(gameObject);
        
    }
    
    
    
    private void Update() //Если враг не мертв, он двигается и атакует
    {
        
        if (!dead)
        {
           
            Move();
            Attack();
        }
        HB.value = health;
    }
}