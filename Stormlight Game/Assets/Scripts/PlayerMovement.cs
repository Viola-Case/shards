using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;

    float rbDrag = 6f;

    float horiMove;
    float vertMove;

    Vector3 moveDir;

    Rigidbody rb;

	private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
	}

    void ControlDrag() {
        rb.drag = rbDrag;
	}

	private void Update() {
        MyInput();
        ControlDrag();
	}

    void MyInput() {
        horiMove = Input.GetAxisRaw("Horizontal");
        vertMove = Input.GetAxisRaw("Vertical");

        moveDir = transform.forward * vertMove + transform.right * horiMove;

        print(moveDir); 
    }

	private void FixedUpdate() {
        movePlayer();
	}

    void movePlayer() {
        rb.AddForce(moveDir.normalized * moveSpeed, ForceMode.Acceleration);
    }

}
