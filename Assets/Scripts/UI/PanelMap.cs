using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMap
{
    public enum PanelType
    {
        ReadyPanel,
        StartPanel,
        LoadPanel,
        StoryPanel
    }


    private static PanelMap instance = new PanelMap();
    public static PanelMap Instance => instance;
    public Dictionary<PanelType, string> panelMaps;
    public Dictionary<PanelType, string> PanelMaps => panelMaps;

    public PanelMap()
    {
        panelMaps = new Dictionary<PanelType, string>(){
        {PanelType.ReadyPanel,"UI/ReadyPanel"},
        {PanelType.StartPanel,"UI/StartPanel"},
        {PanelType.LoadPanel,"UI/LoadPanel"},
        {PanelType.StoryPanel,"UI/StoryPanel"}
    };
    }


}
