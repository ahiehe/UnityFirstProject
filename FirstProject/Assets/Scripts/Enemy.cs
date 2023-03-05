using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    protected int damage; //урон который враг наносит
    protected int health; //здоровье врага
    protected GameObject player; //Информация о игроке
    bool dead = false; //Мертвый ли враг
    protected SpawnManager _spawnManager;

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


    public void OnDeath() //Умирают враги одинаково
    {
        dead = true;
        _spawnManager.EnemyDefeated();
        GetComponent<Animator>().SetBool("death", true); //изменили параметр анимации
        GetComponent<CharacterController>().enabled = false; //отключили коллайдер
    }
    
    
    
    private void Update() //Если враг не мертв, он двигается и атакует
    {
        if (!dead)
        {
            Move();
            Attack();
        }
    }
}