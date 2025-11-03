using System;

public class Search
{
	public Search() { }

	public static int LeveshtainDistance(string source, string target)
	{
		int sourceLen = source.Length;
		int targetLen = target.Length;

		int[,] distance = new int[sourceLen + 1, targetLen + 1];

		for (int i = 0; i < sourceLen; ++i) { distance[i, 0] = i; }
		for (int j = 0; j < targetLen; ++j) { distance[0, j] = j; }

		for (int i = 1; i <= sourceLen; ++i)
		{
			for (int j = 1; j <= targetLen; ++j)
			{
				int similarity = (source[i - 1] == target[j - 1]) ? 0 : 1;

				distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + similarity);
			}
		}
		return distance[sourceLen, targetLen];
	}

	public static string SearchInList(List<string> list, string word)
	{
		if (list.Count == 0) { return "Список пуст!"; }
		if (word == string.Empty) { return "Введие слово, которое хотите найти!"; }

		string result = list[0];
		int distToRes = LeveshtainDistance(list[0], word);

		for (int i = 1; i < list.Count - 1; ++i)
		{
			int d = LeveshtainDistance(list[i], word);
			if (d < distToRes)
			{
				result = list[i];
				distToRes = d;
			}
		}

		if (LeveshtainDistance(result, word) == result.Length) { return $"Слова '{word}' не нашлось!"; }

		string add = (distToRes == 0) ? "Найденное слово: " : "Возможно вы имели в виду: ";

		return add + result;
	}
}
