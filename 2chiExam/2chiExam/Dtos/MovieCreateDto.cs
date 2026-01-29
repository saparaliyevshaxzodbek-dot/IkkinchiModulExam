using System;
using System.Collections.Generic;
using System.Text;

namespace _2chiExam.Dtos;

public class MovieCreateDto
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int DurationMinutes { get; set; }
    public double Reting { get; set; }
    public long BoxOfficeEarnings { get; set; }
}
