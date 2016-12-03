using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{

    public Animation ani;

    void Start()
    {
        ani = GetComponent<Animation>();

        ani.Play();
    }

}