using System;
using System.Windows.Media.TextFormatting;

public class Parser
{
	public Parser() { }

	public static void ParseInList(string str, List<string> list)
	{
		string[] splitStr = str.Split(' ');

		foreach (var word in splitStr)
		{
			if (!list.Contains(word) && word != " ")
			{
				list.Add(word);
			}
		}
	}


}
