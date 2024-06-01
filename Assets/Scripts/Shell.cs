using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private GameObject shellExplosion;
    //public GameObject tank;
    //[SerializeField] private AudioClip shellExplosionAudio;
    //[SerializeField] private AudioSource audioSorce;

    private void OnTriggerEnter(Collider other)
    {
        //audioSorce.PlayOneShot(shellExplosionAudio);
        Instantiate(shellExplosion, transform.position, transform.rotation);


        //if(other.CompareTag("Tank"))
        if (other.tag == "Tank")
        {
            other.SendMessage("TakeDamage");

        }
        Destroy(gameObject);
    }

}
