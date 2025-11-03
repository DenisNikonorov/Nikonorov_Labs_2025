using System;
public class Parser
{
	private const int kDefaultParsedArraySize = 1;
	public Parser() { }
	public List<string> Parse(string str)
	{
		string[] parsedSrting = str.Split(' ');
		List<string> parsedNoRepeat = new List<string>();

		foreach (var x in parsedSrting)
		{
			if (!parsedNoRepeat.Contains(x) && x != " ")
			{
				parsedNoRepeat.Add(x);
			}
		}

		return parsedNoRepeat;
	}
}
