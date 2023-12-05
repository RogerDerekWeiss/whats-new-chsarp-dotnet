var array = new StatusArray();
array[0] = "Active";
array[1] = "Active";
array[1] = "Active";

[System.Runtime.CompilerServices.InlineArray(3)]
public struct StatusArray
{
    private string _value;
}



