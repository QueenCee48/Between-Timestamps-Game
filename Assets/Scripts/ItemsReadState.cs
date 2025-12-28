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

    public float corruptionThreshold = 80;
    public float corruptionIndex = 0;
    float corruptionTimer = 0;

    public float presentThreshold = 15;
    public float presentIndex = 0;

    public float pastThreshold = 14;
    public float pastIndex = 0;

    Dictionary<string, Func<bool>> corruptionFlags;
    HashSet<string> countedCorruption;

    Dictionary<string, Func<bool>> presentFlags;
    HashSet<string> countedPresent;

    Dictionary<string, Func<bool>> pastFlags;
    HashSet<string> countedPast;

    public string endingTitle;
    public string endingText;

    ScreenController canvas;

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

        presentFlags = new Dictionary<string, Func<bool>>()
        {
            { "valeMsgPres", () => valeMsgReadPres },
            { "evanMsgPres", () => evanMsgReadPres },
            { "projSummPres", () => projSummReadPres },
            { "profReflPres", () => profReflReadPres },
            { "readMePres", () => readMeReadPres },
            { "log1Pres", () => log1ReadPres },
            { "log2Pres", () => log2ReadPres },
            { "sysWarnPres", () => sysWarnReadPres },
            { "persLogPres", () => persLogReadPres },
            { "echoDraftPres", () => echoDraftReadPres },
            { "remindersPres", () => remindersReadPres },
            { "labEntryPres", () => labEntryReadPres },
            { "cntrlRoomPres", () => cntrlRoomReadPres },
            { "subFramePres", () => subFrameReadPres },
            { "finalCaptPres", () => finalCaptReadPres },
            { "statusPres", () => statusReadPres },
            { "historyPres", () => historyReadPres },
            { "diagnosePres", () => diagnoseReadPres },
            { "staffGroupPres", () => staffGroupReadPres },
            { "argumentPres", () => argumentReadPres }
        };

        pastFlags = new Dictionary<string, Func<bool>>()
        {
            { "valeMsgPast", () => valeMsgReadPast },
            { "evanMsgPast", () => evanMsgReadPast },
            { "projSummPast", () => projSummReadPast },
            { "profReflPast", () => profReflReadPast },
            { "readMePast", () => readMeReadPast },
            { "log1Past", () => log1ReadPast },
            { "log2Past", () => log2ReadPast },
            { "persLogPast", () => persLogReadPast },
            { "echoDraftPast", () => echoDraftReadPast },
            { "remindersPast", () => remindersReadPast },
            { "labEntryPast", () => labEntryReadPast },
            { "cntrlRoomPast", () => cntrlRoomReadPast },
            { "subFramePast", () => subFrameReadPast },
            { "finalCaptPast", () => finalCaptReadPast },
            { "statusPast", () => statusReadPast },
            { "historyPast", () => historyReadPast },
            { "diagnosePast", () => diagnoseReadPast },
            { "staffGroupPast", () => staffGroupReadPast },
            { "argumentPast", () => argumentReadPast }
        };

        countedCorruption = new HashSet<string>();
        countedPresent = new HashSet<string>();
        countedPast = new HashSet<string>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<ScreenController>();
    }

    // Update is called once per frame
    void Update()
    {
        corruptionTimer += Time.deltaTime;

        if (corruptionTimer >= 1)
        {
            corruptionIndex += 0.25f;
            corruptionTimer = 0;
        }

        foreach (var entry in corruptionFlags)
        {
            bool isRead = entry.Value();

            if (isRead && !countedCorruption.Contains(entry.Key))
            {
                if (entry.Key == "finalCaptCorr" || entry.Key == "argumentCorr" || entry.Key == "resiPresCorr" || 
                        entry.Key == "tempDispCorr" || entry.Key == "tempErasCorr" || entry.Key == "historyCorr")
                {
                    corruptionIndex += 3;
                }
                else 
                {
                    corruptionIndex += 0.5f;
                }
                countedCorruption.Add(entry.Key);
            }
        }

        foreach (var entry in presentFlags)
        {
            bool isRead = entry.Value();

            if (isRead && !countedPresent.Contains(entry.Key))
            {
                if (entry.Key == "staffGroupPres" || entry.Key == "argumentPres" || entry.Key == "profReflPres" || 
                        entry.Key == "statusPres")
                {
                    presentIndex += 3;
                }
                else 
                {
                    presentIndex += 0.5f;
                }
                countedPresent.Add(entry.Key);
            }
        }

        foreach (var entry in pastFlags)
        {
            bool isRead = entry.Value();

            if (isRead && !countedPast.Contains(entry.Key))
            {
                if (entry.Key == "staffGroupPast" || entry.Key == "argumentPast" || entry.Key == "projSummPast" || 
                        entry.Key == "log1Past")
                {
                    pastIndex += 3;
                }
                else 
                {
                    pastIndex += 0.5f;
                }
                countedPast.Add(entry.Key);
            }
        }

        if (corruptionIndex >= corruptionThreshold)
        {
            // Game crashes / corruption ending

            // The archive became too corrupted and all files vanished. See me in my office immediately.

            endingTitle = "Ending: TOTAL DATA LOSS";
            endingText = "- Archive Node #408 has exceeded recoverable corruption limits.";
            endingText += "\n- All remaining data collapsed during extraction.";
            endingText += "\n\nThis outcome was preventable.";
            endingText += "\nReport to my office immediately.";

            canvas.SubmitReport();
        }
        else if (presentIndex >= presentThreshold && pastIndex < pastThreshold)
        {
            // Present stabilized ending

            if (staffGroupReadPres && argumentReadPres && profReflReadPres && statusReadPres)
            {
                // All critical present files retrieved. Present has been stabilized but the past is still unstable.
                // You should have spent more time reviewing the archive. Let this be your warning...

                endingTitle = "Ending: TEMPORAL CONTAINMENT: PRESENT";
                endingText = "- The present layer has stabilized.";
                endingText += "\n- Key data fragments were recovered and contained.";
                endingText += "\n- The past remains volatile.";
                endingText += "\n\nYou were closer than you realize.";
                endingText += "\nDo not repeat this oversight.";
            }
            else
            {
                // Present has been stabilized but not all critical present files were retrieved and the past is still unstable.
                // You should have looked more carefully. Let this be your warning...

                endingTitle = "Ending: PARTIAL CONTAINMENT";
                endingText = "- The present layer has stabilized...barely.";
                endingText += "\n- Several critical data points were overlooked.";
                endingText += "\n\nGaps like these are how archives fail silently.";
                endingText += "\nLet this be your warning.";
            }
        }
        else if (pastIndex >= pastThreshold && presentIndex < presentThreshold)
        {
            // Past stabilized ending

            if (staffGroupReadPast && argumentReadPast && projSummReadPast && log1ReadPast)
            {
                // All critical past files retrieved. Past has been stabilized but the present is still unstable.
                // You should have spent more time reviewing the archive. Let this be your warning...

                endingTitle = "Ending: TEMPORAL CONTAINMENT: PAST";
                endingText = "- The past layer has stabilized.";
                endingText += "\n- Foundational records were successfully preserved.";
                endingText += "\n- The present remains unstable.";
                endingText += "\n\nHistory held.";
                endingText += "\nThe rest did not.";
            }
            else
            {
                // Past has been stabilized but not all critical past files were retrieved and the present is still unstable.
                // You should have looked more carefully. Let this be your warning...

                endingTitle = "Ending: ERODED FOUNDATIONS";
                endingText = "- The past has stabilized, but critical records were lost.";
                endingText += "\n- What remains is incomplete.";
                endingText += "\n\nReconstruction will be… speculative.";
                endingText += "\nThis outcome is on you.";
            }
        }
        else if (pastIndex >= pastThreshold && presentIndex >= presentThreshold)
        {
            // Complete ending

            if (staffGroupReadPres && argumentReadPres && profReflReadPres && statusReadPres && staffGroupReadPast && argumentReadPast && projSummReadPast && log1ReadPast)
            {
                // All critical files retrieved. Archive has been stabilized.
                // Great work hunter. Prepare for your next assignment.

                endingTitle = "Ending: ARCHIVE SECURED";
                endingText = "- Archive Node #408 has stabilized across all temporal layers.";
                endingText += "\n- All critical data fragments were recovered.";
                endingText += "\n- This archive will no longer degrade.";
                endingText += "\n\nExcellent work, Memory Hunter.";
                endingText += "\nPrepare for reassignment.";
            }
            else
            {
                // Archive has been stabilized but not all critical files were retrieved.
                // We lost some critical files. Make sure to look out for those next time.

                endingTitle = "Ending: STABLE, BUT INCOMPLETE";
                endingText = "- Archive Node #408 has stabilized.";
                endingText += "\n- Several critical data fragments were not recovered.";
                endingText += "\n\nWhat was lost cannot be reconstructed.";
                endingText += "\nStability does not mean success.";
            }
        }
        else if (pastIndex < pastThreshold && presentIndex < presentThreshold)
        {
            // Incomplete ending
            
            if (staffGroupReadPres && argumentReadPres && profReflReadPres && statusReadPres && staffGroupReadPast && argumentReadPast && projSummReadPast && log1ReadPast)
            {
                // All critical files retrieved but the archive has not been stabilized.
                // You did not complete the assignment hunter. Do better next time.

                endingTitle = "Ending: MISALIGNED EXTRACTION";
                endingText = "- All critical files were identified.";
                endingText += "\n- The archive remains unstable.";
                endingText += "\n\nInsight without resolution is failure.";
                endingText += "\nYou did not complete the assignment.";
            }
            else
            {
                // Archive was not stabilized and critical Files were not retrieved.
                // Did you even try to complete the assignment? See me in my office immediately.

                endingTitle = "Ending: ASSIGNMENT FAILED";
                endingText = "- Archive Node #408 was not stabilized.";
                endingText += "\n- Critical data was ignored or lost.";
                endingText += "\n\nThis level of negligence is unacceptable.";
                endingText += "\nSee me in my office immediately.";
            }
        }
    }
}
