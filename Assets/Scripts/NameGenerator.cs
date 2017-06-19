using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator {
    private static string[] forenamesM = {
        "Bob",
        "Dan"
    };

    private static string[] forenamesF = {
        "Madeline",
        "Hera"
    };

    private static string[] surnames = {
        "Alder",
        "Ash",
        "Ashe",
        "Atwood",
        "Barnes",
        "Battle",
        "Becker",
        "Berry",
        "Briggs",
        "Brock",
        "Brook",
        "Brooke",
        "Brooks",
        "Bundy",
        "Burnside",
        "Burroughs",
        "Burrows",
        "Bush",
        "Butler",
        "Clay",
        "Court",
        "Cox",
        "Croft",
        "Cross",
        "Crump",
        "Dale",
        "Dean",
        "Deane",
        "Dike",
        "Dodd",
        "Ford",
        "Forrest",
        "Fox",
        "Freeman",
        "Garside",
        "Gary",
        "Gorsuch",
        "Graves",
        "Green",
        "Greene",
        "Greeves",
        "Gross",
        "Grove",
        "Grover",
        "Hall",
        "Hawthorne",
        "Hazel",
        "Head",
        "Heather",
        "Hill",
        "Holland",
        "Holley",
        "Holly",
        "Holmes",
        "Holt",
        "Homer",
        "Hooke",
        "Hope",
        "House",
        "Howe",
        "Hume",
        "Hyde",
        "Johnston",
        "Kay",
        "Kaye",
        "Keats",
        "Kerry",
        "Kirk",
        "Kirke",
        "Knight",
        "Lamb",
        "Land",
        "Lane",
        "Layne",
        "Lea",
        "Lee",
        "Leigh",
        "Lowell",
        "Malthus",
        "March",
        "Marsh",
        "Marshal",
        "Marshall",
        "Martin",
        "May",
        "Millerchip",
        "Mills",
        "Moore",
        "Newby",
        "Pain",
        "Paine",
        "Payne",
        "Pike",
        "Pitt",
        "Preacher",
        "Provost",
        "Purple",
        "Ridge",
        "Rock",
        "Rose",
        "Seller",
        "Sellers",
        "Shaw",
        "Shore",
        "Thorn",
        "Thorne",
        "Trump",
        "Underwood",
        "Wells",
        "West",
        "Whitney",
        "Wild",
        "Wilde",
        "Wood",
        "Woodrow",
        "Woods"
    };
    
    public static string GenerateName(bool gender) {
        int a;
        int b;

        if (gender) {
            a = Random.Range(0, forenamesF.Length);
            b = Random.Range(0, surnames.Length);

            return forenamesF[a] + " " + surnames[b];
        }
        else {
            a = Random.Range(0, forenamesM.Length);
            b = Random.Range(0, surnames.Length);

            return forenamesM[a] + " " + surnames[b];
        }
    }
}
