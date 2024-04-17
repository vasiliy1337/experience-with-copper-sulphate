using UnityEngine;

public class lozhkaMoving : MonoBehaviour
{
    public GameObject objectToHide;
    public Animator anim;
    public Rigidbody rb;
    public float moveSpeed = 1f;

    private Vector3 originalPosition; // начальная позиция объекта
    private bool isFilled = false;
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
        objectToHide.SetActive(false);
        rb.freezeRotation = true;
    }

    private void Update()
    {
        ResetVelocity();
        if (Input.GetMouseButtonUp(0))
        {
            transform.position = originalPosition;
            objectToHide.SetActive(false);
            isFilled = false;
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
        if (other.gameObject.tag == "emk1" && isFilled == false)
        {
            anim.Play("spoon_get");
            objectToHide.SetActive(true);
            isFilled = true;
        }
        if (other.gameObject.tag == "kolba" && isFilled == true && main.ColoredWater == false)
        {
            anim.Play("spoon_colba");
            main.ColoredWater = true;
            isFilled = false;
        }
    }
}