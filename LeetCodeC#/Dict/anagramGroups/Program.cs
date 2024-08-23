using System;
using System.Collections.Generic;

IList<IList<string>> GroupAnagrams(string[] strs) {
    var dict = new Dictionary<string, List<string>>();
    foreach (var currStr in strs) {
        var charArr = currStr.ToCharArray();
        Array.Sort(charArr);
        var sortedStr = new string(charArr);
        if (!dict.ContainsKey(sortedStr)) {
            dict[sortedStr] = new List<string>();
        }
        dict[sortedStr].Add(currStr);
    }

    return new List<IList<string>>(dict.Values);
}

string[] strs = {"eat", "tea", "tan", "ate", "nat", "bat"};
var result = GroupAnagrams(strs);
foreach (var group in result) {
    Console.Write("[");
    foreach (var str in group) {
        Console.Write(str + " ");
    }
    Console.WriteLine("]");
}