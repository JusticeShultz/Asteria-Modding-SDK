using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class DialogueManager : MonoBehaviour
{
     public static DialogueManager Instance;

    public static bool InDialogue
    {
        get
        {
            return false;
        }
    }

    //[TabGroup("Editor References")]  public TextAnimator_TMP animatedTextComp;
    //[TabGroup("Editor References")]  public TypewriterByCharacter typewriter;
    //[TabGroup("Editor References")]  public TMPro.TextMeshProUGUI dialogueText;
    //[TabGroup("Editor References")]  public TypewriterByCharacter characterName;
    //[TabGroup("Editor References")]  public TMPro.TextMeshProUGUI characterNameText;
    //[TabGroup("Editor References")]  public TypewriterByCharacter clickToContinueIndicator;
    [TabGroup("Editor References")]  public GameObject dialogueMenu;
    [TabGroup("Editor References")]  public GameObject choicesMenu;
    [TabGroup("Editor References")]  public GameObject choicesbackdrop;
    [TabGroup("Editor References")]  public GameObject choiceTemplate;
    [TabGroup("Editor References")]  public GameObject choiceAlreadySelectedTemplate;
    [TabGroup("Editor References")]  public Animator dialogueDropshadow;
    [TabGroup("Editor References")]  public DialogueChoiceTray choiceTrayExtension;
    [TabGroup("Editor References")]  public Image characterPortraitA;
    [TabGroup("Editor References")]  public Animator characterPortraitAAnimPlayer;
    [TabGroup("Editor References")]  public Image characterPortraitB;
    [TabGroup("Editor References")]  public Animator characterPortraitBAnimPlayer;

    [TabGroup("Dialogue Data")] public bool currentlyTypewriting = false;
    [TabGroup("Dialogue Data")] public Dialogue currentDialogue;
    [TabGroup("Dialogue Data")] public Dialogue savedDialogue;
    [TabGroup("Dialogue Data")] public int savedSpot = 0;
    [TabGroup("Dialogue Data")]  public bool swapStatus = false;
    [TabGroup("Dialogue Data")] public float timeSinceTypewriteEnded = 0f;
    [TabGroup("Dialogue Data")] public int currentDialogueSpot = 0;
    [TabGroup("Dialogue Data")] public bool onOptionSelection = false;
    [TabGroup("Dialogue Data")] public float nextDialogueAwait = 0f;
    [TabGroup("Dialogue Data")] public float transitionDelay = 0f;
    [TabGroup("Dialogue Data")] private bool dialogueAwaited = false;
    [TabGroup("Dialogue Data")]  public List<GameObject> currentChoices = new List<GameObject>();
    
    [TabGroup("Events")]  public UnityEvent onDialogueBegin = new UnityEvent();
    [TabGroup("Events")]  public UnityEvent onDialogueComplete = new UnityEvent();

    [TabGroup("Tools")]  public List<string> selectedChoicesThisSession = new List<string>();

    void Start()
    {
    }

    void Update()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void ContinueDialogue()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void TextStartedShowing()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void TextFinishedShowing()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void StartDialogue(Dialogue dialogueObj)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void EndDialogue()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void MakeChoice(int choice)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void PromptDecision()
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void MakeChoice(ButtonDetails choiceUsingDetails)
    {
    }

    public static void StartDialogue_Global(Dialogue dialogueObj)
    {
    }

    [TabGroup("Tools")]
    [Button]
    public void UpdateCharacterPortrait()
    {
    }

    public static string GetTranslation(DialogueObject dialogueObject, LocalizationTable localizationTable)
    {
        return "";
    }

    public static string GetTranslation_Name(DialogueObject dialogueObject, LocalizationTable localizationTable)
    {
        return "";
    }
    
    [TabGroup("Tools")]
    [Button]
    public static void TriggerGameEvent(string _gameEvent)
    {
    }
}
