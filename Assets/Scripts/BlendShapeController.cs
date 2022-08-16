using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct BlendShape
{
    public int num;
    [HideInInspector]public float weight;
}

public class BlendShapeController : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;

    [Header("Enable | Disable options")]
    [SerializeField] private bool enableEyeWide;
    [SerializeField] private bool enableDimple;
    
    [Header("Methods")][Tooltip("How to deal with each blend weights")]
    [SerializeField] private int eyeWideMethod;
    [SerializeField] private int mouthOpenMethod; 
    [SerializeField] private int mouthSmileFrownMethod;

    [Header("Blend Shapes")]
    public BlendShape EyeBlinkLeft = new BlendShape(){
        num = -1,
        weight = 0
    };
    public BlendShape EyeBlinkRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape EyeSquintLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape EyeSquintRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape EyeWideLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape EyeWideRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthSmileRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthSmileLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthFrownRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthFrownLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape LipLowerDownLeft = new BlendShape() {
    num = -1,
    weight = 0
    };
    public BlendShape LipLowerDownRight = new BlendShape() {
    num = -1,
    weight = 0
    };
    
    public BlendShape LipUpperUpLeft = new BlendShape() {
    num = -1,
    weight = 0
    };
    
    public BlendShape LipUpperUpRight = new BlendShape() {
    num = -1,
    weight = 0
    };
    
    public BlendShape MouthLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthStretchLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthStretchRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthLowerDownRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthLowerDownLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthPressLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthPressRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthOpen = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthPucker = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthShrugUpper = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape JawOpen = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape JawLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape JawRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape BrowDownLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape BrowOuterUpLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape BrowDownRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape BrowOuterUpRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape CheekSquintRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape CheekSquintLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthDimpleLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthDimpleRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthRollLower = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape MouthRollUpper = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape NoseSneerLeft = new BlendShape(){
    num = -1,
    weight = 0
    };

    public BlendShape NoseSneerRight = new BlendShape(){
    num = -1,
    weight = 0
    };

    
    
    public void UpdateBlendShape()
    {
        // Apply deformation weights
        
        //Apply Eye values
        UpdateEyes();

        //Apply mouth smile and frown values
        UpdateMouthSmileFrownWeights();
        
        UpdateBlendShapeWeight(MouthLeft.num,MouthLeft.weight);
        UpdateBlendShapeWeight(MouthRight.num,MouthRight.weight);
        
        UpdateBlendShapeWeight(MouthStretchLeft.num,MouthStretchLeft.weight);
        UpdateBlendShapeWeight(MouthStretchRight.num,MouthStretchRight.weight);
        
        UpdateBlendShapeWeight(MouthLowerDownRight.num,MouthLowerDownRight.weight);
        UpdateBlendShapeWeight(MouthLowerDownLeft.num,MouthLowerDownLeft.weight);
        
        UpdateBlendShapeWeight(MouthPressLeft.num,MouthPressLeft.weight);
        UpdateBlendShapeWeight(MouthPressRight.num,MouthPressRight.weight);

        if (mouthOpenMethod == 1)
        {
            MouthOpen.weight *= 4;
        }
        else if(mouthOpenMethod == 2)
        {
            if (MouthOpen.weight > 80)
                MouthOpen.weight = 100;
            if(MouthOpen.weight > 1)
            {
                MouthOpen.weight = MappingEffect(MouthOpen.weight, 80, 120, 0);
            }
        }
        UpdateBlendShapeWeight(MouthOpen.num,MouthOpen.weight);
        UpdateBlendShapeWeight(MouthPucker.num,MouthPucker.weight);
        
        UpdateBlendShapeWeight(MouthShrugUpper.num,MouthShrugUpper.weight);
        UpdateBlendShapeWeight(JawOpen.num,JawOpen.weight);
        UpdateBlendShapeWeight(JawLeft.num,JawLeft.weight);
        UpdateBlendShapeWeight(JawRight.num,JawRight.weight);
        
        UpdateBlendShapeWeight(BrowDownLeft.num,BrowDownLeft.weight);
        UpdateBlendShapeWeight(BrowOuterUpLeft.num,BrowOuterUpLeft.weight);
        UpdateBlendShapeWeight(BrowDownRight.num,BrowDownRight.weight);
        UpdateBlendShapeWeight(BrowOuterUpRight.num,BrowOuterUpRight.weight);
        
        UpdateBlendShapeWeight(CheekSquintRight.num,CheekSquintRight.weight);
        UpdateBlendShapeWeight(CheekSquintLeft.num,CheekSquintLeft.weight);

        UpdateBlendShapeWeight(MouthRollLower.num,MouthRollLower.weight);
        UpdateBlendShapeWeight(MouthRollUpper.num,MouthRollUpper.weight);
        UpdateBlendShapeWeight(NoseSneerLeft.num,NoseSneerLeft.weight);
        UpdateBlendShapeWeight(NoseSneerRight.num,NoseSneerRight.weight);
        
    }

    private void UpdateEyes()
    {
        UpdateBlendShapeWeight(EyeBlinkLeft.num,EyeBlinkLeft.weight);
        UpdateBlendShapeWeight(EyeBlinkRight.num,EyeBlinkRight.weight);
        UpdateBlendShapeWeight(EyeSquintLeft.num,EyeSquintLeft.weight);
        UpdateBlendShapeWeight(EyeSquintRight.num,EyeSquintRight.weight);

        if (enableEyeWide)
        {
            if (eyeWideMethod == 1)
            {
                EyeWideLeft.weight = MappingEffect(EyeWideLeft.weight - 80, 20, 100, -40);
                EyeWideRight.weight = MappingEffect(EyeWideRight.weight - 80, 20, 100, -40);
            }
            else if(eyeWideMethod == 2)
            {
                if (EyeWideLeft.weight < 90)
                {
                    EyeWideLeft.weight = 0;
                }

                if (EyeWideRight.weight < 90)
                {
                    EyeWideRight.weight = 0;
                }
            }


            UpdateBlendShapeWeight(EyeWideLeft.num, EyeWideLeft.weight);
            UpdateBlendShapeWeight(EyeWideRight.num, EyeWideRight.weight);
        }
    }
    
    private void UpdateMouthSmileFrownWeights()
    {
        if (mouthSmileFrownMethod == 1)
        {
            MouthSmileRight.weight = MappingEffect(MouthSmileRight.weight - 40,60,100,0);
            MouthSmileLeft.weight = MappingEffect(MouthSmileLeft.weight - 40,60,100,0);
            MouthDimpleLeft.weight = MappingEffect(MouthDimpleLeft.weight - 40,60,100,0);
            MouthDimpleRight.weight = MappingEffect(MouthDimpleRight.weight - 40,60,100,0);
            
        }
        UpdateBlendShapeWeight(MouthSmileRight.num,MouthSmileRight.weight);
        UpdateBlendShapeWeight(MouthSmileLeft.num,MouthSmileLeft.weight);
        if (enableDimple)
        {
            UpdateBlendShapeWeight(MouthDimpleLeft.num, MouthDimpleLeft.weight);
            UpdateBlendShapeWeight(MouthDimpleRight.num, MouthDimpleRight.weight);
        }

        UpdateBlendShapeWeight(MouthFrownRight.num,MouthFrownRight.weight);
        UpdateBlendShapeWeight(MouthFrownLeft.num,MouthFrownLeft.weight);
    }
    
    
    
    private void UpdateBlendShapeWeight(int blendNum, float blendWeight)
    {
        if (blendNum != -1)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(blendNum, Mathf.Clamp(blendWeight,0,100));
        }
    }

    //change the value between 0 upto effectOrder
    private float MappingEffect(float value, float maxValue, float effectOrder, float offset)
    {
        return (value / maxValue) * effectOrder + offset;
    }
    
}