using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Wave
{
    public int EnemiesPerWave;
    public GameObject[] Enemy;
    
}

public class SpawnManager : MonoBehaviour
{

    public Wave[] Waves; // class to hold information per wave
    public Transform[] SpawnPoints;
    public float TimeBetweenEnemies = 2f;
    public Text WaveNumb;
    public Text enemiesLeft;
    public GameObject cam;


    private int _totalEnemiesInCurrentWave;
    private int _enemiesInWaveLeft;
    private int _enemiesInWaveKilled;
    private int _spawnedEnemies;

    private int _currentWave;
    private int _totalWaves;
    int wave;

	void Start ()
	{
	    _currentWave = -1; // avoid off by 1
	    _totalWaves = Waves.Length - 1; // adjust, because we're using 0 index

	    StartNextWave();
	}

    void StartNextWave()
    {
        _currentWave++;
        WaveNumb.text = "Волна " + (Promejutok.wave).ToString();

        // win
        if (_currentWave > _totalWaves)
        {
            return;
        }

        _totalEnemiesInCurrentWave = Waves[_currentWave].EnemiesPerWave;
        enemiesLeft.text = "Врагов осталось: " + _totalEnemiesInCurrentWave.ToString();
        _enemiesInWaveLeft = 0;
        _enemiesInWaveKilled = 0;
        _spawnedEnemies = 0;

        StartCoroutine(SpawnEnemies());
    }

    // Coroutine to spawn all of our enemies
    IEnumerator SpawnEnemies()
    {
        
        while (_spawnedEnemies < _totalEnemiesInCurrentWave)
        {
            int EnemyIndex = Random.Range(0, Waves[_currentWave].Enemy.Length);
            GameObject enemy = Waves[_currentWave].Enemy[EnemyIndex];
           
            _spawnedEnemies++;
            _enemiesInWaveLeft++;

            int spawnPointIndex = Random.Range(0, SpawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's 
            // position and rotation.
            
            Instantiate(enemy, SpawnPoints[spawnPointIndex].position, SpawnPoints[spawnPointIndex].rotation);
                
            
            
            yield return new WaitForSeconds(TimeBetweenEnemies);
        }
        yield return null;
    }
    
    
    public void EnemyDefeated()
    {
        _enemiesInWaveLeft--;
        _enemiesInWaveKilled++;
        enemiesLeft.text = "Врагов осталось: " + (_totalEnemiesInCurrentWave - _enemiesInWaveKilled).ToString();
        
        
        if (_enemiesInWaveLeft == 0 && _spawnedEnemies == _totalEnemiesInCurrentWave)
        {   
            Promejutok.wave += 1;
            _enemiesInWaveKilled = 0;
            cam.GetComponent<Menu>().SaveAmmoAndHP();
            SceneManager.LoadScene(1);
        }
    }
}