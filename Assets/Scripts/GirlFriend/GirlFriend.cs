using UnityEngine;

public class GirlFriend : Singleton<GirlFriend>
{
    //properties

    protected override bool persistent => false;

    //variables

    //tiempo que espera a que el jugador llegue a ella
    [SerializeField] float timeLimit;
    //evento de cSharp en el que se pueda suscribir el spawner para contar
    public static event System.Action OnActive;
    //arreglo con las posibles ubicaciones
    [SerializeField] Transform[] ubications;


    //method

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, .7f);

        foreach (Collider2D col in collider)
        {
            if(col.TryGetComponent(out PlayerVision player))
            {
                EncounterPlayer();
            }
        }
    }
    //funcion para cuando el jugador llega a ella antes de que se acabe el tiempo, hace que el spawner sume un contador para spawnear y luego se cambiara a otra ubicacion

    public void EncounterPlayer()
    {
        //activar evento de c# para que otros script actuen cuando el jugador encuentra a la novia
        OnActive?.Invoke();

        //cambiar la ubicacion
        ChangeUbication();
    }

    //funcion para cuando el jugador no llegue a tiempo, se le quitara vida y se cambiara de ubicacion

    void NotEncounterPlayer()
    {
        //cambiar el estado del juego a GameOver
        GameManager.SwitchState(GameState.GameOver);
    }

    //funcion para cambiar de ubicacion

    void ChangeUbication()
    {
        //elegir una ubicacion al azar de las posibles ubicaciones
        int index = Random.Range(0, ubications.Length);

        //transportarse a dicha ubicacion
        transform.position = ubications[index].position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, .7f);
    }
}
