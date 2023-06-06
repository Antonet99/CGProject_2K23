using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField]
    public GameObject avatar, selection,gamenvrionment,background;
    private int avatarSelected=0;
    public GameObject[] avatarModels;
    private Animator animator;
    public RuntimeAnimatorController[] animatorController;
    public Avatar[] avatarAnimation;
    public bool isBlocking, isWinner;
    public SfxManager sfxManager;
    

    //Start is called before the first frame update
    void Start()
    {
        isBlocking=false;
        isWinner=false;
        int avatarSelected = PlayerPrefs.HasKey("avatarSelected") ? PlayerPrefs.GetInt("avatarSelected") : 0;
        avatar=Instantiate(avatarModels[avatarSelected],transform.position,transform.rotation) as GameObject;
        UpdateAvatar(avatarSelected);
    }
    //Update is called every frame, if the MonoBehaviour is enabled.
    void Update()
    {
        
    }
    
    //Function to go to the next avatar (called when pressing next button)
    public void NextAvatar()
    {
        avatarSelected++;
        //check if we have reached the end of the avatar array
        if (avatarSelected >= avatarModels.Length)
        {
            avatarSelected = 0;
        }
        UpdateAvatar(avatarSelected);
        Save();
    }
    //Function to go to the previous avatar (called when pressing previous button)
    public void PreviousAvatar()
    {
        avatarSelected--;
        //check if we have reached the end of the avatar array
        if (avatarSelected < 0)
        {
            avatarSelected = avatarModels.Length-1;
        }
        UpdateAvatar(avatarSelected);
        Save();
    }
    //Function to update the avatar model
    private void UpdateAvatar(int avatarSelected)
    {
        GameObject thisModel = Instantiate(avatarModels[avatarSelected],transform.position,transform.rotation) as GameObject;
        Destroy(avatar);
        thisModel.transform.parent = transform;
        thisModel.transform.localScale=new Vector3(0.46f,0.46f,0.46f);
        avatar = thisModel;
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = animatorController[avatarSelected];// Set the animator controller
        animator.avatar = avatarAnimation[avatarSelected];// Set the avatar for animation
        animator.Play("selection");
    }
    private void Save()
    {
        PlayerPrefs.SetInt("avatarSelected", avatarSelected);
    }
    public void StartPlaying()
    {
       selection.SetActive(false);
       gamenvrionment.SetActive(true);
       background.SetActive(false);

    }    
    [ContextMenu("Punch!")]
    public void Punching()
    {
        animator.SetTrigger("Punching");
        sfxManager.FemalePunch();
    }
    [ContextMenu("Kick!")]
    public void Kicking()
    {
        animator.SetTrigger("Kicking");
        sfxManager.FemaleKick();
    }
    [ContextMenu("Block!")]
    public void Blocking()
    {
        isBlocking=!isBlocking;
        animator.SetBool("Blocking", isBlocking);
    }
    [ContextMenu("Winner!")]
    public void Winning()
    {
        isWinner=!isWinner;
        animator.SetBool("Winning", isWinner);
        sfxManager.FemaleWinning();
    }
}

