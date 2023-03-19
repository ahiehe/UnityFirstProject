using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    
    public int damage = 1; //урон который враг наносит
    public int health = 1; //здоровье врага
    protected GameObject player; //Информация о игроке
    bool dead = false; //Мертвый ли враг
    protected SpawnManager _spawnManager;
    public GameObject dropedHeal;
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
        _spawnManager.EnemyDefeated();
        var anyEvent = Random.Range(1, 9);
        if ((1<= anyEvent) && (anyEvent < 3)){
            Vector3 pos = transform.position + new Vector3(0,1,0);
            GameObject apt = Instantiate(dropedHeal,pos, Quaternion.identity); 
        }
        Destroy(gameObject);
    }
    
    
    
    private void Update() //Если враг не мертв, он двигается и атакует
    {
        HB.value = health;
        if (!dead)
        {
           
            Move();
            Attack();
        }
    }
}