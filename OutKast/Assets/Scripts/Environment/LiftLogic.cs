using UnityEngine;

public class LiftLogic : MonoBehaviour
{
    public Transform topTarget;
    public Transform bottomTarget;
    public Transform playerCheckTransfrom;
    public LayerMask whatIsPlayer;
    public float speed = 1;
    bool playerIsThere = false;


    void Update()
    {
        playerIsThere = Physics2D.OverlapBox(playerCheckTransfrom.position, playerCheckTransfrom.localScale,0, whatIsPlayer);
        if (playerIsThere)
        {
            transform.position = Vector3.MoveTowards(transform.position, topTarget.position, speed * Time.deltaTime);
        }
    }

    public void MoveToBottomTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, bottomTarget.position, speed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(playerCheckTransfrom.position, playerCheckTransfrom.localScale);
    }
}
