using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private const string SOUNDMANAGER_VOLUME = "SoundManagerVolume";

    [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private int volume = 5;

    private void  Awake()
    {
        Instance = this;
        LoadVolume();
    }

    private void Start()
    {
        OrderManager.Instance.OnRecipeSuccessed += OrderManager_OnRecipeSuccessed;
        OrderManager.Instance.OnRecipeFailed += OrderManager_OnRecipeFailed;
        CuttingCounter.OnCut += CuttingCounter_OnCut;
        KitchenobjectHolder.OnDrop += KitchenobjectHolder_OnDrop;
        KitchenobjectHolder.OnPickup += KitchenobjectHolder_OnPickup;
        TrashCounter.OnObjectTrashed += TrashCounter_OnObjectTrashed;

       
    }

    private void TrashCounter_OnObjectTrashed(object sender, System.EventArgs e)
    {
        print("trashed");
        PlaySound(audioClipRefsSO.trash);
    }

    private void KitchenobjectHolder_OnPickup(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectPickup);
    }

    private void KitchenobjectHolder_OnDrop(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectDrop);
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.chop);
    }

    private void OrderManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.deliveryFail);
    }

    private void OrderManager_OnRecipeSuccessed(object sender, System.EventArgs e) 
    {
        PlaySound(audioClipRefsSO.deliverySuccess);
    }
    public void PlayWarningSound()
    {
        PlaySound(audioClipRefsSO.warning);
    }
    public void PlayCountDownSound()
    {
        PlaySound(audioClipRefsSO.warning);
    }


    public void PlayStepSound(float volumeMutipler= .1f) 
    {
        PlaySound(audioClipRefsSO.footstep, volumeMutipler);
    }
    private void PlaySound(AudioClip[] clips, float volumeMutipler = .1f) 
    {
        PlaySound(clips, Camera.main.transform.position, volumeMutipler);
    }

    private void PlaySound(AudioClip[] clips, Vector3 position, float volumeMutipler = .1f) 
    {
        if(volume == 0 ) return;
        int index = Random.Range(0, clips.Length);
        AudioSource.PlayClipAtPoint(clips[index], position, volumeMutipler*(volume/10.0f));
    }
    
    public void ChangeVolume()
    {
        volume++;
        if(volume > 10) 
        {
            volume = 0;
        }
        SaveVolume();
    }
   
    public int GetVolume()
    {
        return volume;
    }
    private void SaveVolume()
    {
        PlayerPrefs.SetInt(SOUNDMANAGER_VOLUME,volume);
    }
    private void LoadVolume()
    {
        volume = PlayerPrefs.GetInt(SOUNDMANAGER_VOLUME,volume);
    }

}
