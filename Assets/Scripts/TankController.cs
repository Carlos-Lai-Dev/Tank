using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int number;
    [SerializeField] private GameObject shellPrefab;
    [SerializeField] private KeyCode fireKey;
    [SerializeField] private Transform firePosition;
    [SerializeField] private float shellSpeed;
    [SerializeField] private GameObject tankExplosion;
    [SerializeField] private AudioClip fireAudio;
    [SerializeField] private AudioClip tankExplosionAudio;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource miniAS;
    [SerializeField] private AudioClip idleAudio;
    [SerializeField] private AudioClip dravingAudio;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private int Health = 100;


    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("VerticalPlayer" + number);
        float horizontal = Input.GetAxis("HorizontalPlayer" + number);
        rb.velocity = transform.forward * vertical * moveSpeed;
        //Vector3.forward ָ������������Z��������򣬲�������������ת���ı�
        //transform.forwardָ�����������������Z��������򣬻�����������ת���ı�
        //rb.velocity = Vector3.forward * vertical * moveSpeed;
        //rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,vertical * moveSpeed);
        rb.angularVelocity = Vector3.up * horizontal * rotateSpeed;
        
            if (Mathf.Abs(vertical) > 0)
            {
                miniAS.clip = dravingAudio;
                if (miniAS.isPlaying == false)
                    miniAS.Play();
            }
            else
            {
                miniAS.clip = idleAudio;
                if (miniAS.isPlaying == false)
                    miniAS.Play();
        }
        

    }

    private void Start()
    {
        //�ڵ�ǰ������Ѱ����Ϊ ��FirePosition�� ��������
        //firePosition = transform.Find("FirePosition");
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            audioSource.PlayOneShot(fireAudio);
            GameObject shell = Instantiate(shellPrefab, firePosition.position, firePosition.rotation);
            shell.GetComponent<Rigidbody>().velocity = shell.transform.forward * shellSpeed;
            
        }
    }

   public void TakeDamage()
   {
        if (Health > 0)
        {
            Health -= Random.Range(15, 25);
        }
        else {

            //audioSource.PlayOneShot(tankExplosionAudio);
            Instantiate(tankExplosion,transform.position,transform.rotation);
            Destroy(gameObject);
        }
        
        healthSlider.value = (float)Health/100;

   }

}
