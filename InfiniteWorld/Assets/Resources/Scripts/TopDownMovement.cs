using UnityEngine;

public class TopDownMovement : Photon.MonoBehaviour
{
    public Animator animator;    
    public int speed = 5;
    public int faceRightOffsetAngle;
    private bool isMoving;
   	
	void Update () 
    {
        if (photonView.isMine)
        {
            var movementVector = GetMovementVector();
            MovementAnimation(movementVector);
            FaceDirection(movementVector);
            transform.position += movementVector;
        }
        else
        {
            SyncedMovement();
        }
	}

    

    private Vector3 GetMovementVector()
    {
        Vector3 newDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        newDirection.Normalize();        
        return newDirection * Time.deltaTime * speed;
    }

    private void MovementAnimation(Vector3 movementVector)
    {
        isMoving = movementVector != Vector3.zero;
        animator.SetBool("isMoving", isMoving);
    }

    private void FaceDirection(Vector3 movementVector)
    {
        if (movementVector != Vector3.zero)
        {            
            float angle = Mathf.Atan2(movementVector.y, movementVector.x) * Mathf.Rad2Deg + faceRightOffsetAngle;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private Vector3 newPosition;
    private Quaternion newRotation;
    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(isMoving);
        }
        else
        {
            // Network player, receive data
            newPosition = (Vector3)stream.ReceiveNext();
            newRotation = (Quaternion)stream.ReceiveNext();
            isMoving = (bool)stream.ReceiveNext();

            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;
        }
    }

    private void SyncedMovement()
    {
        syncTime += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, newPosition, syncTime / syncDelay);
        transform.rotation = this.newRotation;
        animator.SetBool("isMoving", isMoving);
    }
}
