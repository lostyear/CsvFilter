using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvFilter
{
  class FileFilter
  {
    string[][] contentArry = null;
    HashSet<string>[] keySetArry = null;
    int maxColumnCount = 0;

    public FileFilter(string filePath)
    {
      using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath, Encoding.Default, false))
      {
        List<string[]> contentList = new List<string[]>();

        while (!sr.EndOfStream)
        {
          string lineStr = sr.ReadLine();
          string[] lineArry = lineStr.Split(new char[] { ',' });

          if (lineArry.Length > maxColumnCount)
            maxColumnCount = lineArry.Length;

          contentList.Add(lineArry);
        }

        contentArry = contentList.ToArray();
      }

      keySetArry = new HashSet<string>[maxColumnCount];
      for (int i = 0; i < maxColumnCount; ++i)
      {
        keySetArry[i] = new HashSet<string>();
      }

      foreach (string[] lineArry in contentArry)
      {
        for (int i = 0; i < lineArry.Length; ++i)
        {
          keySetArry[i].Add(lineArry[i]);
        }
      }
    }
  }
}
