using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    int spawnCount;//contador que ira aumentando cuando el juegador encuentre a la novia, al llegar a cierto numero se spawnearan enemigos

    private void OnEnable()
    {
        GirlFriend.OnActive += CounterSpawnPoint;
    }

    private void OnDisable()
    {
        GirlFriend.OnActive -= CounterSpawnPoint;
    }

    void Spawn()
    {
        //preguntar que tan avanzada va la partida

        //asignar un numero aleatorio de enemigos que se espawnearan

        //spawnear enemigos en un lugar aleatorio entre los limites de x e y
    }

    void CounterSpawnPoint()
    {
        //sumarle 1 al contador, cuando llegue a 3 activar la funcion spawn
        Debug.Log("le sume al contador");

        spawnCount++;
        if(spawnCount >= 3)
        {
            Spawn();
            spawnCount = 0;
        }
    }
}
