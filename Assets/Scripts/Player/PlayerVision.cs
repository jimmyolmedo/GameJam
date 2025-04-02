using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.HableCurve;

public class PlayerVision : MonoBehaviour
{
    Vector2 player;
    [SerializeField] float distance;

    [SerializeField] Transform pointA;
    Vector2 hitPosA;
    Vector2 hitPosB;
    [SerializeField] Transform pointB;
    [SerializeField] Transform pointc;
    [SerializeField] LayerMask wall;

    private void Start()
    {
            
    }


    private void Update()   
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        float xx = player.x - mousePos.x;
        float yy = player.y - mousePos.y;
        float rad = Mathf.Atan2(yy, xx);

        float x = Mathf.Cos(rad) * -distance;
        float y = Mathf.Sin(rad) * -distance;

        //transform.localPosition = new Vector3(x, y);

        float angle = rad * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateVision();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<MeshFilter>().mesh = null;
        }

    }

    void WallDetected()
    {
        RaycastHit2D hitA = Physics2D.Raycast(transform.position, (pointA.position + -transform.right), Mathf.Infinity, wall);

        if(hitA.collider != null)
        {
            hitPosA = hitA.point;
        }

        RaycastHit2D hitB = Physics2D.Raycast(transform.position, (pointB.position + -transform.right), Mathf.Infinity, wall);

        if (hitB.collider != null)
        {
            hitPosB = hitB.point;
        }
    }   

    void GenerateVision()
    {
        WallDetected();

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[3];
        int[] triangles = new int[3];

        vertices[0] = transform.position;
        vertices[1] = hitPosA;
        vertices[2] = hitPosB;

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pointA.position, pointA.position + transform.right * 5);
        Gizmos.DrawLine(pointB.position, pointB.position + transform.right * 5);
    }

}
    