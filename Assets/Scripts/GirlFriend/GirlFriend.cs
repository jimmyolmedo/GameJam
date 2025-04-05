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

    //funcion para cuando el jugador llega a ella antes de que se acabe el tiempo, hace que el spawner sume un contador para spawnear y luego se cambiara a otra ubicacion

    public void EncounterPlayer()
    {
        //comunicarse con el health manager para sumarle vida al jugador en funcion al tiempo restante

        //cambiar la ubicacion
        ChangeUbication();
    }

    //funcion para cuando el jugador no llegue a tiempo, se le quitara vida y se cambiara de ubicacion

    void NotEncounterPlayer()
    {
        //comuncarse con el health manager para quitar vida al jugador

        //cambiar la ubicacion
        ChangeUbication();
    }

    //funcion para cambiar de ubicacion

    void ChangeUbication()
    {
        //elegir una ubicacion al azar de las posibles ubicaciones
        int index = Random.Range(0, ubications.Length);

        //transportarse a dicha ubicacion
        transform.position = ubications[index].position;
    }
}
