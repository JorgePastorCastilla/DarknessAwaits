using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombinationSwitch : SwitchItem
{

  
  public CombinationSwitch[] combinationSwitches;
  public CombinationSwitch[] activationSwitches;
  public virtual void OnMouseDown()
  {
    if (switchOn && interactiveItem != null)
    {
      if (animator != null)
      {
        bool newValue = animator.GetBool("isActive");
        animator.SetBool("isActive", !newValue);
        audioSource.Play();
      }
      if (CanActivateDeactivate())
      {
          interactiveItem.Activate();
      }
      else
      {
        if (interactiveItem.isActive)
        {
          interactiveItem.Deactivate();

        }
      }
    }
  }
  
  public virtual bool CanActivateDeactivate()
  {
    for (int i=0; i < combinationSwitches.Length; i++)
    {
      if ( activationSwitches.Contains(combinationSwitches[i]) )
      {
        if ( !combinationSwitches[i].animator.GetBool( "isActive" ) )
        {
          return false;
        }
      }else if (combinationSwitches[i].animator.GetBool( "isActive" ) )
      {
        return false;
      }
    }
    return true;
  }
    
    
}
