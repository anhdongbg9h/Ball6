using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClipJump, audioClipCollisionEnemySquare, audioClipCollisionEnemySquareAtTop;
    public AudioClip audioClipMagnetCoin, audioClipMoveBoat, audioClipBounce;
    public void Jump()
    {
        audioSource.PlayOneShot(audioClipJump, 1);
    }
    public void CollisionEnemySquare(GameObject obj)
    {
        if (obj.GetComponent<Enemy>().atTop)
        {
            YeahVoice();
        }
        else
        {
            HeyVoice();
        }
    }

    public void CollisionMagnetCoin()
    {
        audioSource.PlayOneShot(audioClipMagnetCoin, 1);
    }
    public void MoveBoat()
    {
        audioSource.PlayOneShot(audioClipMoveBoat, 1);
    }
    public void HeyVoice()
    {
        audioSource.PlayOneShot(audioClipCollisionEnemySquare, 1);
    }

    public void YeahVoice()
    {
        audioSource.PlayOneShot(audioClipCollisionEnemySquareAtTop, 1);
    }
    public void BounceVoice()
    {
        audioSource.PlayOneShot(audioClipBounce, 1);
    }
}
