using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsReadState : MonoBehaviour
{
    public static ItemsReadState Instance;

    // Messages
    public bool valeMsgReadPres = false;
    public bool evanMsgReadPres = false;

    public bool valeMsgReadPast = false;
    public bool evanMsgReadPast = false;

    public bool valeMsgReadCorr = false;
    public bool evanMsgReadCorr = false;

    // TalkGPT
    public bool projSummReadPres = false;
    public bool profReflReadPres = false;

    public bool projSummReadPast = false;
    public bool profReflReadPast = false;

    public bool projSummReadCorr = false;
    public bool profReflReadCorr = false;
    public bool tempErasReadCorr = false;

    // File Explorer
    public bool readMeReadPres = false;
    public bool log1ReadPres = false;
    public bool log2ReadPres = false;
    public bool sysWarnReadPres = false;

    public bool readMeReadPast = false;
    public bool log1ReadPast = false;
    public bool log2ReadPast = false;

    public bool readMeReadCorr = false;
    public bool log1ReadCorr = false;
    public bool log2ReadCorr = false;
    public bool sysWarnReadCorr = false;
    public bool echoFragReadCorr = false;

    // Notes
    public bool persLogReadPres = false;
    public bool echoDraftReadPres = false;
    public bool remindersReadPres = false;

    public bool persLogReadPast = false;
    public bool echoDraftReadPast = false;
    public bool remindersReadPast = false;

    public bool persLogReadCorr = false;
    public bool echoDraftReadCorr = false;
    public bool remindersReadCorr = false;

    // Photos
    public bool labEntryReadPres = false;
    public bool cntrlRoomReadPres = false;
    public bool subFrameReadPres = false;
    public bool finalCaptReadPres = false;

    public bool labEntryReadPast = false;
    public bool cntrlRoomReadPast = false;
    public bool subFrameReadPast = false;
    public bool finalCaptReadPast = false;

    public bool labEntryReadCorr = false;
    public bool cntrlRoomReadCorr = false;
    public bool subFrameReadCorr = false;
    public bool finalCaptReadCorr = false;

    // Terminal
    public bool statusReadPres = false;
    public bool historyReadPres = false;
    public bool diagnoseReadPres = false;

    public bool statusReadPast = false;
    public bool historyReadPast = false;
    public bool diagnoseReadPast = false;

    public bool statusReadCorr = false;
    public bool historyReadCorr = false;
    public bool diagnoseReadCorr = false;

    // Trash
    public bool staffGroupReadPres = false;
    public bool argumentReadPres = false;

    public bool staffGroupReadPast = false;
    public bool argumentReadPast = false;

    public bool staffGroupReadCorr = false;
    public bool argumentReadCorr = false;
    public bool tempDispReadCorr = false;
    public bool resiPresReadCorr = false;

    public int corruptionThreshold = 15;
    public int corruptionIndex = 0;

    Dictionary<string, Func<bool>> corruptionFlags;
    HashSet<string> countedCorruption;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        corruptionFlags = new Dictionary<string, Func<bool>>()
        {
            { "valeMsgCorr", () => valeMsgReadCorr },
            { "evanMsgCorr", () => evanMsgReadCorr },
            { "projSummCorr", () => projSummReadCorr },
            { "profReflCorr", () => profReflReadCorr },
            { "tempErasCorr", () => tempErasReadCorr },
            { "readMeCorr", () => readMeReadCorr },
            { "log1Corr", () => log1ReadCorr },
            { "log2Corr", () => log2ReadCorr },
            { "sysWarnCorr", () => sysWarnReadCorr },
            { "echoFragCorr", () => echoFragReadCorr },
            { "persLogCorr", () => persLogReadCorr },
            { "echoDraftCorr", () => echoDraftReadCorr },
            { "remindersCorr", () => remindersReadCorr },
            { "labEntryCorr", () => labEntryReadCorr },
            { "cntrlRoomCorr", () => cntrlRoomReadCorr },
            { "subFrameCorr", () => subFrameReadCorr },
            { "finalCaptCorr", () => finalCaptReadCorr },
            { "statusCorr", () => statusReadCorr },
            { "historyCorr", () => historyReadCorr },
            { "diagnoseCorr", () => diagnoseReadCorr },
            { "staffGroupCorr", () => staffGroupReadCorr },
            { "argumentCorr", () => argumentReadCorr },
            { "tempDispCorr", () => tempDispReadCorr },
            { "resiPresCorr", () => resiPresReadCorr }
        };

        countedCorruption = new HashSet<string>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var entry in corruptionFlags)
        {
            bool isRead = entry.Value();

            if (isRead && !countedCorruption.Contains(entry.Key))
            {
                corruptionIndex++;
                countedCorruption.Add(entry.Key);

                if (corruptionIndex >= corruptionThreshold)
                {
                    // Game crashes / corruption ending
                }
            }
        }
    }
}
