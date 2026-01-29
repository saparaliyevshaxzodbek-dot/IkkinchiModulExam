using _2chiExam.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2chiExam.Extesions;

public static class MovieExtension
{
    public static int Hour(this int Soat)
    {
        var time = Soat / 60;
        return time;
    }

    public static long SumMoney(this List<MovieGetDto> SumMoney)
    {
        long sum = 0;
        foreach(MovieGetDto item in SumMoney)
        {
            sum = sum + item.BoxOfficeEarnings;
        }
        return sum;
    }
}
