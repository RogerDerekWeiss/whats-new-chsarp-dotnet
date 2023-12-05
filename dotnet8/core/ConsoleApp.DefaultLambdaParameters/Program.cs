var developerGrading = (int level = -1) => level switch
{
    1 => "Junior",
    2 => "Mid-level",
    3 => "Senior",
    -1 => "Unknown"
};

Console.WriteLine(developerGrading(1));
Console.WriteLine(developerGrading());