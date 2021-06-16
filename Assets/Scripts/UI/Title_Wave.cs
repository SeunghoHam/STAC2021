using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Wave : MonoBehaviour
{
   [SerializeField] Transform[] m_tfBackgrounds = null;
   [SerializeField] float m_speed = 0f;

   float leftPosX = 0f;
   float rightPosX = 0f;

   private void Start() {
       float t_length = m_tfBackgrounds[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
       leftPosX = -t_length;
       rightPosX = t_length * m_tfBackgrounds.Length;
   }

   private void Update() {
       for(int i=0; i< m_tfBackgrounds.Length; i++)
       {
           m_tfBackgrounds[i].position += new Vector3(m_speed, 0,0) * Time.deltaTime;

           if(m_tfBackgrounds[i].position.x < leftPosX)
           {
               Vector3 selfPos = m_tfBackgrounds[i].position;
               selfPos.Set(selfPos.x + rightPosX, selfPos.y , selfPos.z);
               m_tfBackgrounds[i].position = selfPos;
           }
       }
   }
}
