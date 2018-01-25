using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	public Text Description;
	public Button[] OptionButtons;
	
	public StoryItemBase CurrentItem;


	private  int _numButtons;//button的个数
	private Text[] _buttonTexts;//保存button上的Text组件
	private string[] _optionTexts;
	private StoryItemBase[] _optionItems;


	// Use this for initialization
	void Start () {

        _numButtons = OptionButtons.GetLength(0);//获取optionButton的个数

       


        //调用方法，获取选项的Text组件。
      GetButtonTexts();


        CurrentItem.Activate(this);
		
		
	}
	
    //Def
	private void GetButtonTexts()
	{
        _buttonTexts = new Text[_numButtons];

        for(int i = 0; i < _numButtons; i++)
        {
                //获取Text组件并确保激活。
            _buttonTexts[i] = OptionButtons[i].GetComponentInChildren<Text>(true);

           

        }
			
		
		
	}
	
	//获取StoryCard上保存的数据,并更新UI。   可以写一个函数。
    public void SetCardDetails(string desc, string[] optionTexts, StoryItemBase[] optionItems)
    {

        Description.text = desc;
        _optionTexts = optionTexts;
        _optionItems = optionItems;

        //更新UI
        // UpdateButtons();
        UpdateButtonTexts();

    }


    //更新UI
    public void UpdateButtons()
    {

        int numOptionTexts = _optionTexts == null ? 0 : _optionTexts.GetLength(0);

        int numOptionItems = _optionItems == null ? 0 : _optionItems.GetLength(0);

        int numActiveButtion = Math.Min(numOptionItems, numOptionTexts);

        for(int i = 0; i < _numButtons; i++)
        {

            if (i < numActiveButtion)
            {

                OptionButtons[i].gameObject.SetActive(true);
                _buttonTexts[i].text = _optionTexts[i];


            }
            else
            {
                OptionButtons[i].gameObject.SetActive(false);

            }


        }
       



    }



    //更新Button的Text内容
    public void UpdateButtonTexts()
    {
        //_optionTexts:text字符串.
        //_buttonTexts: Text组件.
      for(int i = 0; i < _numButtons; i++)
        {

            _buttonTexts[i].text = _optionTexts[i];

        }






    }



    //响应Button点击事件
     public void OnButton(int index )
    {

        

       SetCurrentStoryItem(_optionItems[index]);


    }

    public void SetCurrentStoryItem(StoryItemBase item)
    {

        CurrentItem = item;
        CurrentItem.Activate(this);

    }

     
	
}
