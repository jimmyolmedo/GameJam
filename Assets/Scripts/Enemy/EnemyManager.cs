using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    protected override bool persistent => false;

    private List<EnemyMovement> enemys = new List<EnemyMovement>();

    //arreglo de limites, los primeros 2 seran las coordenadas de x y las otras 2 coordenadas de y 
    public float[] limits {  get; private set; } = new float[4] {-9.45f, 9.45f, 5.25f, -5.25f};

    protected override void Awake()
    {
        base.Awake();
    }

    public void AddEnemy(EnemyMovement _enemy)
    {
        enemys.Add(_enemy);
    }
}
