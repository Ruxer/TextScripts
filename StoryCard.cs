using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryCard : StoryItemBase{


    public string Description;

    public string[] Options;
    public StoryItemBase[] Items;

    public StoryState[] StatesToSetTrue;
    public StoryState[] StatesToSetFalse;



    public override void Activate(GameManager gm)
    {
        // base.Activate(gm);

        gm.SetCardDetails(Description, Options, Items);

        UpdateStates();


    }

    private void UpdateStates()
    {

        if(StatesToSetTrue != null)
        {
            foreach(StoryState state in StatesToSetTrue)
            {
                state.Value = true;
            }
        }
        if(StatesToSetFalse != null)
        {
            foreach (StoryState state in StatesToSetFalse)
            {
                state.Value = false;
            }
        }

    }



}
