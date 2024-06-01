using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    Vector3 offSet;
    private void Start()
    {
        offSet = transform.position - (player1.position + player2.position) / 2;
    }

    private void Update()
    {

        if (player1 == null || player2 == null) return;
        transform.position = (player1.position + player2.position) / 2 + offSet;
        float distance = Vector3.Distance(player2.position, player1.position);
        Camera.main.orthographicSize = distance * 0.58f;
        //print(Camera.main.orthographicSize);
    }
}
