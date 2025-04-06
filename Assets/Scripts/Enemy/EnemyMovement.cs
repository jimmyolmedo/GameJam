using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool isMoving;
    Vector2 direction;
    Collider2D wallCollider;//se guardara el collider de la pared por si choca

    private void Awake()
    {
        EnemyManager.instance.AddEnemy(this);
    }

    private void Start()
    {
        StartCoroutine(WaitingToMove());
    }

    IEnumerator WaitingToMove()
    {
        while(true)
        {
            movement();
            isMoving = true;
            yield return new WaitForSeconds(5f);
            isMoving = false;
            yield return new WaitForSeconds(3f);
        }
    }

    private void Update()
    {
        

        if(isMoving)
        {
            if(GameManager.CurrentState != GameState.Gameplay) { return; }
            transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        }

        PlayerDodge();
    }

    void movement()
    {
        //crear un vector2 a partir de numeros random entre los limites del nivel actual
        float x = Random.Range(-5, 5f); 
        float y = Random.Range(-5, 5);
        
        direction = new Vector2(x, y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Vector3.Distance(transform.position, direction));

        Debug.DrawLine(transform.position, hit.point);

        if(hit.collider != null && hit.collider != this.transform.GetComponent<Collider2D>())
        {
            direction = hit.point;
        }

    }

    void PlayerDodge()
    {
        Collider2D coll = Physics2D.OverlapCircle(transform.position, 1f);

        if(coll != null)
        {
            if(coll.gameObject.TryGetComponent<PlayerVision>(out PlayerVision player))
            {
                // Calculamos la dirección opuesta a la del jugador
                Vector2 directionAway = (transform.position - coll.transform.position).normalized;

                // Mover el objeto en la dirección opuesta
                transform.Translate(directionAway * speed * Time.deltaTime);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
