using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{

    // Start is called before the first frame update
    public static float playerMovementScaling = 1f;
    public static float bulletSpeedScaling = 1f;
    public static float enemySpawnScaling = 1f;

    static AudioSource music;
    void Start() {
        music = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }
    public static void updateSpeeds(float healthRatio) {

        playerMovementScaling = healthRatio;
        bulletSpeedScaling = healthRatio;
        enemySpawnScaling = healthRatio;
        music.pitch = healthRatio;
    }


}
