using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private Player player;
    private float footstepTimer;
    private float footstepTimerMax=.1f;

    private void Awake()
    {
        player=GetComponent<Player>();
    }
    private void Update()
    {
         footstepTimer = Time.time;
        if(footstepTimer<0f)
        {
            footstepTimer=footstepTimerMax;

            if (player.IsWalking())
            {
                float volume = 1f;
                SoundManger.Instance.PlayFootstepsSound(player.transform.position, volume);
            }
        }
    }
}
