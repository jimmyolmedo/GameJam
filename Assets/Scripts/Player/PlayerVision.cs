using NUnit.Framework.Internal;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerVision : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr_vision;

    [SerializeField] bool IsActive;

    private void OnEnable()
    {
        InputManager.OnVision += vision;
    }

    private void OnDisable()
    {
        InputManager.OnVision -= vision;
    }

    void vision(bool _vision)
    {
        StopAllCoroutines();
        StartCoroutine(GenerateVision(_vision));
    }

    IEnumerator GenerateVision(bool _generate)
    {
        float value = sr_vision.color.a;
        //si es true hacer un lerp para que el escenario se vea
        if (_generate)
        {
            IsActive = true;
            for (float i = 0; i < 1.5f; i += Time.deltaTime)
            {
                value = Mathf.Lerp(value, 0f, i/1.5f);
                sr_vision.color = new Color(0,0,0,value);
                yield return null;
            }
            IsActive = true;
        }


        //si es falso hacer un lerp para que el ascenario no se vea

        if (!_generate)
        {
            IsActive = false;
            for (float i = 0; i < 1.5f; i += Time.deltaTime)
            {
                value = Mathf.Lerp(value, 255f, i/1.5f);
                sr_vision.color = new Color(0, 0, 0, value);
                yield return null;
            }
        }
    }

    void GetDamage(int damage)
    {
        //hacer el daño al health manager
    }

    void CalculateDamage()
    {
        //preguntar al enemy manager cuantos enemigos hay en la escena

        //aplicarle un multiplicador dependiendo de la dificultad actual

        //usar ese numero en el GetDamage
    }

}
    