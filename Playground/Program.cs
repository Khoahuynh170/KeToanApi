using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;

namespace Playground;

class Program
{
    static void Main(string[] args)
    {
        decimal[] money = { 1_200_000m, 350_000m, 2_000_000m, 500_000m, 6_000_000m, 7_000_000m };
        decimal tongchi = 0;
        decimal max = 0;
        int khoanglon = 0;
        int i = 1;
        foreach (var amount in money)
        {
            string mucdo = amount switch
            {
                <1_000_000m  => "Nhỏ",
                >=1_000_000m and <=5_000_000m  => "Vừa",
                _    => "Lớn"
            };

            if (mucdo=="Lớn")
            {
                khoanglon++;
            }
            if (amount > max) max = amount;
            tongchi += amount;
            Console.WriteLine($"Khoan {i}: {amount:N0} d - {mucdo}");
            i++;
        }
        Console.WriteLine($"Tong chi: {tongchi:N0}");
        Console.WriteLine($"Khoang chi lon nhat: {max:N0}");
        Console.WriteLine($"So khoan chi lon: {khoanglon}");
        Console.WriteLine($"Tong chi sau VAT: {CalculateVat(tongchi):N0}");
    }



    static decimal CalculateVat(decimal price, decimal rate = 0.1m)
    {
        price = price + price * rate;
        return price;
    }

    // ==================================
}