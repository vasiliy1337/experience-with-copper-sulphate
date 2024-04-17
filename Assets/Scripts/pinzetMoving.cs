using UnityEngine;

public class pinzetMoving : MonoBehaviour
{
    private Vector3 originalPosition; // начальная позиция объекта
    public Vector3 originalPositionChild;
    public Transform originalParent;
    public Collider sk;
    public bool isDragging;

    public Rigidbody rb;
    public float moveSpeed = 1f;

    public Animator anim;

    private Vector3 mOffset;
    private float mZCoord;

    void ResetVelocity()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void Start()
    {
        originalPosition = transform.position; // сохраняем начальную позицию объекта
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        ResetVelocity();
        if (Input.GetMouseButtonUp(0))
        {
            if (main.InWater == false) {
                sk.transform.parent = originalParent;
                sk.transform.position = originalPositionChild;
                originalParent = null;
            }
            transform.position = originalPosition;
            isDragging = false;
        }


    }
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        mOffset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f)
        {
            Vector3 targetPosition = GetMouseWorldPos() + mOffset;
            targetPosition.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sk1" && main.InWater == false)
        {
            sk = other;
            originalPositionChild = other.transform.position;
            originalParent = other.transform.parent;
            other.transform.parent = transform;
            other.transform.position = transform.localPosition + new Vector3(0f, 0f, 0.06f);
            isDragging = true;
        }
        if (other.gameObject.tag == "kolba" && isDragging == true)
        {
            anim.Play("pinzet_put");
            sk.transform.parent = originalParent;
            sk.transform.position = other.transform.position + new Vector3(0f, -0.07f, 0f);
            main.InWater = true;
            isDragging = false;
        }

    }
}